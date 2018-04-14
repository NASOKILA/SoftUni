$(() => {

    const app = Sammy('main', function () {

        this.use('Handlebars', 'hbs');

        this.get('/', (ctx) => {

            ctx.isAuth = auth.isAuth();
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                footer: '../templates/common/footer.hbs',
            }).then(function () {
                this.partial('../templates/welcome.hbs');
            });

        })

        this.get('#home', (ctx) => {


            ctx.isAuth = auth.isAuth();

            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                footer: '../templates/common/footer.hbs',
            }).then(function () {
                this.partial('../templates/welcome.hbs');
            });

        })

        this.get('#register', (ctx) => {

            ctx.isAuth = auth.isAuth();
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                registerForm: '../templates/forms/registerForm.hbs',
                footer: '../templates/common/footer.hbs',
            }).then(function () {
                this.partial('../templates/viewregister.hbs');
            })

        })

        this.post('#register', (ctx) => {

            let password = ctx.params.passwd;
            let username = ctx.params.username;

            auth.register(username, password)
                .then((userData) => {
                    auth.saveSession(userData);
                    notify.showInfo(`User ${username} has registered successfully!`)
                    ctx.redirect('#home');
                })
                .catch(notify.handleError);
        })

        this.get('#login', (ctx) => {

            ctx.isAuth = auth.isAuth();
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                loginForm: '../templates/forms/loginForm.hbs',
                footer: '../templates/common/footer.hbs',
            }).then(function () {
                this.partial('../templates/viewLogin.hbs');
            })

        })

        this.post('#login', (ctx) => {

            let password = ctx.params.passwd;
            let username = ctx.params.username;

            auth.login(username, password)
                .then((userData) => {
                    auth.saveSession(userData);
                    notify.showInfo(`User ${username} has logged in successfully!`)
                    ctx.redirect('#home');
                })
                .catch(notify.handleError);
        })

        this.get('#logout', (ctx) => {

            if (!auth.isAuth()) {
                notify.showError('User not authenticated !');
                return;
            }

            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    notify.showInfo('Logout successfull!');
                    ctx.redirect('#home');
                })
                .catch(notify.handleError);

        })

        this.get('#list/ads', (ctx) => {


            if (!auth.isAuth()) {
                notify.showError('User not authenticated !');
                return;
            }

            ctx.isAuth = auth.isAuth();
            ctx.username = sessionStorage.getItem('username');

            ads.getAllAds()
                .then((allAds) => {

                    allAds.forEach((add, i) => {
                        add.isAuthor = sessionStorage.getItem('userId') === add._acl.creator;
                    })

                    ctx.adsList = allAds;

                    ctx.loadPartials({
                        header: '../templates/common/header.hbs',
                        ad: '../templates/ads/ad.hbs',
                        footer: '../templates/common/footer.hbs',
                    }).then(function () {
                        this.partial('../templates/ads/viewAds.hbs');
                    })

                });

        })

        this.get('#ad/delete/:adId', (ctx) => {


            if (!auth.isAuth()) {
                notify.showError('User not authenticated !');
                return;
            }

            let adId = ctx.params.adId;
            console.log(ctx)
            ads.deleteAdd(adId)
                .then((ad, i) => {
                    notify.showInfo(`Add ${ad.title} was removed !`);
                    ctx.redirect('#home');
                }).catch(notify.handleError);
        })

        this.get('#create/ad', (ctx) => {

            if (!auth.isAuth()) {
                notify.showError('User not authenticated !');
                return;
            }


            ctx.isAuth = auth.isAuth();
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                footer: '../templates/common/footer.hbs',
            }).then(function () {
                this.partial('../templates/ads/createAd.hbs');
            })

        })

        this.post('#create/ad', (ctx) => {

            if (!auth.isAuth()) {
                notify.showError('User not authenticated !');
                return;
            }

            let title = ctx.params.title;
            let description = ctx.params.description;
            let date = ctx.params.datePublished;
            let price = ctx.params.price;
            let publisher = sessionStorage.getItem('username');
            let views = 0;
            let linkToImage = ctx.params.imageUrl;

            ads.createAd(publisher, title, description, date, price, views, linkToImage)
                .then(function () {
                    notify.showInfo('Ad Created successfully !');
                    ctx.redirect('#list/ads');
                });

        })

        this.get('#ad/edit/:adId', (ctx) => {

            if (!auth.isAuth()) {
                notify.showError('User not authenticated !');
                return;
            }

            let adId = ctx.params.adId;
            
            ads.getAddById(adId)
                .then((ad) => {

                    ctx.ad = ad;
                    ctx.isAuth = auth.isAuth();
                    ctx.username = sessionStorage.getItem('username');
                    ctx.loadPartials({
                        header: '../templates/common/header.hbs',
                        footer: '../templates/common/footer.hbs',
                    }).then(function () {
                        this.partial('../templates/ads/editAd.hbs');
                    })

                })

        })

        this.post('#ad/edit/:adId', (ctx) => {

            if (!auth.isAuth()) {
                notify.showError('User not authenticated !');
                return;
            }

            let title = ctx.params.title;
            let description = ctx.params.description;
            let date = ctx.params.datePublished;
            let price = ctx.params.price;
            let publisher = sessionStorage.getItem('username');
            let views = ctx.params.views;
            let linkToImage = ctx.params.imageUrl;
            let adId = ctx.params.adId;

            ads.editAd(adId, publisher, title, description, date, price, views, linkToImage)
                .then(function () {
                    notify.showInfo('Ad Updated successfully !');
                    ctx.redirect('#list/ads');
                });

        })

        this.get('#ad/details/:adId', (ctx) => {

            if(!auth.isAuth())
            {
                notify.showError('User not authenticated !');
                return;
            }

            let adId = ctx.params.adId;

            ads.getAddById(adId)
                .then((ad) => {                    
                    
                    let viewsNumber = Number(ad.views);
                    viewsNumber++;

                    ads.editAd(adId, ad.publisher, ad.title, ad.description, ad.date, ad.price, viewsNumber, ad.linkToImage)
                    .then(function(){

                        ctx.ad = ad;

                        ctx.isAuth = auth.isAuth();
                        ctx.username = sessionStorage.getItem('username');
                        
                        ctx.loadPartials({
                            header: '../templates/common/header.hbs',
                            footer: '../templates/common/footer.hbs',
                        })
                        .then(function(){
                            this.partial('../templates/ads/adDetails.hbs')
                        })
                    })
                    .catch(notify.handleError)
                    })

           

        })

    });


    app.run();
});
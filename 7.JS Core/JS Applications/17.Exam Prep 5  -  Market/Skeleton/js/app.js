$(() => {
    const app = Sammy('main', function () {
        this.use('Handlebars', 'hbs');

        this.get('/market.html', (ctx) => {

            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                nonRegisteredHomeView: './templates/views/nonRegisteredHomeView.hbs',
                viewUserHome: '../templates/views/viewUserHome.hbs'
            }).then(function () {
                this.partial('../templates/views/homeView.hbs');
            }).catch(notify.handleError);
        })

        this.get('#/home', (ctx) => {

            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                nonRegisteredHomeView: './templates/views/nonRegisteredHomeView.hbs',
                viewUserHome: '../templates/views/viewUserHome.hbs'
            }).then(function () {
                this.partial('../templates/views/homeView.hbs');
            })
        })

        this.get('#/login', (ctx) => {

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: '../templates/forms/loginForm.hbs'
            }).then(function () {
                this.partial('../templates/views/loginView.hbs');
            })
        })

        this.post('#/login', (ctx) => {
            let username = ctx.params.username;
            let password = ctx.params.password;

            auth.login(username, password)

                .then((userData) => {
                    auth.saveSession(userData);
                    notify.showInfo('Login successful.');
                    ctx.redirect('#/home');
                })
                .catch(notify.handleError);

        })

        this.get('#/register', (ctx) => {

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                registerForm: '../templates/forms/registerForm.hbs'
            }).then(function () {
                this.partial('../templates/views/registerView.hbs');
            })
        })

        this.post('#/register', (ctx) => {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let name = ctx.params.name;

            let cart = {};
            auth.register(username, password, name, cart)
                .then((userData) => {
                    auth.saveSession(userData);
                    notify.showInfo('User registration successful!');
                    ctx.redirect('#/home');
                })
                .catch(notify.handleError);
        });

        this.get('#/logout', (ctx) => {
            auth.logout()
                .then(() => {
                    sessionStorage.clear();
                    ctx.redirect('#/home');
                })
                .catch(notify.handleError);
        });

        this.get('#/shop', (ctx) => {

            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            productsService.getAllProducts()
                .then((products) => {

                    ctx.products = products;
                    products.forEach((p, i) => {

                        p.price = p.price.toFixed(2).toString();
                        ctx.product = p;
                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            product: './templates/views/product.hbs',
                        }).then(function () {
                            this.partial('../templates/views/shopView.hbs');
                        })

                    });
                });
        });

        this.get('#/cart', (ctx) => {

            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            auth.getCurrentUser()
                .then((user) => {

                    let productsInCart = user.cart;
                    ctx.productsInCart = productsInCart;

                    for (p in productsInCart) {

                        let product = productsInCart[p];

                        product.totalPrice = (product.product.price * product.quantity).toFixed(2).toString();


                        ctx.productInCart = product;
                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            productInCart: './templates/views/productInCart.hbs',
                        }).then(function () {
                            this.partial('../templates/views/cartView.hbs');
                        })

                    }

                    if (productsInCart === undefined || productsInCart === null) {
                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            productInCart: './templates/views/productInCart.hbs',
                        }).then(function () {
                            this.partial('../templates/views/cartView.hbs');
                        })

                    }

                });
        });

        this.get('#/purchase/:id', (ctx) => {

            let productId = ctx.params.id;

            auth.getCurrentUser()
                .then((user) => {

                    if (user.cart === undefined)
                        user.cart = {};

                    let productExists = user.cart[productId] !== undefined;

                    if (productExists) {

                        let currentQuantity = user.cart[productId].quantity;
                        currentQuantity = Number(currentQuantity) + 1;
                        user.cart[productId].quantity = currentQuantity.toString();

                        let cart = user.cart;

                        let id = sessionStorage.getItem('userId');
                        let username = sessionStorage.getItem('username');
                        let name = sessionStorage.getItem('name');


                        productsService.updateUser(id, username, name, cart)
                            .then(() => {
                                notify.showInfo('Product purchased.');
                                ctx.redirect('#/cart');
                            })
                            .catch(notify.handleError);

                    }
                    else {

                        productsService.getProduct(productId)
                            .then((product) => {

                                auth.getCurrentUser()
                                    .then((user) => {


                                        if (user.cart === undefined)
                                            user.cart = {};

                                        let cart = user.cart;

                                        cart[productId] = {
                                            "quantity": "1",
                                            "product": product
                                        };

                                        let id = sessionStorage.getItem('userId');
                                        let username = sessionStorage.getItem('username');
                                        let name = sessionStorage.getItem('name');


                                        productsService.updateUser(id, username, name, cart)
                                            .then(() => {
                                                notify.showInfo('Product purchased.');
                                                ctx.redirect('#/cart');
                                            })
                                            .catch(notify.handleError);

                                    })

                            });




                    }
                })
        });

        this.get('#/discart/:id', (ctx) => {

            let productId = ctx.params.id;

            auth.getCurrentUser()
                .then((user) => {

                    let currentProduct = user.cart[productId];
                    let cart = user.cart;

                    delete user.cart[productId];

                    let id = sessionStorage.getItem('userId');
                    let username = sessionStorage.getItem('username');
                    let name = sessionStorage.getItem('name');

                    productsService.updateUser(id, username, name, cart)
                        .then(() => {
                            notify.showInfo('Product purchased.');
                            ctx.redirect('#/cart');
                        })
                        .catch(notify.handleError);
                })
                .then(function () {
                    ctx.redirect('#/cart');
                })
        });

    });

    app.run();
});
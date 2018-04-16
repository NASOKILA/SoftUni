$(() => {
    const app = Sammy('#main', function () {
        
        this.use('Handlebars', 'hbs');

        //register
        this.get('skeleton.html', (ctx) => {

            ctx.loadPartials({
                header: './templtes/common/header.hbs',
                footer: './templtes/common/footer.hbs',
                registerForm: './templtes/forms/registerForm.hbs',
            }).then(function () {
                this.partial('./templtes/registerView.hbs');
            })
        });

        this.post('skeleton.html', (ctx) => {

            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPass = ctx.params.repeatPass;

            if (!/^[A-Za-z]{5,}$/.test(username)) {
                notify.showError('Username should be at least 3 characters long and contain only english alphabet letters');
            } else if (password === '' || repeatPass == '') {
                notify.showError('Password fiels should not be empty.');
            } else if (repeatPass !== password) {
                notify.showError('Passwords must match!');
            } else {
                auth.register(username, password)
                    .then((userData) => {
                        auth.saveSession(userData);
                        notify.showInfo('User registration successful!');
                        ctx.redirect('#/home');
                    })
                    .catch(notify.handleError);
            }
        });

        this.get('#/login', (ctx) => {

            ctx.loadPartials({
                header: './templtes/common/header.hbs',
                footer: './templtes/common/footer.hbs',
                loginForm: './templtes/forms/loginForm.hbs',
            }).then(function () {
                this.partial('./templtes/loginView.hbs');
            })
        });

        this.post('#/login', (ctx) => {

            let username = ctx.params.username;
            let password = ctx.params.password;

            if (username === '' || password === '') {
                notify.showError('All fields should be non-empty!');
            } else {
                auth.login(username, password)
                    .then((userData) => {
                        auth.saveSession(userData);
                        notify.showInfo('Login successful.');
                        ctx.redirect('#/home');
                    })
                    .catch(notify.handleError);
            }
        });

        this.get('#/logout', (ctx) => {
            auth.logout()
                .then(() => {
                    sessionStorage.clear();
                    notify.showInfo('Login successful.');
                    ctx.redirect('Chirper-Resources/skeleton.html');
                })
                .catch(notify.handleError);
        });
        
        this.get('#/home', (ctx) => {

            //get user chirpsCount

            ctx.username = sessionStorage.getItem('username');

            chirpService.getChirpCount(sessionStorage.getItem('username'))
                .then((count) => {

                    ctx.chirpCount = count.length;

                    //get following users

                    auth.getCurrentUser()
                        .then((user) => {

                            //IMPORTANT GET FOLLOWING USERS
                            let following = user.subscriptions.toString();
                            following = following.replace('[', '');
                            following = following.replace(']', '');
                            let followingArray = following.toString().split(',')


                            ctx.chirpCount = followingArray.length;
                            ctx.followingUsers = followingArray.length ;

                            let followers = 0;

                            //get followers
                            //get all users subscriptions
                            //count how many have our name in it !!!
                            auth.getAllUsers()
                                .then((users) => {
                                    users.forEach((user, i) => {

                                        if (user.subscriptions !== undefined) {

                                            if (user.subscriptions.includes(sessionStorage.getItem('username')))
                                                followers++;
                                        }
                                    })

                                    ctx.followers = followers;

                                    //get subscriptions
                                    //get all subscriptions chirps
                                    //get current user subscriptions

                                    auth.getCurrentUser()
                                        .then((user) => {

                                            let subscriptions = user.subscriptions;

                                            let subs = JSON.stringify(JSON.parse(subscriptions))
                                     
                                            chirpService.getAllSubscriptionsChirps(subs)
                                                .then((chirps) => {

                                                    ctx.hasNoChirps = chirps.length === 0;
                                                    ctx.subscribersChirps = chirps
                                                  
                                                    
                                                    chirps.forEach((c, i) => {


                                                        let idOfuserr = "";

                                                        auth.getAllUsers()
                                                            .then((allUsers) => {
                                                                let uuu = allUsers.filter(u => u.username === c.author)[0];
                                                                idOfuserr = uuu._id;

                                                                console.log(idOfuserr)

                                                                c.idOfUser = idOfuserr;
                                                                c.time = calcTime(c._kmd.ect)




                                                                ctx.loadPartials({
                                                                    header: './templtes/common/header.hbs',
                                                                    footer: './templtes/common/footer.hbs',
                                                                    navigation: './templtes/common/navigation.hbs',
                                                                    chirp: './templtes/chirps/chirp.hbs',
                                                                    submitChirpForm: './templtes/forms/submitChirpForm.hbs'
                                                                }).then(function () {
                                                                    this.partial('./templtes/feedView.hbs');
                                                                })
                                                            })




                                                    })

                                                    
                                                })

                                        });



                                })



                        })

                })

        });

        this.post('#/home', (ctx) => {

            let chirp = ctx.params.text;
            let author = sessionStorage.getItem('username');

            if (chirp === '') {
                notify.showError('Chirp should not be empty!')
                return;
            }

            if (chirp.split('').length > 150) {
                notify.showError('Chirp should not contain more than 150 symbols !')
                return;
            }

            chirpService.createChirp(author, chirp)
                .then(function () {
                    notify.showInfo('Chirp published.');
                    ctx.redirect('#/me');
                })
        })

        this.get('#/me', (ctx) => {

            let username = sessionStorage.getItem('username');
            ctx.username = username;
            //get all chirps of  current user
            chirpService.getUserChirps(username)
                .then((chirps) => {

                    ctx.hasChirps = chirps.length > 0;
                    ctx.chirps = chirps



                    chirps.forEach(c => {
                        c.time = calcTime(c._kmd.ect)
                        c.isAuthor = username === c.author;
                        //c.idOfUser = sessionStorage.getItem('userId');
                    });

                    //get user chirp count
                    chirpService.getChirpCount(sessionStorage.getItem('username'))
                        .then((count) => {

                            ctx.chirpsCount = count.length;


                            auth.getCurrentUser()
                                .then((user) => {

                                    //IMPORTANT GET FOLLOWING USERS
                                    let following = user.subscriptions.toString();
                                    following = following.replace('[', '');
                                    following = following.replace(']', '');
                                    let followingArray = following.toString().split(',')


                                    ctx.chirpCount = followingArray.length;
                                    ctx.followingUsers = followingArray.length
                                    


                                    //getFollowers

                                    let followers = 0;

                                    //get followers
                                    //get all users subscriptions
                                    //count how many have our name in it !!!
                                    auth.getAllUsers()
                                        .then((users) => {

                                            users.forEach((user, i) => {

                                                if (user.subscriptions !== undefined) {

                                                    if (user.subscriptions.includes(sessionStorage.getItem('username')))
                                                        followers++;

                                                }
                                            })

                                            ctx.followers = followers;
                                            

                                            //get subscriptions
                                            //get all subscriptions chirps
                                            //get current user subscriptions

                                            auth.getCurrentUser()
                                                .then((user) => {

                                                    
                                                    ctx.loadPartials({
                                                        header: './templtes/common/header.hbs',
                                                        footer: './templtes/common/footer.hbs',
                                                        navigation: './templtes/common/navigation.hbs',
                                                        meChirp: './templtes/chirps/meChirp.hbs',
                                                        submitChirpForm: './templtes/forms/submitChirpForm.hbs'
                                                    }).then(function () {
                                                        this.partial('./templtes/meView.hbs');
                                                    })
                                                   });



                                        })




                                })

                        })





                })



        })

        this.get('#/delete/:chirpId', (ctx) => {

            let chirpId = ctx.params.chirpId;

            chirpService.deleteChirp(chirpId)
                .then(function () {
                    notify.showInfo('Chirp deleted.');
                    ctx.redirect('#/me');
                })

        })

        this.get('#/discover', (ctx) => {

            let username = sessionStorage.getItem('username');

            auth.getAllUsers()
                .then((users) => {

                    //vzimame vsichki bez nashiq user
                    let filteredUsers = users.filter(u => u.username !== username);

                    
                    
                    filteredUsers.forEach((user, i) => {

                        //get subscriptions
                        //get all people who have our name in their subscribers, thouse are our followers


                        let followers = 0;

                        auth.getAllUsers()
                            .then((allUsers) => {

                                allUsers.forEach((u, i) => {
                                    if (u.subscriptions !== undefined) {

                                        if (u.subscriptions.includes(user.username))
                                            followers++;

                                    }
                                })

                                user.followersCount = followers;
                                

                                

                            })

                            

                    })

                    ctx.users = filteredUsers.sort((a,b) => 
                    {
                        //NE MI DAVA DA DOSTUPA .followersCount
                        console.log(a.username)
                        console.log(b.followersCount)
                        
                        if(Number(a.followersCount) < Number(b.followersCount))
                            return a - b;

                            
                        if(Number(a.followersCount) > Number(b.followersCount))
                        return a + b;
                    })

                            console.log(filteredUsers)

                            ctx.loadPartials({
                                header: './templtes/common/header.hbs',
                                footer: './templtes/common/footer.hbs',
                                navigation: './templtes/common/navigation.hbs',
                                chirp: './templtes/chirps/chirp.hbs',
                                user: './templtes/user.hbs',
                            }).then(function () {



                                setTimeout(() => {
                                    this.partial('./templtes/discoverView.hbs');
                                }, 3000)

                            })

                });

        })

        this.get('#/userProfile/:userId', (ctx) => {

            let userId = ctx.params.userId;

            auth.getUserById(userId)
                .then((user) => {


                    ctx.user = user;
                    console.log(user.username)
                    
                    ctx.idOfUser = user._id;

                    //IMPORTANT GET FOLLOWING USERS
                    let following = user.subscriptions.toString();
                    following = following.replace('[', '');
                    following = following.replace(']', '');
                    let followingArray = following.toString().split(',')


                    ctx.chirpCount = followingArray.length;
                    ctx.followingUsers = followingArray.length - 1


                    let followers = 0;

                    //get followers
                    //get all users subscriptions
                    //count how many have our name in it !!!
                    auth.getAllUsers()
                        .then((users) => {

                            users.forEach((u, i) => {

                                if (u.subscriptions !== undefined) {

                                    if (u.subscriptions.includes(user.username))
                                        followers++
                                }
                            })

                            ctx.followers = followers;


                            //get chirps count of user
                            chirpService.getChirpCount(user.username)
                                .then((count) => {

                                    ctx.chirpsCount = count.length;

                                    //get chirps of user
                                    chirpService.getUserChirps(user.username)
                                        .then((chirps) => {


                                            ctx.chirps = chirps

                                            chirps.forEach((c, i) => {
                                                c.time = calcTime(c._kmd.ect);
                                                c.idOfUser = userId
                                            })


                                            auth.getCurrentUser()
                                                .then((currentUser) => {

                                                    //to finish
                                                    if (currentUser.subscriptions.includes(user.username))
                                                        ctx.following = true;
                                                    else
                                                        ctx.following = false;

                                                })


                                            ctx.loadPartials({
                                                header: './templtes/common/header.hbs',
                                                footer: './templtes/common/footer.hbs',
                                                navigation: './templtes/common/navigation.hbs',
                                                chirp: './templtes/chirps/chirp.hbs',
                                                submitChirpForm: './templtes/forms/submitChirpForm.hbs',
                                            }).then(function () {
                                                this.partial('./templtes/profileView.hbs');
                                            })

                                        });
                                });

                        });

                })




        })

        this.get('#/follow/:userId', (ctx) => {

            let userId = ctx.params.userId;
            console.log(userId);


            ctx.redirect();
        })

        this.get('#unfollow/:userId', (ctx) => {
            let userId = ctx.params.userId;
            console.log(userId);

            ctx.redirect();
        })

        function calcTime(dateIsoFormat) {
            let diff = new Date - (new Date(dateIsoFormat));
            diff = Math.floor(diff / 60000);
            if (diff < 1) return 'less than a minute';
            if (diff < 60) return diff + ' minute' + pluralize(diff);
            diff = Math.floor(diff / 60);
            if (diff < 24) return diff + ' hour' + pluralize(diff);
            diff = Math.floor(diff / 24);
            if (diff < 30) return diff + ' day' + pluralize(diff);
            diff = Math.floor(diff / 30);
            if (diff < 12) return diff + ' month' + pluralize(diff);
            diff = Math.floor(diff / 12);
            return diff + ' year' + pluralize(diff);
            function pluralize(value) {
                if (value !== 1) return 's';
                else return '';
            }
        }



    });

    app.run();
});
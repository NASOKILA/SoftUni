$(() => {
    const app = Sammy('main', function () {

        this.use('Handlebars', 'hbs');

        this.get('messages.html', (ctx) => {
            ctx.redirect('#/home');
        });

        this.get('#/home', (ctx) => {

            ctx.isAuth = auth.isAuth();
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                homeView: './templates/views/homeView.hbs'
            }).then(function () {
                this.partial('./templates/views/welcomeView.hbs');
            })
        });

        this.get('#/login', (ctx) => {

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: '../templates/forms/loginForm.hbs'
            }).then(function () {
                this.partial('./templates/views/loginView.hbs');
            })
        });

        this.get('#/register', (ctx) => {

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                registerForm: '../templates/forms/registerForm.hbs'
            }).then(function () {
                this.partial('./templates/views/registerView.hbs');
            })
        });

        this.post('#/register', (ctx) => {

            let username = ctx.params.username;
            let password = ctx.params.password;
            let name = ctx.params.name;
            auth.register(username, password, name)
                .then((userData) => {
                    auth.saveSession(userData);
                    notify.showInfo('User registration successful!');
                    ctx.redirect('#/home');
                })
                .catch(notify.handleError);
        });

        this.post('#/login', (ctx) => {

            let username = ctx.params.username;
            let password = ctx.params.password;

            auth.login(username, password)
                .then((userData) => {
                    auth.saveSession(userData);
                    notify.showInfo('User login successful!');
                    ctx.redirect('#/home');
                })
                .catch(notify.handleError);
        });

        this.get('#/logout', (ctx) => {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    notify.showInfo('User logout successful!');
                    ctx.redirect('#/home');
                }).catch(notify.handleError);
        });

        this.get('#/my/messages', (ctx) => {    

            ctx.noMessages = false;
            ctx.username = sessionStorage.getItem('username');            
            ctx.isAuth = auth.isAuth();

            messageService.listMessagesByRecipient()
                .then((messages) => {

                    ctx.messages = messages;


                    messages.forEach(message => {

                        let name = messageService.formatSender(message.sender_name, message.sender_username);
                        let date = messageService.formatDate(message._kmd.ect);

                        ctx.message = message;
                        message.name = name;
                        message.date = date;
                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            message: './templates/messages/message.hbs'
                        }).then(function () {
                            this.partial('./templates/messages/myMessagesView.hbs');
                        })

                    })


                    if (messages.length < 1) {

                        ctx.noMessages = true;

                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            message: './templates/messages/message.hbs'
                        }).then(function () {
                            this.partial('./templates/messages/myMessagesView.hbs');
                        })
                    }
                })



        });

        this.get('#/sent/messages', (ctx) => {

            ctx.isAuth = auth.isAuth();
            ctx.username = sessionStorage.getItem('username');
            ctx.noMessages = false;

            messageService.listMessagesBySender()
                .then((messages) => {

                    ctx.noMessages = false;
                    ctx.messages = messages;

                    messages.forEach(message => {

                        let name = messageService.formatSender(message.sender_name, message.sender_username);
                        let date = messageService.formatDate(message._kmd.ect);

                        ctx.sentMessage = message;
                        message.dateSent = date;

                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            sentMessage: './templates/messages/sentMessage.hbs'
                        }).then(function () {
                            this.partial('./templates/messages/sentMessagesView.hbs');
                        })

                    })

                    if (messages.length < 1) {
                        ctx.noMessages = true;

                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            sentMessage: './templates/messages/sentMessage.hbs'
                        }).then(function () {
                            this.partial('./templates/messages/sentMessagesView.hbs');
                        })
                    }
                })

        });

        this.get('#/delete/message/:id', (ctx) => {

            let messageId = ctx.params.id;

            messageService.deleteMessage(messageId)
                .then(() => {
                    notify.showInfo('Message deleted.');
                    ctx.redirect('#/sent/messages');
                })
                .catch(notify.handleError);

        });

        this.get('#/send/message', (ctx) => {

            ctx.username = sessionStorage.getItem('username');            
            ctx.isAuth = auth.isAuth();

            auth.getAllUsers()
                .then((users) => {

                    ctx.users = users;
                    users.forEach(user => {
                        ctx.option = `<option value="${user.username}">${user.name}</option>`;
                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            option: './templates/option.hbs'
                        }).then(function () {
                            this.partial('./templates/views/sendMessage.hbs');
                        })
                    });
                });




        });

        this.post('#/send/message', (ctx) => {


            let recipient_username = ctx.params.recipient;
            let text = ctx.params.text;

            let sender_name = sessionStorage.getItem('name');
            let sender_username = sessionStorage.getItem('username');

            messageService.sendMessage(sender_username, sender_name, recipient_username, text)
                .then(function (res) {

                    notify.showInfo('Message sent.');
                    ctx.redirect('#/sent/messages');
                })
                .catch(notify.handleError);

        });

    });

    app.run();
});
const userController = require('./../controllers/user');
const homeController = require('./../controllers/home');
const articleController = require('./../controllers/article');



// TUK SHTE RABOTIM  shte kazvame ako usera otide na edi koe si da se
// izpulni dadena funkciq ot daden kontroler



module.exports = (app) => {
    app.get('/', homeController.index);

    app.get('/user/register', userController.registerGet);
    app.post('/user/register', userController.registerPost);

    app.get('/user/login', userController.loginGet);
    app.post('/user/login', userController.loginPost);

    app.get('/user/logout', userController.logout);
    app.get('/article/create', articleController.createGet); // tova vizualizira formata
    app.post('/article/create', articleController.createPost); // tazi funkciq zapisva dannite koito usera e izpratil

    app.get('/article/details/:id', articleController.detailsGet);
    // IDto e parametur koito se opisva v URLla kato :id

    app.get('/article/edit/:id', articleController.editGet);
    app.post('/article/edit/:id', articleController.editPost);

    app.get('/article/delete/:id', articleController.deleteGet);
    app.post('/article/delete/:id', articleController.deletePost);


};


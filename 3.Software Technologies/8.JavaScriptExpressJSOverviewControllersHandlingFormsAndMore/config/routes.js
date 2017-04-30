const homeController = require('./../controllers/home');

module.exports = (app) => {
    app.get('/', homeController.indexGet);

    /* tuk nie kazvame : kogato usera ni potursi localhost:3000/  koeto e
    * ekvivalentno na home, nie da mu dadem  funkciqta indexGet ot homeController !s
    * mojem da dobavqme kolkoto si iskame */

   app.get('/about', homeController.aboutGet);

    app.post('/', homeController.indexPost);
    // kogato nqkoi ni izprati danni na "/" da se izpulni funkciqta indexPost V homeControllera !
};

// s this nie rabotim s tekushtiq obekt i v sluchaq mu zakachame stoinosti

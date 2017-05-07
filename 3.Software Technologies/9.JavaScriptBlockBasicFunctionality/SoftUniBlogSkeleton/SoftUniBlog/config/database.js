const mongoose = require('mongoose');
mongoose.Promise = global.Promise;

module.exports = (config) => {
    mongoose.connect(config.connectionString);

    let database = mongoose.connection;
    database.once('open', (error) => {
        if (error) {
            console.log(error);
            return;
        }

        console.log('MongoDB ready!')
    });

    require('./../models/Article');
    // PO TOZI NACHIN NIE KAZVAME NA NASHIQ PROEKT CHE IMAME MODELI USER I ARTIKUL !!!

    require('./../models/Role').initialize();
    // DOBQVAME SI KKUVTO I NOV MODE DA IMAME, BAZATA TRQBVA DA ZNAE !

    require('./../models/User').initialize();

};

// Tova e kod koito startira bazata vruzva ni kum mongo s modula mongoose !
// i kazva che ako ima nqkakva greshka da consolo.logne error

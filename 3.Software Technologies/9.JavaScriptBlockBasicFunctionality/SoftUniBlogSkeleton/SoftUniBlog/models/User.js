
const mongoose = require('mongoose');
const encryption = require('./../utilities/encryption');

// Za da kajem che vseki user moje da ima i artikuli shte ni trqbvaObjectID ot mongoose !
const ObjectId = mongoose.Schema.Types.ObjectId;

const Role = mongoose.model('Role');
//Vzehme rolqta

let userSchema = mongoose.Schema(
    {
        email: {type: String, required: true, unique: true},
        passwordHash: {type: String, required: true},
        fullName: {type: String, required: true},
        salt: {type: String, required: true},
        article : [{type:ObjectId, ref:'Article'}],
        roles : [{type:ObjectId, ref:'Role'}],
        /* mojemda imame mnogo artikuli zatova ni trqbva kolekciq ot ID-ta toest masiv
            po default mu kazvame da e prazen masiv ZA DA NE NI DAVA UNDEFINED.

            STARITE USERI NE RABOTQT S TAKAVA SHEMA, TE SI IMAT SOBSTVENA, ZATOVA NIE TRQBVA
            DA KAJEM CHE STARITE USERI I TE MOGAT DA IMAT MASIV OT ARTIKULI.
            AKO NE GO NAPRAVIM STARITE USERI NQMA DA IMAT ARTIKULI A NOVITE SHTE IMAT !
            TOVA SE NARICHA MIGRACIQ T.E. UPDATE NA STARATA BAZA.
            Daden nie sledniq kod : db.getCollection('users').update({articles: {$exists: false}}, { $set: {articles:
            []}}, {multi: true})    koito nie trqbva da slojim v shela na blog bazata koqto suzdadohme
            v Robomongo !!! Sleg kato go runnem shte vidim che userite imat i artikuli !!!

        */

        /*Opisali sme artikulite no po nikakuv nachin ne referirame kum tqh.
          t.e. trqbva da slojim ref i Object id mojem da go iznesem v kontanta.
          Sled koeto trqbva da napravim sushtoto za Roles*/

    }
);

userSchema.method ({
   authenticate: function (password) {
       let inputPasswordHash = encryption.hashPassword(password, this.salt);
       let isSamePasswordHash = inputPasswordHash === this.passwordHash;

       return isSamePasswordHash;
   }
});


userSchema.method({


    isAuthor: function(article){
        //SUZDAVAME FUNKCIQ ZA PROVERKA DALI EDIN AVTOR E AVTOR NA DADEN ARTIKUL
        /*
        MNOGO VAJNO: AKO IZPOLZVAME ARROW FUNKCII T.E. SUS =>   this NQMA DA
        BUDE KATO V NORMALNITE FUNKCII
        */
        if(!article){
            return false;  // ako nqmam artikul da vurne false
        }
        let id = article.author;

        return this.id == id;
        // PROVERQVAME DALI IDto NA AVTORA E SUSHTOTO NA TOVA NA USERA, AKO E TAKA ZNACHI
        // da vurne isAuthoe
    },
    isInRole: function(roleName){
        return role.findOne({name:roleName}).then(role => {
            if(!role){
                return false;
            }

            let isInRole = this.roles.indexOf(role.id) !== -1;
            return isInRole;
        })
    }

});




const User = mongoose.model('User', userSchema);

module.exports = User;


// TOVA E EDIN MODEL ZA USERI, TOI KAZVA CHE EDIN USER TRQBVA DA IMA
// Ime parola, emeil i dr...

// NIE SHTE SI SUZDAEM NOV KOITO DA KAZVA KAKVO TRQBVA DA SUDURJA EDIN ARTIKUL !



// ILI SI NORMALEN USER ILI SI ADMIN
module.exports.initialize = () => {

    let email = 'admin@mysite.com'; // takuv shte bude imeilut na admina
    User.findOne({email: email}).then( admin => {// opitai se da namerish takuv user s takuv imeil


            if (admin) {
                return; // ako imam gotov admin prosto returni !!!
            }


        //ako ne go namerish go dobavi


        // trqbva da namerim rolqta na tozi admin, VZIMAME Q OTGORE S Role
        //NAMIRAME ROLQTA POLZVAIKI IMETO KOETO TRQBVA DA E ADMIN
        Role.findOne({name: 'Admin'}).then(role => {

            if(!role){
                return; // ako nqma rolq da returne
            }


        // slednite dva reda sa za heshirane na parolata :
            let salt = encryption.generateSalt();
            let passwordHash = encryption.hashPassword('admin123456', salt);


            let adminUser = {
                // Tozi user trqbva da pretstavlqva obekt koito ima sushtite danni kato usera malki razliki
                email:email,
                fullName:'Admin',
                articles:[],
                roles: [role.id], // ZAKACHAME IDto NA ADMINSKATA ROLQ
                salt:salt,
                passwordHash: passwordHash
            };

            User.create(adminUser).then(user => {
                role.users.push(user.id);

                role.save();
            });

            // NAI NAKRAQ SUZDAVAME ADMIN USERA !
            // trqbva v database.js da uvedomim che imame Admin DAVAME initialize na Users.js
            // USERA TRQBVA DA PAZI ROLQTA A ROLQTA TRQBVA DA PAZI USERA !!!

        });
        }
    )
};




















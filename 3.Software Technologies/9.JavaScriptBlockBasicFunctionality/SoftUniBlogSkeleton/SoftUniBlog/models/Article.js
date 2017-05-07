const mongoose = require("mongoose");
const ObjectId = mongoose.Schema.Types.ObjectId;

// za typa na avtora avtora ni trqbva objectID !

// tova e nashiq model za artikulite

let articleSchema = mongoose.Schema({

    title : {type: String, required: true},
    content : {type: String, required: true},
    author : {type: ObjectId, ref: 'User', required: true},

    /*Za avtora nie trqbva da zapazvame IDto na usera koito e sazdal
      tekushtata artikul. Avtora na artikula trqbva da e user
      Veche sum kazal za avtora che shte ima ID sega trqbva da kajem che
      trqbva da e user sus : ref: 'User' i nakraq mu kazvame che e
      zaduljitelen. */

    date : {type: Date, default: Date.now()},
    // datata ne e zaduljitelno no sme kazali che ako ne mu dadem data
    // po default da zapazi segashnata data.

    // TOVA SHETE E ZA SNIMKATA
    imagePath: {type:String}, // TRQBVA DA SETNEM PUTQ V KONTROLERA
});
// VAJNO: TRQBVA DA OTIDEM V user.js I DA KAJEM CHE VSEKI USER MOJE DA IMA I ARTIKUL !!!

// Sega trqbva da kajem na bazata da ima takava kolekciq t.e. nashiq model:

const Article = mongoose.model('Article', articleSchema);
// kazavme mu da suzdade model Article koito da ima tazi shema !
// SEGA NIE MOJEM LESNO DA RABOTIM S TEKUSHTIQ ARTIKUL, t.e. MOJEM DA DOBAVQME, TRIEM, UPDATEVAME I DR




module.exports = Article;
// tuk kazvame che nqkoi moje da go izpolzva vuv vunshniq svqt t.e. izvun tozi fail.


// NAJRAQ NIE TRQBVA DA KAJEM NA NASHIQ PROEKT CHE SUSHTESTVUVA TOZI FAIL KOITO SEGA NAPRAVIHME
// TOVA TRQBVA DA GO NAPISHEM V database.js !!!!!





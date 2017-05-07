
const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.Types.ObjectId;


function initializeRole(roleName){
// ZA DA NE KOPIRAME KOD PRAVIM TAZI FUNKCIQ ZASHTOTO LOGIKATA E SUSHTATA
    // Opitva da nameri edna rolq s ime User i ako q nqma q suzdava
    let roleData = {name: roleName};
    Role.findOne(roleData).then(role => {
        if(!role){
            Role.create(roleData); // ako nqma dakava rolq q suzdava!
        }
    });
}

let roleSchema = mongoose.Schema({

    // vsqka edna rolq shte si ima ime i user
    name : {type: String, required: true, unique:true},
    // unique oznachava che ne moje da imame dva puti edna i sushta rolq, ADMIN PRIMERNO !
    users : [{type: ObjectId, ref: 'User'}],
//userite sa masiv ot object ID referiran ot user
});

// sega trqbva da suzdadem model

const Role = mongoose.model('Role', roleSchema);
module.exports = Role; // exportvame go

// OTIVAME V database.js da kajem na bazata che moje da izvikva tova neshto kakto kazahme i za drugite !
// TRQBVA DA KAJEM USERITE KOI ROLI IMAT ZATOVA OTIVAME V Users.js



/*
 Ima edin initialize metod na modul exports koito turi rolq s ime Uer i ako q nqma toi q suzdava.
 Suthtoto neshto go pravi i sus Admin !!!
 */




module.exports.initialize = () => {
    initializeRole('User');

    // Sega pravim sushtoto za Admin
    initializeRole('Admin');

    // MOJE I DA SE NAPRAVI SUS FUNKCIQ ZASHTOTO TAKA KOPIRAME KOD KOETO E LOSHA PRAKTIKA
};
// za da trugne obache nie trqbva nqkade da q izvikame i tova stava v database.js sled zarejdaneto na role

// V Uesr.js vuv Funkciqta registerPost TRQBVA DA UPDATENEM  usera da ima  ROLE










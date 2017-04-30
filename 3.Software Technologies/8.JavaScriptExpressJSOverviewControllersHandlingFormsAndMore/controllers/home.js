

const Calculator = require('../models/Calculator');
// KAZVAME MU EDNA PAPKA NAZAT POSLE MODELS I CALCULATOR !!!

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    aboutGet: (req, res) => {
        res.render('home/about', {
            name: 'Atanas Kambitov',
            phone: '0889037703'
        });
    },
    indexPost: (req, res) => {
        // kato request poluchavame tova koeto napishem kato left i right operand i operator
        // TRQBVA DA IZVADIM CALCULATOR OT TQLOTO NA REQUESTA

        let calculatorParams = req.body['calculator'];
        // req.body ni dava avtomatichno izpratenite danni ot usera
        // SEGA MOJEM SPOKOINO DA RABOTIM S nashite operandi  chrez calculatorParameters


        //TRQBVA DA REQUAIRNEM NASHIQ KALKULATOR NAI OTGORE !

        // KAZVAME SI NOV KALKULATOR I MU PODAVAME PARAMETRITE VZETI S req.body:
        // VAJNO E DA MU PODADEM PARAMETRITE V TAKUV RED V KAKUVTO SME GI NAPISALI VUV FUNKCIQTA
        // I E VAJNO DA GI PREVURNEM VUV CHISLA ZA DA MOJEM DA GI PRESMETNEM !
        let calculator = new Calculator(Number(calculatorParams.leftOperand),
            calculatorParams.operator, Number(calculatorParams.rightOperand));

        let result = calculator.caculateResult();
        /*RABOTATA NA KONTROLERA E DA VZEME PODADENITE DANNI OT USERA,
        DA GI OBRABOTI I DA VURNE NQKAKUV HTML !!!

        */


         res.render('home/index', {
             // za da zapazi oprandite trqbva da mu gi vurnem
             'calculator':calculator,
             'result':result}); // i nakraq mu vrushtame i rezultata v poleto s ime 'result'
    }
};

/*
  vijdame che indexGet e funkciq koqto renderira nqkakuv hbs fail koito se
  namira v home i se kazva index, tozi fail obache ne vrushta nishto t.e.
  toi e prazen.
*/










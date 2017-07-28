
const Article = require("mongoose").model("Article");
// Tova ni e za da mojem da pipame direktno vuv artikulite

    // TRQBVA DA OTPECHATAME 6 ARTIKULA NA GLAVNATA STRANICA ZA DADENIQ AVTOR !
module.exports = {
  index: (req, res) => {

      Article.find({}).limit(60).populate('author').then(articles => {

          res.render('home/index', {
              articles
              // podavame samite artikuli kato danni za da se vizualizirat
          });
      });
      //find() namira dadeno neshto po Conditions v sluchaq shte tursim artikuli
      //Ako go ostavim bez usloviq shte ni nameri vsichki artikuli i shte gi vurne, samo pishem {} vutre
      // slagame .limit(6) koeto e za da vzima maksimum 6 artikula v sluchai che imame poveche

      //za da namerim vsichki useri ili avtori vmesto da obhojdame vsichki artikuli s for cikul
      //polzvame edin metod populate() koito ni go pravi avtomatichno
      // .populate('author')    mojem i da gi sortirame sus sort()



  }
};
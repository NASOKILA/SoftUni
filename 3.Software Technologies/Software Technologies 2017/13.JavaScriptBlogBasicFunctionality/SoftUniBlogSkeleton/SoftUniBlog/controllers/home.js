

const mongoose = require('mongoose');
const Article = mongoose.models.Article;

// LETS LIST ALL ARTICLES
module.exports = {
  index: (req, res) => {

      //We get only the first 6 articles
      //put all of the author’s information in the article property
      //Nakraq renderirame viewto kato mu podavame vzetite artikuli!

      Article.find({}).limit(6).populate('author').then(articles => {
         res.render('home/index', {articles: articles});
      });

      /*
      Populate example: If we have an article with an “author”
      property  = “a3fvce4GtT” (which is the author’s ID) and we
      say that we want to populate that property, MongoDB will
      search in the User model for a user with the same ID and
      simply attach all the information it has for that user
      */
  }
};




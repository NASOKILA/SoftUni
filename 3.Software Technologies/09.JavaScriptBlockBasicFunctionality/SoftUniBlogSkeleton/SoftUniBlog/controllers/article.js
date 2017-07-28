const Article = require('mongoose').model('Article');
const encryption = require('./../utilities/encryption');


// Tova e nashiq kontroler za artikulite


function validateArticle(articleArgs, req){

    let errorMsn = '';
    //TUK TRQBVA DA NAPRAVIM 3 PROVERKI: DALI USERA E LOGNAT, DALI PISHE TITLE, I DALI PISHE CONTENT !
    if(!req.isAuthenticated()){
        errorMsn = 'You should be logged in before you make articles';
    }
    else if(!articleArgs.title){   // moje i taka : req.body.title
        errorMsn = 'Invalid title!';
    }
    else if(!articleArgs.content){   // moje i taka : req.body.content
        errorMsn = 'Invalid content!';
    }
    return  errorMsn;
}




module.exports = {
    // S tova nie kazvame che nashiq kontroler e suvkupnost ot tezi raboti vutre v obekta !

    createGet: (req, res) => {
        res.render('article/create')

    },
    createPost : (req, res) => {

            let articleArgs = req.body;// sus req.body vzimame samo title i content ot artikula

            let errorMsn = validateArticle(articleArgs,req);

        if(errorMsn) // ili prosto if(errorMsn !== '')
        {
            res.render('article/create', {
                error: errorMsn
            });
            return; // ako imame greshka da sprem do tuk ili mojem da slojim else dolo !
        }

        // AKO NQMAM GRESHKA TOZI IF NQMA DA SE IZPULNI I PROGRAMATA SHTE PRODULJI NADOLO


        //SEGA TRQBVA DA VZEMEM TEKUSHTIQ USER A TOVA VECHE NI E NAPRAVENO GOTOVO:

         // ot bazata znaem che userite imat i IDta





        // TUK SHTE OBRABOTVAME IMAGES
        let image = req.files.image;

        // PRAVIM SI PAPKA IMAGES V public , koqto shte e dostupna za vseki user
        if(image){
            let filenameAndExtention = req.files.image.name; // VZIMAME IMETO NA IMAGE


            //Uslovieto e : DA SLOJIM RANDOM CHARACTERS MEJDU IMETO I EXTENtiONA NA SNIMKATA,
            // TOVA E S CEL AKO NQKOI KACHI EDNA I SUSHTA SNIMKA DA IMA RANDOM KARAKTERI ZA DA BUDE RAZLICHNA  SNIMKATA!

            // VSICHKO PREDI POSLEDNATA TOCHKA E filenme A VS SLED NEQ E EXTENTION-a
            // ZATOVA TRQBVA DA NAMERIM PURVO POSLEDNATA TOCHKA.

            let filename = filenameAndExtention.substring(0,
                filenameAndExtention.lastIndexOf('.'));

            //SEGA NI TRQBVA I ETENTIONA:  SLAGAME + 1 za da vzemem samo  jpg  vmesto  .jpg
            let extention = filenameAndExtention.substring(filenameAndExtention.lastIndexOf('.') + 1)

            // ZA DA GENERIRAME RANDOM CHARACTERS MOJEM DA POLZVAME kakto salt v user.js NO PURVO TRQBVA DA
            // VKLUCHIM  encription NAI OTGORE !
            let randomCharachters = encryption
                .generateSalt()
                .substring(0, 5)
                .replace(/\//, 'x'); // repleisvame vsichki sinvoli '/' sus 'x' samoche go pravim sus regex
            // vzehme samo purvite 5 znaka sus substring() i s replace repleisvame sinvola / za da ne ni precaka
            // NO TRQBVA DA GO NAPRAVIM SUS regex ZASHTOTO INACHE REPLEISVA SAMO PURVIQ SRESHNAT SINVOL !

            let finalFileName = `${filename}_${randomCharachters}.${extention}`;
            console.log(finalFileName);


            image.mv(`C:/Users/nasko/Desktop/JavaScriptBlockBasicFunctionality/SoftUniBlogSkeleton/SoftUniBlog/public/images/${finalFileName}`,
                err=>{
                // s funkciqta MV() zapisvame v survera za da e dostupno za vseki potrebitel

               if(err) {
                   console.log(err.message); // ako ima greshka da mi q pokaje
               }
            });


            //SHTE SETNEM PUTQ NA SNIMKATA:
            // slagame q tuk zashtoto ako nqmame snimka da ne zapisva nishto v bazata
            // ako ako slojim imagePath otvun, i ako nqma snimka shte zapishe v bazata imagePath = undefined !!!!
            articleArgs.imagePath = `/images/${finalFileName}` ;


        }




          articleArgs.author = req.user.id; // kazvame che avtora ni e idto na usera
        // sega article ima i avtor

        // sega nie trqbva da zapishem dannite, tova stava s dva metoda!
        //S METOD create NIE ZAOISVAME DANNITE V BAZATA A METOD then IZPULNQVAME
        // NESHTO AKO TE SA ZAPISANI !  ZA DA GI ZAPISHEM NI TRQBVA MODELA Article



        //Article si go requirvame ot gore da e ravno na modela ni
        //V create podavame tova koeto iskame da zapishem v bazata
        Article.create(articleArgs).then(article => { // poluchihme article
            req.user.article.push(article.id); // sega na usera zapisvame artikula
            req.user.save(err => {
                if(err) // ako imam greshka
                {
                    res.redirect('/', {
                        error:err.massage
                    });
                }
                else // ako nqmam greshka moga da redirektna kum nachalnata stranica
                {
                    res.redirect('/');
                }
            })

        })
    },

    detailsGet: (req, res) => {

        // Vzimame IDto ot URLla
        let id = req.params.id;  // opisali sme che shte se kazva : id

        Article.findById(id).populate('author').then(article => {

            // TESTVAHME VSICHKO, AKO NE SI AVTORA NA STATIQTA NE MOJESH DA Q EDITVASH
            // ILI DA Q TRIESH !!!


            res.render('article/details',article);
        });

        // findById(id) namirame po id to
        // ako izpolzvame findOne() shte nameri samo purviq koito otgovarq na dadeniq kondition
    },

    editGet: (req, res) => {
        let id = req.params.id;
        Article.findById(id).then(article => {

            if((req.user === undefined) || !req.user.isAuthor(article) || !req.user.isInRole('Admin')){ // AKO NQMAM USER ILI AKO LOGNATIQ USER NE E AVTOR NA TOZI ARTIKUL
                res.render('home/index', { // SHTE GO REDIREKTNEM KUM MAIN S DADENOTO DOLO SUOBSHTENIE !
                    error:'You cannot edit this article!'
                });
                return;
            }

            res.render('article/edit',article);
        });

    },

    editPost: (req, res) => {
        let id = req.params.id;
        let articleArgs = req.body;

        let errorMsn = validateArticle(articleArgs,req);

        if(errorMsn) // ako imam greshka
        { // da ni vurne sushtoto view samoche s tazi greshka
            res.render('article/edit', {error:errorMsn});

        }
        else {
            Article.update({_id: id, author: req.user.id}, {
                $set: {
                    title: articleArgs.title,
                    content: articleArgs.content
                }
            }).then(err => {
                res.redirect(`/article/details/${id}`);
                //redirektvame kum konkretniq artikul
            })
        }
            /*
             update iziskva purvo condotion, v sluchaq iskame idto da e tova koeto e na
             usera,  vtoroto neshto e kakvo da napravim s tozi update, t.e. nie mu kazvame
             da ni setne title i content
             */
    },

    deleteGet: (req, res) => {
        let id = req.params.id;

        Article.findById(id).then(article => {
            res.render('article/delete', article)
        });
    },


    deletePost: (req, res) => {
        let id = req.params.id;

          Article.findByIdAndRemove(id).then(article => {
                // kazvame da go nameri, iztrie no da ni go dade sled tova za da rabotim s nego
            //TRQBVA DA VLEZEM V USERITE I DA IZTRIEM TOCHNO TOZI ARTIKUL!!!S

              let index = req.user.article.indexOf(article.id); // namerihme indexa na tozi artikul
              req.user.article.splice(index, 1); // sus solice triem index samo edin put
              req.user.save(err => {    // TRQBVA DA GO SEIVNEM T.E. ZAPISVAME USERA V BAZATA
                if(err)
                {
                    // ako ima greshka da q vizualiziram
                    res.redirect('/', {error:err.message});
                }
                else
                {
                    //ako nqma greshka da se vurna na glavnata str
                    res.redirect('/');
                }
              });

          });
            // obache nali znaem che  v article pazim koi e avtora i v
            // avtorite pazim koi sa tehnite artikuli t.e. trqbva v users.js
            //da kajem che mahame daden artikul !!!!!!

        }

        /*
        TRQBVA DA IMAME ADMINI I NORMALNI USERI
        USERITE NE TRQBVA DA EDITVAT ARTIKULI KOITO NE SA TEHNI.

          SHTE SUZDADEM NOV MODEL S IME Role.js
          */



};


// kogato nqkoi potursi article/create da mu vurnem hbs failut s ime create
// koito suzdadohme v papkata article koqto suzdadohme v papkata views !!!










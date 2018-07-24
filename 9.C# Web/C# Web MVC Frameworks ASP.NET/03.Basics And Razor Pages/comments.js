
/*
    Razor pages:
        Mnogo sa lesni.

    V ASP.MVC Framework Routing:
        Polzvat se Middlewares koito izvikvat .Next() metoda inache ni vrushtat v nachalnata stranica.
        Moje da imame nqkolko middlewari koito da proverqvat razlichni neshta.
        I vseki edin moje da izbira dali da ni vrushta v nachaloto, na predishniq middleware ili da produljim napred.
    
        Mojem da polzvame Default Routing koeto e :
            /Controller/Action/?OptionalId

        No ot Configure metoda v services mojem da si setnem routinga da raboti po razlichen nachin, primerno:
            /Controller/?OptionalId

        //We can add a new route like this
                routes.MapRoute(
                    name: "orders",
                    template: "Orders/{orderId}",
                    defaults : new { controller = "Orders", action = "Details" });


        VAJNOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            NA VSEKI ACTION V DADEN KONTROLER MOJEM DA ZAKAHCIM ROUTE SUS ATTRIBUTA Route:
            PRIMERNO: [Route("/")]

        VTORIQ NACHIN VECHE GO VIDQHME I TOI E SUS app.UseMvc() VUV Configure metoda SUS 
        vsichkite routove v metoda.



//We can change the route of a given action
        //We can have many routs for on action
        [Route("Home/ContactNasko")]
        [Route("Home/NaskoContact")]
        [Route("Home/ContactNaskoContact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }



        VAJNOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Ne mojem da imame edin rout na dva aktiona, dava ni Internal Server Error.
            No mojem da gi razdelim sus HttpGet i HttPost 


        VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!
            Mojem da imame i [Route("Home")] na samiq kontroller i polse
                Route("Index") na samiq action BEZ DA SLAGAME "/" PREDI ILI SLED TQH
                OBACHE AKO SLOJIM "/" ZNACHI DVATA ROUTA NE SE KOMBINIRAT POMEJDU SI

        
        VAJNO E DA ZAPOMNIM CHE AKO POLZVAME "/" SAMIQ ROUTING REAIGIRA RAZLICHNO.

*/


/*
    Ako iskame da polzvame Statichni failove mojemd da napishem v Config metoda:
        app.UseStaticFiles();

    Ako iskam az da si dobavqm dopulnitelni statichni failove v saita.
        Trqbva da gi opishem, koit path koi fail da otvori 
        sus new staticFileOptions().
    
    Primer:
        app.UseStaticFiles(new StaticFileOptions() {
            RequestPath = "",
            // . . .
        });
    
*/







/*
    Razor:
        Pozvolqva ni da pishem C# v samoto View koeto e .cshtml fail.
        I tozi C# kod  generira HTML ili JavaScript kod.

        MOJEM DA PODAVAME DANNI KUM ViewTo CHREZ:
            01.ViewBag - Tova e kato rechnik, polzvame stoinost ako imame takuv kuch,
            
            02.ViewData - klucha e string s valueto e stoinostta koqto mojem i da kastnem,
            
            03.Model - Tova koeto polzvame kato  @Model TypePassed  katogo podavame ot kontrollera
                this.View(model:SomeThing);  Moje edno View da nqma Model no e hubavo da gi slagame.  


        @*Razor Comments*@


        VAJNOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Trqbva da imame @page NA PURVIQ RED NA STRANICATA INACHE NQMA DA RABOTI.
            Taka kazvame che tova e samostoqtelna stranica.

        VAJNOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Mojem da si inject-nem samiq DB kontext v samoto view sus
                @Inject BooksDbConetxt



        MNOGO CHESTO NI TRQBVAT NQKOOLKO MODELA V EDNO VIEW ZATOVA RAZDELQME SAMOTO VIEW
        NA NQKOLKO PARTIAL VIEWTA I NA TQH SLAGAME OTDELNI MODELI.



        TAKA SLAGAME LINK KUM DRUGA STRANICA.
        <a asp-page="Pricavy">Privacy</a>
*/






/*
    MVVM:
        Model - Durji dannite,
        View - Vizualizaciqtata na samata stranica,
        ViewModel - Sedi mejdu Viewto i Modela i vruzkata e dvuposochna, 
            ima metodi v nego, samoche ne e tolkova umno kato Controllera. 
            Celta e sa se prenasqt i obrabotvat danni ot modela kum viewto i da 
            se BINDVAT t.e. da idvat veche promeneni.
*/

















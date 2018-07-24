
/*
    Blazor:
        Polzva se C# Razor za da se suzdade stranica, ne e slojno.

    Shte razgledame:
        Razor Pages - zashtoto e po lesno
        MVVM - Model View ViewModel
        Lifecicle - ,
        Databinding and Validations
        Configuracii
    
        

    Links and Handling:
        Linkovete  ZADULJITELNO se validirat.


    Tag Helper:
        <a asp-page="About">ASP.NET Helper Link to About Page</a>



    MVVM : 
        Tuk zad vseko edno view si ima model v koito imame logika, mnogo e prosto klikni na strelkichkata na samoto view i shte
        vidish .cs faila koito e samiqt model.
        
        Samiqt klas nasledqva OnPage klasa i si ima OnGet() Metod koito se izpulnqva predi da se pokaje viewto,
        tozi metod moje da bude void koito avtomatichno vrushta samoto view ili moje da bude ot tip IActionResult i da 
        Redirectva kum drugi stranici i da pravi mnogo drugi neshta.


        Imame i onPost() onPut() onPatch() i drugi vgradeni metodi za razlichnite zaqvki.
        
    


    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Razgledai faila index.cshtml.cs za da razberesh za formite v MVVM, tozi fail e VIEWMODEL na View-to Index.cshtml

        Ako vidim nqkude {id} znachi e PARAMETUR


    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Pregledai failovete Login.cshtml Login.cs  Details.cshtml Details.cs 
        STAWA VUPROS ZA FORMI

    
    
    Page Lifcicle methods: 
        Narichat se i Filters (filteri)
        Tova sa metodi koito se izpulnqvat v dadeno vreme i izvurshvat operacii,
        Davat i informaciq za stranicata.

        Mojem i sami da si suzdavame filtri.

        Ima nqkolko vida filtri:
            OnPageHandlerSelected - Vinagi se izpulnqva purvi
            OnPageHandlerExecuting - Izvurshva se predi izpulnqvaneto 
            OnPageHandlerExecuted - Izvurshva se sled izpulnqvaneto  

        //Vgradenite handlerri trqbva da budat prezapisani za da rabotim s tqh
        
        
        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            //This Hander is alwais first

            ViewData["LinkMessage"] += "OnPageSelected " + context.HandlerMethod.Name;
            base.OnPageHandlerSelected(context);
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //This Hander runs BEFORE OnGet(){ } method

            ViewData["LinkMessage"] += "OnPageExecuting " + context.HandlerMethod.Name;
            base.OnPageHandlerExecuting(context);
        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            //This Hander runs AFTER OnGet(){ } method

            ViewData["LinkMessage"] += "OnPageExecuted " + context.HandlerMethod.Name;
            base.OnPageHandlerExecuted(context);
        }

         TOVA E ZA FILTRITE !!!
*/


/*
        Boxing and Unboxing:

            //Boxing is when we turn something into object
            //Every datatype inherits the "object" class
            
            int a = 5;
            object aObj = (object)a;

            //Unboxing is the opposite, turning something from an object to a dataType
            int b = (int)aObj - 1;
*/





/*
    Web Forms Apps: 
        They work only on Windows and on .NET Framework (NOT .NET CORE)
        

        PAK VURVI NA MVVM, Ima klasove zad samite viewta koito obrabotvat logikata.
        
        VAJNOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!
            Polzva neshto podobno na Razor: 
                <%: ... %>  vmesto  @...

            CodeBehind="NameOfFail" e atributa v koito opisvame koi fail raboti zad tova dadeno view 

            TUK NQMAME index.cshtml A IMAME Default.aspx FAIL

            

        Tuk Layout.cshtml e Site.Master faila
        Global.asax e faila koito puska aplikaciqta 

        Mojem da dobavqme kontroli ot toolsbox.
        Tuk ne mojem da pravim unit testove i tova e losho.

        Tova e po star framework no e dosta razvit i mnogo kompanii go polzvat.
*/






/*
        Summary:
            Pisane i vruzvane na stranici v "Pages"
            Handleri,
            Formi,
            Validacii,
            LifeCicle (Filters) Build In Handlers,
            Boxing Unboxing,
            WEB FORMS 


            VSICHKO KOTO GO NAUCHIHME V PAGES E EDNAKVO I V MVC.
            SAMO Filtrite i Handlerite v MVC sa MNOGO PO SLOJNI 
*/








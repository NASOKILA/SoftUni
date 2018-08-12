
/*
    Modules and Routing:
        Faila app.modules.ts e mqstoto v koeto si importvame 
        novi vuncshni neshta.

        S MODULITE MOJEM DA SI ORGANIZIRAME PRILOJENIRETO PO DOBRE.


        Mojem da si razcepim prilojenieto na mnogo moduli.
        I shared module, module polzvan ot vseki.

        creating modules:
            importvame NgModule ot @angular/core
            i CommonModule ot @angular/common

            i go slagame v imports masiva

            exports: []  e masiv v koito slagame komponenti
                koito mogat da budat polzvani izvun tozi.

        VAJNOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!
        Vseki komponent moje da si ima moudle kakto e app.module.ts
*/


/*
    Router:
        Routera se griji da podmenq contenta na HTML stranicata v zavisimost na koi link kliknem.
        A samiq Html e edin i sush, tova e SPA (Single Page Application), stranicata se zarejda samo vednuj

        Kak se polzva ?
            01.Slagame <base href="/"> tag vuv index.html faila

            02.Trbva ni navigaciq v koqto vmesto da pishem href="", pishem routerLink=""

            03.Pishem <router-outlet></router-outlet> nakraq v app.component.html   

            04.Za da importnem routera ni trqbva klas koito da sudurja routovete app.routes.module.ts

  V samiq fails predi da go exportnem          
//we have to mark this as a module with the routes
@NgModule({
    imports:[RouterModule.forRoot(routes)]
})

        05.Importvame klasa v app.modules.ts


//we can use the route to create routes in the following way
    { path: 'courses', children : [
        { path: 'details', component: AboutComponent }, //courses/details
        { path: 'create', component: AboutComponent }, //courses/create
        { path: 'edit/:id', component: AboutComponent }, //courses/edit/5
    ] },



*/  


/*
    Parametri kak da vadim ot URL-i ?
        Trqbva ni ´ActivatedRoute´ koeto trqbva da importnem
        v komponent v koito shte go polzvame :
        
        constructor(private route : ActivatedRoute) {}
        i posle v NgOnInit(){} mojem da gi printirame

        ngOnInit() {
            this.route.params
            .subscribe(params => console.log(params));
        }

*/



/*
    Guards:
        Gardovete sa neshtoto koeto zashtitava daden route da e 
        primerno samo za lognati ili authentikirani useri.

        NE E TRUDNO.

        Suzdavae se servise koito da implementira daden klas, registrirame go
        i sme gotovi.

        Mogat da se slagat v Shared Papka.

        Klasa predstavlqva neshto podobno:
       
import { CanActivate } from "@angular/router";
import { Injectable } from "@angular/core";

//class implements CanActivate
//we mark this function as injectable
@Injectable()
export class AuthenticatedRoute implements CanActivate {

    
    canActivate(){

        //logic goes here

        //if(this.userService.isAuthenticated) {return true;}else {return false;}
        return false;
    }
}

        Sled tova otivame v app.routes.modules.ts i slagame tozi route 
        v canActivate: [] masiv

*/




/*
Shte govorim za Forms, Directives and Pipes:

    Forms:
        Ima dva vida formi v Angular:
            01.Teplate Driven Forms - logikata se pishe v samiq template na frontenda
            02.Reactive Forms - logikata e v backenda

        V razlichni situacii se polzvat razlichni formi, ne e hubavo da polzvame razlichni formi v 
        edin i susht proekt.


    Teplate Driven Forms:
        Mojem da polzvame TWO WAY BINDING kato polzvame "ngModel"

        VAJNOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Edin input trqbva zaduljitelno da ima "name" i ngModel za two way binding
            Trqbva da importnem v app.module.ts import { FormsModule } from '@angular/forms';
            A za reactive-forms se importva import { ReactiveFormsModule } from '@angular/forms';

        butonite vinagi sa ot type="submit" a na formata slagame #form="ngForm". 

        Validation messagite sa mi divove koito se pokazvat samo kogato nehto ne e nared
    
        Mojem da gi napravim hidden i da gi pokazvame kogato neshto stane.
        Mojem da polzvame *ngIf="form.invalid"  t.e. da se pokazva kogato formata ne e validna.
        Mojem da imame messagi za razlichni validacii koito da sa divove nestnati v drugi divove.
        Mojem da slagame 'disabled' na butoni i ako ne e validna formata da ne mojem da gi klikame.

        Ima oshte VIJ template-driven-forms Komponenta !!!!!!!!!!
        


    Reactive Forms:
        Ne sa tolkova slojni.
        S tqh mojem da pravim asinhromna validaciq.
        Asinhromnata validaciq se dopitva do bazata.
        A za reactive-forms se importva import { ReactiveFormsModule } from '@angular/forms';

        Polzvame i import { FormGroup, FormControl } from '@angular/forms'; ovutre v dadeniq komponent.
        Tuk imame poveche svoboda s validaciite.

        Ako napravim FormGroup sus FormBuilder shte mojem da slojim masiv ot validacii za vseki input
        izpolzvaiki klasa 'Validators' vuv FormControl().


        Kak stawa ?
        Importvame si : 
            import { FormGroup, FormControlName } from '@angular/forms';
            Imame i formControlName za vseki input field v html faila
            i submit buton s.l. na formata ima me ngSubmit event koito otiva v dadena funkciq : 
                (ngSubmit)="log()"
            Ima oshte VIJ reactive-forms Komponenta !!!!!!!!!!

    Directives:
        Veche znaem kakvo e, tova sa *ngIf=""  i  *ngFor="" 
        Tezi direktivi manipulirat dom elementite.


        
    Pipes:
        Tova sa build In neshta v Angular kato "uppercase", "lowercase", "camelcase" ...
        Mojem da si pishem nashi si pipove.




    VAJNOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!
        Ako kahvame proekti v git vajno e da mahama node_modules papkata.
        Instalirane na bootstrap v angular proekt chrez konzolata:


    VAJNOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!
        Kak da se orientirame koe kude otiva v app.module.ts ?
        Vseki module se slaga v Imports: [],
        Vseki komponent, direktiva ili Pipe se slaga v Declarations: [],
        Vseki service se slaga v Providers: [],


*/
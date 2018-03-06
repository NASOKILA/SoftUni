
//TRQBVA DA INSTALIRAME NQKOLKO BIBLIOTEKI ZA DA TESTVAME V HTML KOD

//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!
//OTVARQME TERMINALA KATO ADMINISTRATOR ZASHTOTO AKO NQMAME PRAVA NISHTO NQMA DA NAPRAVIM 
//I PISHEM:
//npm install jsdom -g                     //TOVA E ZA 'jsdom' BIBLIOTEKATA
//npm install jsdom-global -g                     //TOVA E ZA 'jsdom-global' BIBLIOTEKATA

/*
    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        VSICHKI BIBLIOTEKI GLOBALNO INSTALIRANI SE SUHRANQVAT TUK: 
        C:\Users\user\AppData\Roaming\npm\node_modules
        Tam trqbva da imame BIBLIOTEKITE : 
            01.mocha, 
            02.chai, 
            03.jsdom,
            04.jsdom-global

*/ 
//Vzimame si expecta
let expect = require('chai').expect;

//VAJNOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//POSLEDOVATELNOSTTA PRI IZPISVANETO NA SLEDNITE TRI NESHTA E VAJNA
//PURVO: Tazi biblioteka Pozvolqva ni da si suzdavame virtualen HTML v testovete
const jsdom = require('jsdom-global');  //Shte mojem da dostupvame HTML-a chrez JQUERY-to

//VTORO: Vzimame si Jquery bibliotekata 
let $ = require('jquery'); 

//NAKRAQ: Vzimam si funkciqta koqto shte testvam
let nuke = require('../06. ArmageDOM');


//S beforeEach si suzdavame HTML predi vseki test

describe("function nuke", function () {
    beforeEach(() => {
        document.body.innerHTML =
            `<div id="target">
                <div class="nested target">
                    <p>This is some text</p>
                </div>
                <div class="target">
                    <p>Empty div</p>
                </div>
                <div class="inside">
                    <span class="nested">Some more text</span>
                    <span class="target">Some <span>more</span> text</span>
                </div>
            </div>`
    });

    before(()=>global.$ = $);
    it("should do nothing if selectors are equal", function () {
        let beforeNuke = $('body').html();
        nuke('#target', '#target');
        let afterNuke = $('body').html();
        expect(beforeNuke).to.equal(afterNuke);
    });

    it("should remove one span for ('.target', 'span')", function () {
        let initialTargetLength = $('.target').length;
        let initialSpanLength = $('span').length;
        let initialSpanTargetLength = $('.target').filter('span').length;
        if($('.target').filter('span').has('span')){
            initialSpanLength--;
        }
        nuke(".target", "span");
        expect($('.target').filter('span').length).to.be.equal(0);
        expect($('span').length).to.equal(initialSpanLength - initialSpanTargetLength);
        expect($('.target').length).to.equal(initialTargetLength - initialSpanTargetLength);
    });
    it("should remove two divs for ('div', '.target')", function () {
        let initialTargetLength = $('.target').length;
        let initialDivLength = $('div').length;
        let initialDivTargetLength = $('.target').filter('div').length;
        nuke('div', '.target');
        expect($('.target').filter('div').length).to.be.equal(0);
        expect($('div').length).to.equal(initialDivLength - initialDivTargetLength);
        expect($('.target').length).to.equal(initialTargetLength - initialDivTargetLength);
    });
    it("should remove one span for", function () {
        nuke('.nested', 'span');
        expect($('span.nested').length).to.be.equal(0);
    });
    it("should return the same html if one parameter is omitted", function () {
        let beforeNuke = $('body').html();
        nuke("div");
        let afterNuke = $('body').html();
        expect(beforeNuke).to.equal(afterNuke);
    });
    it("should return the same html if one parameter is omitted", function () {
        let beforeNuke = $('body').html();
        nuke("" ,"div");
        let afterNuke = $('body').html();
        expect(beforeNuke).to.equal(afterNuke);
    });
    it("should do nothing for non-existing selector", function () {
        let beforeNuke = $('body').html();
        nuke("#invalid", "section");
        let afterNuke = $('body').html();
        expect(beforeNuke).to.equal(afterNuke);
    });
});




/*
 IMPORTANT !!!!!!!!!!!
 WE CAN APPEND FUNCTIONS TO THE ROTOTYPE OT THINGS SO FOR
 EXAMPLE IF WE APPEND IT TO THE PROTOTYPE OF string WE
 WILL BE ABLE TO USE THIS FUNCTION FOR EVERY STRING WE CREATE
 */
String.prototype.try = function () {
    return (this + ' Appened to the string prototype')
};

console.log('hello'.try());



/*
* Stringovete v JS sa kato masivi samoche sa IMMUTABLE
* t.e. ne mogat da se promenqt vednuj suzdadeni.
*
* */

let str = 'Hello';
console.log(str[4]);

str[4] = 'O'; // ne mojem da go promenqme
console.log(str[4]);


console.log(str.length);

//mojem da gi obhojdame kato masivi s for of i for in

//nqmame reverse() no mojem da reversnem taka:

//str.split("").reverse().join("")

/*
* .indexOf() ni dava indexa
* .substr(5) reje i pokazva stringa ot 5tiq element natam.
* */
console.log(); console.log();

let str2 = 'My name is Atanas Kambitov';
console.log(str2.indexOf('Atanas'));

console.log(str2.substr(11));

console.log(str2.substr(11, 6)); // vrushta 6 sinvola ot 11tiq natam.

console.log(str2.substr(-2)); //vrushta vtoriq sinvol ot zad napred.

console.log();
//.substring(11, 15); shte pokaje ot 11tiq do 15tiq sinvol
console.log(str2.substring(11, 15));

//pri .substring() negativnite stoinosti se broqt kato 0.



console.log();

//.split() i .replace() gi znaem !!!
console.log(str2.split(' '));

console.log(str2.replace('name', 'brother'));//replace zamenq dumi!


//STRING SI OSTAVQ EDIN I SUSH, TOI E IMMUTABLE !!!



/*
* HTML escaping:
* Vmesto <, >, i drugi sinvoli po dobre da polzvame &lt; ,  &gt;  i dr.
* ZA DA IZBEGNEM NQKOI NA NI HAKNE TRQBVA DA SI ESKEIPVAME SINVOLITE.
*
*
* */


/*
* Regular epression.
*
* POLZVAME SAITA Regex 101
*
* [0-9] - namira vsichki cifri ot 0 do 9
* [A-Z][a-z] - namira vsichki bukvi i malki i glavni
*
*  +  ozn da nameri pone edno ili poveche
*  *  ozn che moje da vurne 0 ili poveche
*  ?  ozn che moje da vurne 0 ili 1
*
* /s+  -  ozn whitespace
* /S+  -  ozn vs koeto ne e whitespace();
*
*
* [0-9]{3,6}  -  vrushta tochen broi suvpadeniq ot 3 do 6 cifri.
*
*  /w  -  vsichki dumi i s malki i s golqmi bukvi
*  /W  -  obratnoto na gornoto
*
*  /d  -  vsichki chisla ot 0 do 9
*  /D  -  obratnoto na gornoto
*
*   ^  -  ozn nachalo na texta
*   $  -  ozn krai na texta
*   ZA TQH TRQBVA DA E PUSNATO Multyline !!!
*
*
* let patt = /^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]+$/;
*
*  patt.test(args) vrushta true ili false .
*
*
* .REPLACE () MOJE DA RABOTI SUS REGEX !!!
* kato matchvame neshto i go repleisnem.
*
*
*
* Mojem da splitvame po regex,
* VAJNO E DA SE POLZVAT ^ i $ i MULtiLINE ZA DA SE SELEKTIRA PRAVILNO
* V DADENA SITUACIQ.
*
* VAJNO!!!!!!!!!!!!!!!!!!!
*   LookAhead - Kogato iskame da imame neshto OTPRED na stringa obache da NE go machva !
*   Lookbehind - Kogato iskame da imame neshto ZAD stringa obache da NE go machva !
*
*   MOGAT DA BUDAT NEGATIVE ILI POSITIVE LookBehind i LookAhead
*       Negative - e kogato NE iskame da ima neshto otpred ili otzad na stringa !!!
*       Positive - e kogato iskame da ima neshto !!!!
*
*   SINTAXIS:
*       Slagat se otpred ili otzat na regexa:
*
*       LOOKAHEAD:
*           Positive:
*           ... (?=.)  -  iskame da ima tochka sled matchnatoto obache da ne se machva tochkata.
*
*           Negative:
*           ... (?!.)  -  NE iskame da ima tochka sled matchnatoto !
*
*       LOOKBEHIND:
*           Positive:
 *           (?= ) ...  -  Iskame da ima space predi matchnatoto bez speisa da bude matchnat.
 *
 *          Negative:
 *           (?= ) ...  -  NE Iskame da ima space predi matchnatoto !
 *
* */

/*
*   VAJNOOOOOOOOOOOOOO !!!!!!!!!!!!
*       V Javascript NQMA LookBehind !!!!!!!!!!!!!!!
*       Ne moje da go polzvame
* */


/*
*  WORD BOUNDRY:
*       Tova e \b  ... \b
*       Zagrajdame regexa sus \b i go pravi na duma.
*       MOJEM DA GO SLOJIM SAMO OTPRED ILI SAMO OTZAD, NE E NUJNO DA ZAGRAJDAME CELIQ REGEX
*       Za da se razbere po dobre trqbva da se testva v www.regex101.com
*
*
*
*   MOJEM DA REPLEISVAME STRINGOVE SUS REGEXI KATO IM
*   PODADAVAME FUNKCII ILI ARROW FUNKCII
*
*
*
* AKO ISKAME DINAMICHEN REGEX, t.e. SUS PROMENLIVI MOJEM
* DA POLZVAME PRIMERNO:
*/

console.log();

let text = 'iuawdiowanaw76wda56dwa4544wd9d9876wd767';
let numbers = 'd+';
let regex = new RegExp(`\\${numbers}`, 'g');
let matches = text.match(regex);
console.log(matches.join(" "));


/*
*
* VAJNO !!!!!!!!!!!!! :
*   str.match(regex);    VRUSHTA MASIV S MATHCOVETE
*   regex.test(str);     VRUSHTA true ili false
*
* REPLACE SUS FUNKCIQ !
*   str.replace(regex, function(){...})
*   Tova koeto vrushta funkciqta ni, se prilaga na vseki
*   element hvanat ot regexa
*
*
*
* SUMMARY:
*   01. .substr(startIndex, length) .substring(startIndex, endIndex)
*       .indexOf()   .trim()   .replace()
*   02. REGEXI:
*   03.
*   04.
*
*
*
*
* */












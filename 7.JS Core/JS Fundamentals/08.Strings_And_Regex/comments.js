
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
* */








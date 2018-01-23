



/*
*
* Shte razgledame obektite v JS, definiciq i izpolzvane
*
* Masivi i asociativni masivi
* pecialni obekti kato mapove i setove
* obekti i json
*
* klasa Map koito e kato diktionari v C# raboti sus key i value
* klasa Set koito e kato spisuk samoche bez povtarqshti se stoinosti.
*
*
* */

console.log();console.log('OBEKTI:');
let obj = {name:'Nasko', age:25};

//Mojem da dobavqme propertita i stoinosti taka :
obj['gender'] = 'Male';
obj.status = 'Single';

console.log(obj);

//.hasOwnProperty() proverqva dali daden obekt ima dadeno properti
console.log(obj.hasOwnProperty("age")); //vrushta true ili false

//Pri obektite for in cikula minava prez vsichki kluhove na obekta:
for(let key in obj)
    console.log(key);

//taka dostupvame stoinostite
for(let key in obj)
    console.log(obj[key]);

//Object.keys ni dava vsichki kluchove na podadeniq obekt
console.log(Object.keys(obj));

//V obekta ni mojem da imame i funkciq:
obj.add = function (a,b) {return a + b;};
console.log(obj.add(5,9));

//dobavqme funkciq koqto da vrushta godinite
obj.getAge = function () {return this.age;};
console.log(obj.getAge());



/*
* JSON znaem kakvo e !
*   Mojem da go prevrushtame v string i obratnoto,
*   mojem da prevrushtame string v JSON obekt.
*
*
* */

//JSON.stringify() pravi obekta na string
let strJSON = JSON.stringify(obj);
console.log(strJSON);

//JSON.parse go pravi ot strng na JSON obekt
let parsedObj = JSON.parse(strJSON);
console.log(parsedObj);


/*
*
* MOJEM da imame nestnti obekti t.e. obekt v nego masiv ot obekt v nego
* oshte obekti ili masivi ot obekti i taka na tatuka.
*
* */


//Mojem da triem ot obekt s 'delete';
console.log();
let person = {name:'Atanas',surename:'Kambitov', age:25};
console.log(person);

delete person['age']; // triem go s delete
console.log(person);  //sega go nqma


//VAJNO : RED NA OBEKTA
console.log();
let order = {'One':'First'};

order['Two'] = 'Second';
order['Three'] = 'Third';

//CHISLOVITE PROPERTITA SE SLAGAT NAI OTPRED PO GOLEMINA:
order[1] = 'Edno';
order[5] = 'Pet';
order[3] = 'Tri';
console.log(order);


//SORTIRANE NA OBEKT
//AKO ISKAME DA IMA NQKAKUV DRUG RED MOJEM DA SI GO SORTIRAME.



console.log();console.log();console.log('MAPOVE:');
/*
* Mapove:
*
* V JS nqmame klasove vsichko e obekt.
* V JS Mapovte sa kato rechnicite v C# sudurjat key i value pairs.
*
*
* */

//Deklaraciq na Map
let map = new Map();

//Sus .set() mu slagame stoinosti:
map.set('Asen', 26);
map.set('Atanas', 25);
map.set('Toni', 24);
map.set('Toni', 25);
//AKO KLUCHA GO IMA SHTE MU SE PREZAPISHE STOINOSTTA

//pokazvame celiq map
console.log(map);

// S .delete(Key) se trie :
map.delete('Atanas');

console.log(map); // Atanas veche go nqma

console.log();
//Mojem da iterirame vsichki stoinosti v tozi map.
for(let [k, v] of map)
    console.log(k + ' -> ' + v);

console.log();

//Taka vijdame map iteratora i vijdame vsichki vhodove na tozi map
console.log(map.entries());

console.log();
for(let kvp of map.entries())
    console.log(kvp);  // mojem i da fi foreachnem

console.log();
//.keys() ni vrushta samo kluchovete:
console.log(map.keys());

//.values() ni vruhta vsichki stoinosti ot nashiq map:
console.log(map.values());


//VAJNOOOOOOO !!!!!!!!!!!!!!!!
//[...map] go razcepva na masiv ot dva masiva, edin za kluchovete i
// edin za stoinostite
console.log();
console.log([...map]);


/*VAJNOOOOOOO !!!!!!!!!!!!!!!!
 *Mappa ne moje da se sortira, nachina po koito moje da se sortira e
 *
 *ZA DA GO SORTIRAME TRQBVA PURVO DA GO PREVURNEM V MASIV OT MASIVI!
 */

//Mojem da sortirame po nuleviq element t.e. po kluchovete.
//Ako iskame da e po stoinost trqbva da e po vtoriq
//element t.e. a[1] i b[1] !!!
console.log([...map].sort((a, b) => a[1] - b[1]));

//No tova ne sortira mapa a prosto vrushta nov masiv ot dvata masiva veche sortirani !
console.log(map);


//MAPPA NE MOJE DA SE STRINGOSVA
console.log(JSON.stringify(map)); //vrushta prazen obekt

//NO AKO GO PREVURNEM V MASIV SHTE STANE:
console.log(JSON.stringify([...map])); //sega veche stava

console.log(); console.log();console.log('SETOVE:');
/*
* Sets (Setove):
* Kato map bes values koito sudurja mnojestva koito ne se povtarqt.
* NE MOJEM DA DOBAVIM EDNA I SUSHTA STOINOST DVA PUTI.
* Kluchovete i stoinostite sa edno i sushto neshto v seta!!!
*
* */

//Definira se kato Map()
let names = new Set();
names.add('Nasko');
names.add('Asi');
names.add('Toni');

//NE MOJEM DA DPBAVIM EDNA I SUSHTA STOINOST DVA PUTI.
names.add('Nasko'); // ne ni hvurlq greshka a napravo si go skipva.

console.log(names);

//proverkite se pravqt taka:
console.log(names.has("Nasko"));
console.log(names.has("Nasko2"));

//Taka se triqt elementi
names.delete("Toni");
console.log(names);

//Kluchovete i stoinostite sa edno i sushto neshto v seta!!!
console.log([...names.keys()]);
console.log([...names.values()]);//vadi edno i sushto neshto !!!


//.entries() ni vrushta masiv ot masivi s edni i sushti kluchove i stoinosti:
console.log([...names.entries()]);




/*
*
* SUMMARY:
* Mapovete i Setovete rabotat malko po razlichno ot masivite i obektite
* Te izpolzvat specialni Funkcii.
*
* */


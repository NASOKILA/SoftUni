


/*
Matrici i masivi:

S Array.  imame dostup do neshtata v obekta Array

Tuk vsichko e obekt.


*/


//VAJNO !!!!:
//Ako imame mnogo golqm masiv mojem dakeshirame duljinata mu
//za da ne q vzimame vseki put pri iterirane na masiva

let bigArr = [1,2,3,4,5]; // Primerno ima 1 milion elementa
const length = bigArr.length; // slagame duljinata v constanta
for(let i = 0; i < length; i++){}


//Masivi, mojem da pravim kakvoto si iskame s tqh


let arr = [1, 2, 3, 4];

console.log(arr);
console.log(arr[0]);

console.dir(arr);
//v brawsera ni go pokazva kato tablichka s indexite i vsichko


arr[10] = true;
arr[8] = 'Nasko';
arr[9] = 5.67;
console.log(arr);


//push i pop dobavqt i mahat elementi
arr.push(33);
console.log(arr);

arr.pop();
console.log(arr);


console.log();

//shift() i unshift();
arr.shift(); //maha purviq element
console.log(arr);

console.log();

//ako iskame da zakachim masiv v masiv ako polzvame shift() shte
//go zakachi kato edin element
console.log(arr.shift([5,6,7]));

//ako li ne polzvame concat();
let arr2 = [5,6,7].concat(arr);
console.log(arr2);

console.log();

arr.unshift(555); //dobavq element na purvata poziciq
console.log(arr);

console.log();

//moje da sudurja i obekt
arr['naso'] = 'NASO';
console.log(arr);


console.log();

// .forEach() ni pozvolqva da rabotim s vsichki elementi.
console.log(); console.log();
arr.forEach(e => console.log(e));



//.join()
console.log(arr.join('-'));

console.log();

//JSON.stringify()  tova serializira obekta !!!
//tozi obekt sega moje da se prashta po mrejata.
let jsonArrInString = JSON.stringify(arr);
console.log(jsonArrInString);


console.log();
//JSON.Parse();  vzima string i go prevrushta obratno v masiv !!!
console.log(JSON.parse(jsonArrInString));


//.splice();  s tova mojem da vzimame ot masiva bez da go promenqme
//vrushta nov masiv;
let arr3 = arr.slice(7);
console.log(arr3);


//.splice() e sushtoto samoche modificira samiq masiv !!!
arr3.splice(2);
console.log(arr3);


console.log();console.log();console.log();

//.map(...)   prilaga se na masivi i vsichki elementi shte
//minat prez tazi funkciq i otivat v nov masiv.
//RABOTI KATO .Select();
let arrStr = ['10','20','30','40'];
let arrNum = arrStr.map(e => Number(e)); // prevrushtame gi vsichki ot stringove v nomera.
console.log(arrNum);


console.log();console.log();console.log();
// .sort();  Sortira masiv
let arr4 = [5,8,1,99,124,77];
console.log(arr4);
arr4 = arr4.sort((a, b) => (a - b));
console.log(arr4);


// .reduce();  tova e agregirashta funkciq, slaga se na masiv
// i e za vzimane na mnogo stoinosti i ot tqh da vzemem edna.
//POLZVA SE S KOMBINACIQ S .concat();

console.log();
console.log('Matrici:')
/*Kak se deklarira matrica:*/
let matrix =
    [[1,2,3,4,5],
    [6,7,8,9,10],
    [11,12,13,14,15],
    [16,17,18,19,20],
    [21,22,23,24,25]];

//kak se dostupvat elementi

console.log(matrix[2][2]);  // 13
console.log(matrix[3][4]);  // 20
console.log(matrix[4][2]);  // 23

console.log();

console.log('Printing a matrix :');
console.log(matrix.map(row => row.join(' ')).join('\n'));


/*Summery:
* 01.Arrays: push(), pop(), unshift(), shift(), rabota s tqh
* 02.Matricite sa masivi ot masivi,
*   kak da gi printirame, dostupvame i manipulirame.
* */


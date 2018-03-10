


//Vzime si expecta na Chai bibliotekata za da si testvame programata
let expect = require('chai').expect;


//Pravim si funkciika koqto da testvame:
//PO PRINCIP TRQBVA DA E V OTDELEN FAIL I DA Q EXPORTNEM I POSLE TUK DA SI Q REQUIRENEM V PROMENLIVA !!!
function sum(arr){
    let sum = 0;
    for(num of arr)
        sum += Number(num);

    return sum;
}



//tuk podavame ineto na funkciqta koqto shte testvame i posle druga 
//funkciq v koqto da si pravim testovete sus 'it' 
describe('Sum', function(){

    //tuk si pravim vsichki testcheta s koito iskame da testvame 'Group' funkciqta

    it('Should return 3 from [1, 2]', function(){
        //imame i to.be.empty()  , .toInclude() , .have. I MNOGO DRUGI, VIJ V SAITA NA 'Chai'.
        expect(sum([1,2])).to.be.equal(3);
    })
    
    it('Should return 1 from [1]', function(){
        expect(sum([1])).to.be.equal(1);
    })

    it('Should return 0 from []', function(){
        expect(sum([])).to.be.equal(0);
    })
    
    it('Should return 3 from [1.5, 2.5, -1]', function(){
        expect(sum([1.5, 2.5, -1])).to.be.equal(3);
    })
    
    //VAJNO !!!
    //shte go testvame sus neshto razlichno ot masiv s chisla i trqbva da vurne NaN
    //OBACHE V JS NaN e RAZLICHNO OT NaN ( Proveri go v konzolata ) ZATOVA PRAVIM FUNKCIQTA NA 
    //STRING SUS .toString() I PRAVIM NaN na 'NaN' I SHTE SE POLUHI. 
    it('Should return NaN from string', function(){

        //expect(sum('Invalid Input').toString()).to.be.equal('NaN');
        
        //STAWA I TAKA :
        expect(sum('Invalid Input')).to.be.NaN;
    })


})


//MOJEM DA GO TESTVAME V TERMINALA ILI V CMD-to KATO VLEZEM V PAPKATA KOQTO 
//SUDURJA test PAPKATA I PROSTO NAPISHEM 'mocha', SHTE NI POKAJE KOLKO TESTOVE SA 
//VQRNI I KOLKO NE.



















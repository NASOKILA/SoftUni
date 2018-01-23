
function modifyWorker(worker){

       if(worker['handsShaking'] === true) {

           console.log('to be modified');
           worker['bloodAlcoholLevel'] += 0.1 * worker['weight'] * worker['experience'];
           worker['handsShaking'] = false;
       }

       return(worker);
}

solve({ weight: 80,
    experience: 1,
    bloodAlcoholLevel: 0,
    handsShaking: true }
);

solve({ weight: 120,
    experience: 20,
    bloodAlcoholLevel: 200,
    handsShaking: true }
);











function solve(worker){

     if(worker.handsShaking === true)
     {
        let requiredAlcoholAmount = 0.1 * worker.experience * worker.weight;

        worker.bloodAlcoholLevel += requiredAlcoholAmount;
        worker.handsShaking = false;
     }
     return worker;
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
solve({ weight: 95,
    experience: 3,
    bloodAlcoholLevel: 0,
    handsShaking: false }
);









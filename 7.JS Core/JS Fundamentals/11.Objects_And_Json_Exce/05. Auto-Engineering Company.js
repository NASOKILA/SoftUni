

function solve(args) {

    let car = new Map();

    for(let row of args)
    {
        let elements = row.split(' | ');
        let brand = elements[0];
        let model = elements[1];
        let price = Number(elements[2]);

        let oldPrice = 0;

        let modelAndPrice = new Map();

        if(car.has(brand)) //ako veche q sudurja tazi kola
        {
            modelAndPrice = car.get(brand);

            //ako modela go ima mu vzimame cenata i q subirame s taq
            if(modelAndPrice.has(model))
            {
                oldPrice = modelAndPrice.get(model);
                price += oldPrice;
            }
                modelAndPrice.set(model, price);
        }
        else // ako ne se sudurja veche tozi kluch
            modelAndPrice.set(model, price);
        

        car.set(brand, modelAndPrice);
    }

    //Printirame:
    for(let c of car)
    {
        console.log(c[0])

        for(let e of c[1])
        {
            console.log(`###${e[0]} -> ${e[1]}`);
        }
    }

}
/*
solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);
*/


function s(args){

    let cars = new Map();
    for (const row of args) {
        
        let [car, model, count] = row.split(' | ');

        count = Number(count);
        let modelAndCount = new Map();

        let oldCount = 0;
        
        //ako taq kola se sudurja veche s toq model 
        if(cars.has(car)) //ako veche q sudurja tazi kola
        {
            modelAndCount = cars.get(car);

            //ako modela go ima mu vzimame cenata i q subirame s taq
            if(modelAndCount.has(model))
            {
                oldCount = modelAndCount.get(model);
                count += oldCount;
            }
            modelAndCount.set(model, count);
        }
        else // ako ne se sudurja veche tozi kluch
        modelAndCount.set(model, count);

        cars.set(car, modelAndCount);
    }

    //print:    
    for (const car of cars) {
        console.log(car[0]);
      //  console.log([...car[1]]);
        
        for (let [model, count] of [...car[1]]){
            console.log('###' + model + ' -> ' + count);     
        }

    }
}

s(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);







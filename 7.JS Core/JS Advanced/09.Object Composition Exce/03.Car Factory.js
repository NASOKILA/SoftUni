function solve(input) {

    let storage = {
        smallEngine:{power: 90, volume: 1800},
        normalEngine:{power: 120, volume: 2400},
        monsterEngine:{power: 200, volume: 3500},
        hatchback: {type: 'hatchback', color: ''},
        coupe: {type: 'coupe', color: ''}
    };

    if(input['power'] <= 90) {
        input['engine'] = storage['smallEngine'];
    }
    else if(input['power'] <= 120){
        input['engine'] = storage['normalEngine'];
    }
    else if(input['power'] <= 200){
        input['engine'] = storage['monsterEngine'];
    }

    delete input['power'];

    if(input['carriage'] === 'hatchback') {
        storage['hatchback']['color'] = input['color'];
        input['carriage'] = storage['hatchback'];
    }
    else if (input['carriage'] === 'coupe'){
        storage['coupe']['color'] = input['color'];
        input['carriage'] = storage['coupe'];
    }

    delete input['color'];

    if(input['wheelsize'] % 2 === 1){

        let weels = [input['wheelsize'],input['wheelsize'],
            input['wheelsize'],input['wheelsize']];
        input['wheels'] = weels;

    }
    else {
        let weels = [input['wheelsize']-1,input['wheelsize']-1,
            input['wheelsize']-1,input['wheelsize']-1];
        input['wheels'] = weels;
    }

    delete input['wheelsize'];

    return input;
}


solve({ model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 });

solve({ model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17 }
);









//“{systemName} | {componentName} | {subcomponentName}”
function solve(args) {

    let systems = new Map();

    for (let row of args) {
        let elements = row.split(' | ');

        let [system, component, subcomponent] = elements;

        let components = new Map();
        let subcomponents = [];

        //ako veche q ima taq sistema
        if (systems.has(system)) {
            components = systems.get(system);
            //ako veche go ima i komponenta
            if (components.has(component)) {
                subcomponents = components.get(component);
                subcomponents.push(subcomponent);
                components.set(component, subcomponents);
                systems.set(system, components);

            }
            else {
                //ako go nqma go setvame zedno sus vsichko drugo
                subcomponents.push(subcomponent);
                components.set(component, subcomponents);
                systems.set(system, components);
            }

        }
        else {
            subcomponents.push(subcomponent);
            components.set(component, subcomponents);
            systems.set(system, components);
        }
    }

    let sorted = [...systems.keys()].sort(sortSystems);
    for (let s of sorted) {
        console.log(s);
        let sys = systems.get(s);

        for (let comp of sys) {
            console.log('|||' + comp[0]);

            for (let subcomp of comp[1]) {
                console.log('||||||' + subcomp);
            }
        }

    }

    function sortSystems(s1, s2) {
        if(systems.get(s1).size != systems.get(s2).size) {
            return systems.get(s2).size - systems.get(s1).size;
        } else {
            return s1.toLowerCase().localeCompare(s2.toLowerCase());
        }
    }
}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']);


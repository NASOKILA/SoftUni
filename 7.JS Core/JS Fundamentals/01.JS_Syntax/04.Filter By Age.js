
function FilterByAge(minAge, p1Name, p1Age, p2Name, p2Age)
{

    let people = [];

    let personOne = {name: p1Name, age: p1Age};
    people.push(personOne);

    let personTwo = {name: p2Name, age: p2Age};
    people.push(personTwo);

    for(let p of people)
    {
        if(p.age >= minAge)
            console.log(p);
    }

}


FilterByAge(12, 'Ivan', 15, 'Asen', 9);



















function solve(name, age, weight, height) {

    //get BMI
    let heightInMeters = height / 100;
    let BMI = Math.round(weight / (heightInMeters * heightInMeters));

    //get status
    let status = '';
    if(BMI < 18.5)
        status = 'underweight';
    else if(BMI >= 18.5 && BMI < 25)
        status = 'normal';
    else if(BMI >= 25 && BMI < 30)
        status = 'overweight';
    else
        status = 'obese';

    //make persona Info obj
    let personalInfo = {
        age: age,
        weight: weight,
        height: height
    };

    //make person object
    let person = {
        name: name,
        personalInfo: personalInfo,
        BMI: BMI,
        status: status
    };

    //add reccommendation to the object
    if(status === 'obese')
        person['recommendation'] = 'admission required';

    
    return (person);
}

solve('Peter', 29, 75, 182);
//solve('Honey Boo Boo', 9, 57, 137);

function solve(name, age, weight, height) {

    let personalInfo = {
        age: age,
        weight: weight,
        height, height
    };
    heightInMeters = height / 100;
    let bmi = Math.round(weight / Math.pow(heightInMeters,2));

    let status = '';

    if(bmi < 18.5)
        status = 'underweight';
    else if(bmi >= 18.5 && bmi < 25)
        status = 'normal';
    else if(bmi >= 25 && bmi < 30)
        status = 'overweight';
    else if(bmi >= 30)
        status = 'obese';

    let patient = {
            name: name,
            personalInfo: personalInfo,
            BMI: bmi,
            status: status
    };

    if(status === 'obese')
        patient['recommendation'] = 'admission required';

    return(patient);
}

solve('Peter', 29, 75, 182);
solve('Honey Boo Boo', 9, 57, 137);
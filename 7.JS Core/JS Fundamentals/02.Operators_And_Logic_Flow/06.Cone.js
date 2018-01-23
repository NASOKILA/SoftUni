


function Cone(r, h) {

    //radius  height
    //V = (1/3)πr2h
    //A = L + B = πrs + πr2 = πr(s + r) = πr(r + √(r2 + h2))

    let volume = (1/3) * Math.PI * Math.pow(r, 2) * h;
    console.log('volume = ' + volume.toFixed(4));

    let lateralArea = Math.PI * r * Math.sqrt(Math.pow(r, 2) + Math.pow(h, 2));
    let baseArea = Math.PI * Math.pow(r, 2);
    let area = lateralArea + baseArea;
    console.log('area = ' + area.toFixed(4));
}

Cone(3, 5);
Cone(3.3, 7.8);










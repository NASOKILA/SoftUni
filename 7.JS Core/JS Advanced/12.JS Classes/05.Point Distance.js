


class Point {
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

//sega tazi funkciq e zakachena za SAMIQ KLAS 'Point', NE MOJEM DA Q POLZVAME OT INSTANCIQ
 static distance(a, b) {
    //const ne mojem da go promenqme
    const dx = a.x - b.x;
    const dy = a.y - b.y;
    return Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2));
    }

}
//Ako printirame 'this' v statichniq metod shte vidim che toi sochi kum SAMIQ KLAS Point    

//STATICHNIQ METOD E ZAKACHEN 'DIRECTNO' ZA KLASA.
//SLEDOVATELNO Q IZVIKVAME DIREKTNO OT IMETO NA SAMIQ KLAS : Point.distance(...) //Point E S GLAVNA BUKVA
//I NE MOJEM DA GO POLZVAME OT INSTANCII A SAMO OT SAMIQ KLAS, V SLUCHAQ E: Point.distance(..., ...);

let pointOne = new Point(-2, 5);
let pointTwo = new Point(22, 15);

//SEGA ZA DA IZVIKAME STATICHNIQ METOD PROSTO PISHEM;
console.log(Point.distance(pointOne, pointTwo));

//NE MOJEM DA GO IZPOLZVAME OT INSTANCII:
console.log(pointOne.distance); // dava undefined


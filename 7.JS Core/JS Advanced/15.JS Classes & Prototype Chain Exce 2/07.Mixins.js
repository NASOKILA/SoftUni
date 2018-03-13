

//Test Classess :

class Keyboard {
    constructor(manufacturer, responseTime) {
        this.manufacturer = manufacturer;
        this.responseTime = Number(responseTime);
    }
}

class Monitor {
    constructor(manufacturer, width, height) {
        this.manufacturer = manufacturer;
        this.width = Number(width);
        this.height = Number(height);
    }
}

class Battery {
    constructor(manufacturer, expectedLife) {
        this.manufacturer = manufacturer;
        this.expectedLife = Number(expectedLife);
    }
}

class Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
        if (new.target === Computer)
            throw new Error('Cannot instantiate an abstract class.');

        this.manufacturer = manufacturer;
        this.processorSpeed = Number(processorSpeed);
        this.ram = Number(ram);
        this.hardDiskSpace = Number(hardDiskSpace);
    }
}

class Laptop extends Computer {

    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {

        super(manufacturer, processorSpeed, ram, hardDiskSpace);

        this.weight = Number(weight);
        this.color = color;
        this.battery = battery;
    }


    get battery() {
        return this._battery;
    }
    set battery(newBattery) {

        let className = newBattery.constructor.name;
        if (className !== 'Battery')
            throw new TypeError('The type is not a Battery.');

        this._battery = newBattery;
    }

}

class Desktop extends Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {

        super(manufacturer, processorSpeed, ram, hardDiskSpace);

        this.keyboard = keyboard;
        this.monitor = monitor;
    }


    get keyboard() {
        return this._keyboard;
    }
    set keyboard(newKeyboard) {

        let className = newKeyboard.constructor.name;
        if (className !== 'Keyboard')
            throw new TypeError('The type is not a Keyboard.');

        this._keyboard = newKeyboard;
    }

    get monitor() {
        return this._monitor;
    }
    set monitor(newMonitor) {

        let className = newMonitor.constructor.name;
        if (className !== 'Monitor')
            throw new TypeError('The type is not a Monitor.');

        this._monitor = newMonitor;
    }

}







function createMixins() {

    function computerQualityMixin(classToExtend) {

        classToExtend.prototype.getQuality = function () {
            let result = (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
            return result;
        }

        classToExtend.prototype.isFast = function () {
            return (this.processorSpeed > (this.ram / 4));
        }

        classToExtend.prototype.isRoomy = function () {
            return (this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed));
        }
    }

    function styleMixin(classToExtend) {

        classToExtend.prototype.isFullSet = function () {

            let keyboardManufacturer = this.keyboard.manufacturer;
            let monitordManufacturer = this.monitor.manufacturer;

            let computerManufacturer = this.manufacturer;

            let result;
            (keyboardManufacturer === monitordManufacturer
            && monitordManufacturer === computerManufacturer)
                ? result = true
                : result = false
                
            return result;
        }


        classToExtend.prototype.isClassy = function () {

            let batteryLessThanThree = this.battery.expectedLife >= 3;
            let weightLesThanThree = this.weight < 3;
            let colorCheck = (this.color === 'Black' || this.color === 'Silver');

            return (batteryLessThanThree && weightLesThanThree && colorCheck);
        }

    }

    return {
        computerQualityMixin,
        styleMixin
    }
}

let result = createMixins();


/*
result.computerQualityMixin(Laptop);

let laptop = new Laptop('ASER', 5, 10, 50, 100, 'Black', new Battery('ASUS', 356)); 

console.log(laptop.getQuality());

console.log(laptop.isFast());

console.log(laptop.isRoomy());
*/


//styleMixin test
/*
result.styleMixin(Desktop);

let keyboard = new Keyboard('Lenovo', 1);
let monitor = new Monitor('Lenovo', 50, 90);
let desktop = new Desktop('Lenovo', 5, 10, 50, keyboard, monitor);

console.log(desktop.isFullSet());

*/

/*
result.styleMixin(Laptop);

let laptop = new Laptop('ASER', 5, 10, 50, 2, 'Black', new Battery('ASUS', 356)); 

console.log(laptop.isClassy());
*/




function solve(args) {

    let rectangles = [];
    for(let arg of args){
        let rect = createRectangle(arg[0], arg[1]);
        rectangles.push(rect)
    }

    function createRectangle(width, height) {

        let rectangle = {
            width: rect[0],
            height: rect[1],
            area: function () {
                return this.width * this.height;
            },
            compareTo: function (other) {
                //vrushta ili ednoto ili drugoto
                return other.area() - this.area() || other.width - this.width
            }
        };

        return rectangle;
    }

    rectangles = rectangles.sort((a,b) => a.compareTo(b));
    return rectangles;
}


//solve([[10,5],[5,12]]);

solve([[10, 5], [3, 20], [5, 12]]);







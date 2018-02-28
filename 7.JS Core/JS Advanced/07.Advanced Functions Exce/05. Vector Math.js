




let solution = (function () {

    let obj = {
        add:(x, y) => { return [x[0] + y[0], x[1] + y[1]]},
        multiply: (x, y) => {return [x[0]*y, x[1]*y]},
        length: (x) => Math.sqrt(Math.pow(x[0], 2) + Math.pow(x[1], 2)), 
        dot: (x, y) => ((x[0] * y[0]) + (x[1] * y[1])),
        cross: (x, y) => ((x[0] * y[1]) - (x[1] * y[0]))
    }

    return obj;

})()
    //console.log(solution.add([1, 1], [1, 0]));
    //console.log(solution.multiply([3.5, -2], 2));
    //console.log(solution.length([3, -4]));
    //console.log(solution.dot([1, 0], [0, -1]));
    //console.log(solution.cross([3, 7], [1, 0]));
    
    //console.log(solution.add([5.43, -1], [1, 31]));
    //console.log(solution.dot([2, 3], [2, -1]));




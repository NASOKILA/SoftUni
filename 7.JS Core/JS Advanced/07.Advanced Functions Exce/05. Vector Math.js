




let solution = (function () {

    return {
        add: function add(vect1, vect2) {

            let result = [];
            result.push(vect1[0] + vect2[0]);
            result.push(vect1[1] + vect2[1]);
            return result;
        },
        multiply: function multiply(vect1, scalar) {

            let result = [];
            result.push(vect1[0] * scalar);
            result.push(vect1[1] * scalar);
            return result;
        },
        length: function length(vect1) {

            let result = (Math.sqrt(Math.pow(vect1[0],2) + Math.pow(vect1[1],2)));
            return result;
        },
        cross: function cross(vect1, vect2) {
            return (vect1[0] * vect2[1]) - (vect1[1] * vect2[0])
        },
        dot: function dot(vect1, vect2) {

            let result = (vect1[0] * vect2[0]) + (vect1[1] * vect2[1]);
            return result;
        }

    };

})()
    //console.log(solution.add([1, 1], [1, 0]));
    //console.log(solution.multiply([3.5, -2], 2));
    //console.log(solution.length([3, -4]));
    //console.log(solution.dot([1, 0], [0, -1]));
    //console.log(solution.cross([3, 7], [1, 0]));
    //console.log(solution.add([5.43, -1], [1, 31]));;
    //console.log(solution.dot([2, 3], [2, -1]));




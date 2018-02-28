
//NAPRAVIH MNOGO GLUPAVI GRESHKI NA TESTA IMA LI NACHIN DA GO KARAM NA NOVO ?

    
function solveProblem(input) {
    
    if (input.length == 0 || input == null) {
        return 0;
    }

    var maximumElement = 0;
    var indexContainer = [];
    var index = 0;
    while (index < input.length) {

        let currentRectangleHeight = input[index];
        if (currentRectangleHeight >= input[indexContainer[indexContainer.length - 1]] 
            || indexContainer.length == 0) {
            
                indexContainer.push(index++);
        } else {

            var lastElement = indexContainer.pop();
            var height = input[lastElement];
            var width = indexContainer.length == 0 
            ? index 
            : index - indexContainer[indexContainer.length - 1] - 1;

            maximumElement = Math.max(height * width, maximumElement);
        }
    }
    while (indexContainer.length !== 0) {
        var lastElement = indexContainer.pop();
        var height = input[lastElement];
        var width = indexContainer.length == 0 
        ? index 
        : index - indexContainer[indexContainer.length - 1] - 1;
        
        maximumElement = Math.max(height * width, maximumElement);
    }

    return maximumElement;
}
console.log(solveProblem([2,1,5,6,2,3]));








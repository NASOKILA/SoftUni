

function solve(args){

   args = args.map(Number);

   console.log(
       checkForSum(args[0], args[1], args[2]) ||
       checkForSum(args[0], args[2], args[1]) ||
       checkForSum(args[1], args[2], args[0]) ||
       'No'
   );

    function checkForSum(first, second, sum)
    {
        if(first + second !== sum) {
            return false;
        }

/*
        if(first > second){
            let replace = first;
            first = second;
            second = replace;
        }
*/
        if(first > second){
            [first, second] = [second, first];
        }



        return `${first} + ${second} = ${sum}`;
    }
}
solve(['-3', '-2', '-5']);














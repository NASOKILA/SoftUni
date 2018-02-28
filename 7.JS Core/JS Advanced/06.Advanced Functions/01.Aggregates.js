
function solve(arr) {

  
    let sum = arr.reduce((a,b) => Number(a) + Number(b));
    let join = arr.join('');
    let min = arr.sort((a,b) => Number(a) > Number(b))[0];
    let max = arr.sort((a,b) => Number(a) < Number(b))[0];
    let product = arr.reduce((a,b) => Number(a) * Number(b))
    
    console.log('Sum = ' + sum);   
    console.log('Min = ' + min);
    console.log('Max = ' + max);
    console.log('Product = ' + product);
    console.log('Join = ' +join);
}

solve([2,3,10,5]);

solve([5, -3, 20, 7, 0.5]);





function Prime(n) {

    if (n === 1 || n <= 0)
        return false;
    else if(n === 2)
        return true;
    else
    {
        for(let x = 2; x < n; x++)
        {
            if(n % x === 0)
                return false;

        }
        return true;
    }
}

console.log(Prime(7));
console.log(Prime(8));
console.log(Prime(81));



















function solve(args)
{
    let uniqueSequences = [];
    let sums = [];
    for(let row of args)
    {
        let sequence = JSON.parse(row);

        let sum = 0;
        for(let num of sequence)
            sum += num;

        //Ako sumata ne sushtestvuva
        if(sums.indexOf(sum) === -1)
        {
            sums.push(sum);
            uniqueSequences.push(sequence);
        }

    }
    uniqueSequences.map(a => a.sort((a,b) => a - b).reverse()) //sortirame go po suma descending
        .sort((r,t) => r.length - t.length) //sortirame vseki masiv vutre po duljina
        .forEach(e => console.log('[' + e.toString().replace(/[,]/g,', ') + ']'));  //printirame

}
/*
solve(['[-3, -2, -1, 0, 1, 2, 3, 4]',
    '[10, 1, -17, 0, 2, 13]',
    '[4, -3, 3, -2, 2, -1, 1, 0]']);
*/

solve(['[7.14, 7.180, 7.339, 80.099]',
    '[7.339, 80.0990, 7.140000, 7.18]',
    '[7.339, 7.180, 7.14, 80.099]']);


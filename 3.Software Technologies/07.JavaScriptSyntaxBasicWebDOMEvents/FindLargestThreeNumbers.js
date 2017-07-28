
function solve(args) {

    args = args.map(Number).sort((a, b) => b - a); // PRAVIM GI NA NOMERA

    // kazvame ako b e po golqmo ot a iskame da e po otpred

    let total = Math.min(args.length, 3);

    for(let i = 0; i < total; i++){


        console.log(args[i]);
    }

}
solve(['34','65','22','11','87','99']);





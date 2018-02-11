
function solve(ballots) {

    let starSystems = new Map();

    let totalVotesAtAll = 0;

    for (let ball of ballots) {

        totalVotesAtAll += ball.votes;
        
        //ako imame sistema s takova ime
        if (starSystems.has(ball.system)) {

            //si q vzimame
            let currentCancidateAndListOfVotes = starSystems.get(ball.system);


            //ako sudurja i kandidata
            if (currentCancidateAndListOfVotes.has(ball.candidate)) {
                //vzimame si kandidata i mu dobavqme samo oshte votove
                let currentVoters = currentCancidateAndListOfVotes.get(ball.candidate);
                currentVoters += ball.votes;

                currentCancidateAndListOfVotes.set(ball.candidate, currentVoters);
            
            }
            else {
                //suzdavame si noviq kandidat
                currentCancidateAndListOfVotes.set(ball.candidate, ball.votes);

            }

        }
        else {
            //ako nqmame takava sistema

            let currentCancidateAndListOfVotes = new Map();
            currentCancidateAndListOfVotes.set(ball.candidate, ball.votes);
            starSystems.set(ball.system, currentCancidateAndListOfVotes);
        }


    }



    //declare the winner of each system 
    //take the votes from the rest and give them to the winner
    //compare with the candidates from the remaining systems
    //get the winner of all winners
    //get the second winner also 
    //get the planets of the second winner
    let sistemsWinners = [];

    for (let system of starSystems) {
        
        
        //kazvame che purviq v sistemata shte e pobeditel
        let systemWinner = [...[...system][1]][0];
        systemWinner.push(system[0]);
        //ako ima obache drug s poveche votove znachi toi e pobeditel
        for (let candidate of [...system][1]) {
            let winnerVotes = Number(systemWinner[1]);
            let challengerVotes = Number(candidate[1]);

            if(winnerVotes < challengerVotes)
                systemWinner = candidate;
        }

        //take the votes from the rest and give them to the winner
       

        for (let candidate of [...system][1]) {
            
            //ako imeto e razlichno ot tova na pobeditelq mu vzimame glasovete
            if(candidate[0] !== systemWinner[0])
                systemWinner[1] += Number(candidate[1]);
        }


        
        sistemsWinners.push(systemWinner);
    }

    //find winner of winners
    let winnerOfWinners = sistemsWinners.sort((a,b) => a[1] <= b[1])[0];


    //IF THIS WINNER WON ALL THE SYSTEMS:
    if(sistemsWinners.every(e => e[0] === winnerOfWinners[0]))
    {
        let totalSumOfVotes = 0;
        sistemsWinners.map(w => totalSumOfVotes += w[1]);

        console.log(winnerOfWinners[0] + ' wins with ' + totalSumOfVotes + ' votes');
        console.log(winnerOfWinners[0] + ' wins unopposed!');
        return;
    }

    //get sum of remaining candidates
    let totalSumOfVotes = 0;
    sistemsWinners.map(w => totalSumOfVotes += w[1]);
    
    if(winnerOfWinners[1] > (totalSumOfVotes / 2))
    {
        //WE DECLARE FINALLY THE WINNER
        console.log(winnerOfWinners[0] + ' wins with ' + winnerOfWinners[1] + ' votes');
        
        //get the runnerUp
        
        //remove the current winner and find the second winner
        sistemsWinners.shift();
        let runnerUpWinner = sistemsWinners.shift();

        //subirame mu obshtata broika  kato cqlo i na nego
         sistemsWinners.filter(w => w[0] === runnerUpWinner[0])
        .map(o => runnerUpWinner[1] += o[1]);

        console.log('Runner up: ' + runnerUpWinner[0]);
    
        //print each planet of the runner up sorted by 
        //total votes of the riunner up in that system
        let runnerUpsystems = [];
        for (let system of [...starSystems]) {
            
            for (let candidate of [...system][1]) {
                
    
                if(candidate[0] === runnerUpWinner[0]
                && winnerOfWinners[2] !== system[0]){

                    //get the sum of all votes in this system
                    let runnerUpTotalSum = 0;
                    [...[...system][1]].map(w => runnerUpTotalSum += w[1]);
                    runnerUpsystems.push({'name':system[0], 'votes':runnerUpTotalSum});
                    break;
                    //we break out of thi sytem
                }    
            }
        }

        //get the winnersSystem that he won and eliminate her from 


        for(let sys of runnerUpsystems.sort((a,b) => (a.votes <= b.votes)))
        {
            console.log(sys.name + ': ' + sys.votes);
        }

    }
    else
    {
        //AKO NE E POVECHE OT POLOVINATA
        //IMAME RUNOFF MEJDU PURVITE DVAMA
        //get the runnerUp
        
        //remove the current winner and find the second winner
        sistemsWinners.shift();
        sistemsWinners.filter(w => w[0] === winnerOfWinners[0])
        .map(o => winnerOfWinners[1] += o[1]);

        //vzimame vsichki glasove ot vsichki sistemi na purviq pobeditel

        let runnerUpWinner = sistemsWinners.shift();
        sistemsWinners.shift();
        sistemsWinners.filter(w => w[0] === runnerUpWinner[0])
        .map(o => runnerUpWinner[1] += o[1]);

        let winnerPercentage = Math.floor(100 / (totalVotesAtAll / winnerOfWinners[1]));
        let runnerPercentage = Math.floor(100 / (totalVotesAtAll / runnerUpWinner[1]));
        console.log('Runoff between ' + winnerOfWinners[0] + ' with ' + winnerPercentage + '%' + ' and ' + runnerUpWinner[0] + ' with ' + runnerPercentage + '%');
    }

}


solve(
    [ { system: 'Tau',     candidate: 'Flying Shrimp', votes: 150 },
      { system: 'Tau',     candidate: 'Space Cow',     votes: 100 },
      { system: 'Theta',   candidate: 'Space Cow',     votes: 10 },
      { system: 'Sigma',   candidate: 'Space Cow',     votes: 200 },
      { system: 'Sigma',   candidate: 'Flying Shrimp', votes: 75 },
      { system: 'Omicron', candidate: 'Flying Shrimp', votes: 50 },
      { system: 'Omicron', candidate: 'Octocat',       votes: 75 } ]
    );
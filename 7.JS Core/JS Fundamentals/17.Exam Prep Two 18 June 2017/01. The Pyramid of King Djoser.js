
function solve(base, increment) {

    let stones = 0;
    let marbies = 0;
    let lapis = 0;
    let gold = 0;

    let step = 1;

    if (base % 2 === 0) {
        //Ako sazata e chetna
        for (let blocks = base; blocks >= 0; blocks = blocks - 2) {

            if (blocks > 2) {

                //calculate stones
                stones += CalculateStonesOrGold(blocks, increment);

                if (step % 5 === 0) {
                    //calculate lapis
                    lapis += CalculateMarbiesOrLapis(blocks, increment);
                }
                else {
                    //calculate marbies
                    marbies += CalculateMarbiesOrLapis(blocks, increment);
                }
            }
            else {

               
                //get only gold
                gold += (blocks * blocks) * increment;
                break;
            }



            step++;
        }

        let pyramidHeight = Math.floor((step) * increment);

        //Print
        Print(stones, marbies, lapis, gold, pyramidHeight);
    }
    else {

        //Ako sazata e NEchetna
        for (let blocks = base; blocks >= 1; blocks = blocks - 2) {

            if (blocks > 1) {

                //calculate stones
                stones += CalculateStonesOrGold(blocks, increment);

                if (step % 5 === 0) {
                    //calculate lapis
                    lapis += CalculateMarbiesOrLapis(blocks, increment);
                }
                else {
                    //calculate marbies
                    marbies += CalculateMarbiesOrLapis(blocks, increment);
                }
            }
            else {
                
                //get only gold
                gold += CalculateStonesOrGold(blocks, increment);
            }



            step++;

            if (blocks == 1)
                break;
        }

        let pyramidHeight = Math.floor((step - 1) * increment);

        Print(stones, marbies, lapis, gold, pyramidHeight);
    }







    function Print(stones, marbies, lapis, gold, pyramidHeight) {

        console.log('Stone required: ' + Math.ceil(stones));
        console.log('Marble required: ' + Math.ceil(marbies));
        console.log('Lapis Lazuli required: ' + Math.ceil(lapis));
        console.log('Gold required: ' + Math.ceil(gold));
        console.log('Final pyramid height: ' + pyramidHeight);

    }

    function CalculateMarbiesOrLapis(blocks, increment) {
        let width = blocks;
        let height = blocks;

        let perimeter = 2 * (width + height);
        return (perimeter - 4) * increment;
    }

    function CalculateStonesOrGold(blocks, increment) {

        let width = blocks - 2;
        let height = blocks - 2;

        let area = width * height;
        return (area * increment);
    }

}



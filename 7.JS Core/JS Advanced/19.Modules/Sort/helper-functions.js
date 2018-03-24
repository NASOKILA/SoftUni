



function mapSort(map, sortFn) {
    
    if (sortFn === undefined) {
    
        //we sort the map by its keys
        let orderedMapArray = [...map].sort(
            function(a, b){
            if(a[0] < b[0]) return -1;
            if(a[0] > b[0]) return 1;
            return 0;
        });

        //put the values in a new Map()
        let orderedMap = new Map();

        orderedMapArray.forEach(e => {
            orderedMap.set(e[0], e[1]);
        })

        return (orderedMap);
    }

    // ako imame podadena funkciq

    //pravim nov map, pulnim go sus sortitranite stoinosti i go vrushtame
    let result = new Map();

    [...map].sort(sortFn).forEach(e => {
        result.set(e[0], e[1]);
    })

    return result;
}

module.exports = mapSort;












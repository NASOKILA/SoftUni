import React from 'react';

const All = (props) => {

    //take url parameter
    let food = props.match.params.food;
    
    //footId is an optional parameter
    let foodId = props.match.params.foodId;

    //if the footId is missin we take an empty string  
    let optionalId = foodId ? "Id : " + foodId : "";
    
    return (
        <div>
            <h1>All avaliable foods</h1>
            <h2>Food: {food}</h2>
            <h3>{optionalId}</h3>
        </div>
    )
}

export default All;
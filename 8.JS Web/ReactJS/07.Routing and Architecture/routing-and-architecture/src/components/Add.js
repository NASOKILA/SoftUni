import React from 'react';

const AddCatFood = () => {
    return (<div>
    <h1>Add cat food form</h1>
    <form>
        Name:
        <input type="text" name="name"/><br/>
        Weight:
        <input type="number" name="weight"/><br/>
        Price:
        <input type="number" name="price"/><br/>
        <input type="submit" value="Create" /><br/>
    </form>
    </div>)
}

export default AddCatFood;


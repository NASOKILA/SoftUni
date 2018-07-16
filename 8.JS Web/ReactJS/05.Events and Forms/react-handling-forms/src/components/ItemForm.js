import React from 'react';

import propTypes from 'prop-types';


class ItemForm extends React.Component {

    constructor(props) {
        super(props)

        this.state = {
            itemName : ''
        }
    
        this.OnInputChangedEvent = this.OnInputChangedEvent.bind(this);
        this.OnItemSaved = this.OnItemSaved.bind(this);
    }

    OnItemSaved(event){
        event.preventDefault()

        //we cn use the function that we passed to this komponent as props !!!
        this.props.addItem(this.state.itemName)
    }

    OnInputChangedEvent(event){
        this.setState({
            itemName : event.target.value
        })
    }

    render() {

        let formName = 'MyForm';
        if(this.props.name.length > 6 ) {
            formName = this.props.name;
        }

        return (
            <form onSubmit={this.OnItemSaved}>

            <div>{formName}</div>
                Name:
                <input 
                type="text" 
                name="name"
                onChange={this.OnInputChangedEvent}
                value={this.itemName} />
                
                <input type="submit" value="Submit" />
            </form>
        )
    }
}


//we want the name property to be of type string:
ItemForm.propTypes = {
    //we can set it to be required
    name: propTypes.string
}

export default ItemForm;

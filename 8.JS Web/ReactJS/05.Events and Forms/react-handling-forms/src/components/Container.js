import React, {Component} from 'react';
import List from '../components/List';
import ItemForm from '../components/ItemForm';

export default class Container extends Component {
    
    constructor(props){
        super(props)

        this.state = {
            items:[]
        }

        this.addItem = this.addItem.bind(this);
    }


    addItem(itemName){
        this.setState(prevState => {

            let items = prevState.items;
            
            items.push({
                id: itemName.length + 1,
                name: itemName
            })
        })
    }

    render(){

        return (
            <div>
                {this.props.children[0]}
                {this.props.children[1]}
                <br/>
                <h1>Main Page</h1>
                <List items={this.state.items} />
                <ItemForm addItem={this.addItem} name={true}/>
            </div>
        )
    }
}
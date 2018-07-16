import React, {Component} from 'react';

export default class BoundForm extends Component {
    constructor(props){
        super(props);

        this.state = stateFromChildren(this.props.children);

        //bind
        this.onChange = this.onChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onChange(e){

        //we reset the state on every input change
        let key = e.target.name;
        let value = e.target.value;

        this.setState({
            [key] : value
        })
    }

    onSubmit(e){
        //prevent default is important
        e.preventDefault();

        //we pass the state to the outsidFunction in the <App /> component
        this.props.onSubmit(e, Object.assign({}, this.state));
    }

    render(){

        return (
            <form onSubmit={this.onSubmit}>

                {/*If there are no children returns null, if there are many children it returns a collection !!!*/}
                {React.Children.map(this.props.children, child => {
                
                if(child.type === 'input' && child.props.name){
                    return <input onChange={this.onChange} value={this.state[child.props.name]} {...child.props}/>;
                }

                return child;   
                })}                
                
            </form>
        )
    }
}


function stateFromChildren(children) {
    
    let inputs = {};
    React.Children.map(children, child => {
                
        if(child.type === 'input' && child.props.name){
            inputs[child.props.name] = ''; 
        }

    });
    
    return inputs;
}
import React from 'react';
import withLoading from '../helpers/withLoading';

class ComponentWithData extends React.Component {

    constructor(props){
        super(props);

        this.state = {
            ready: false,
            data:[]
        }
    }

    componentDidMount(){

        if(this.props.data)
        {
            const data = this.props.data;
        
            console.log(data);

            this.setState({
                ready : true,
                data
            })
        }
    }

    render(){

        if(this.state.ready)
        {

            return(
                <ul>
                    {this.props.data.map(i => {
                            alert('hi')
                            return <li id="item" key={i.id}>{i.name}</li>
                    })}
                </ul>
            ) 
        }
        
        return (<h1>Data Not Found</h1>)

        
    }
}

const ComponentResult = withLoading(ComponentWithData);

export default ComponentResult;
 
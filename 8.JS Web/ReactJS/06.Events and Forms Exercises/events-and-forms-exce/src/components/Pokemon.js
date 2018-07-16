import React from 'react';

export default class Pokemon extends React.Component {
    constructor(props) {
        super(props);

    }


    render(){
        return(
            <div>
                <img width="200px" src={this.props.item.pokemonImg} alt={"No Image"} />
                <h2> {this.props.item.pokemonName} </h2>
                <p> {this.props.item.pokemonInfo} </p>
                <br/>
                <br/>
            </div>
        )
    }

}
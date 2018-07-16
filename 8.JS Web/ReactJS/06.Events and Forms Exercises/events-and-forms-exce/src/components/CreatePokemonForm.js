import React from 'react';
import Pokemon from './Pokemon'
import Error from './Error'

export default class CreatePokemonForm extends React.Component {
    constructor(props) {
        super(props);



        this.state = {
            pokemon: {
                pokemonName: '',
                pokemonImg: '',
                pokemonInfo: ''
            },
            pokemons: [],
            error: {
                state: false,
                message: ''
            }
        }

        this.submit = this.submit.bind(this);
        this.handleUpdate = this.handleUpdate.bind(this);
        this.isFormValid = this.isFormValid.bind(this);
    }


    handleUpdate(e) {

        e.preventDefault();

        let key = e.target.name;
        let value = e.target.value;


        let newPokemon = {};
        newPokemon[key] = value;

        this.setState({
            pokemon: Object.assign(this.state.pokemon, newPokemon)
        })

    }

    isFormValid(e) {

        let pokemon = this.state.pokemon;
        if (pokemon.pokemonName === "") {
            
            let error = {};
            error.state = true;
            error.message = "Pokemon name is required !";

            this.setState({
                error
            });

            return false;
        }
        else if (pokemon.pokemonInfo === "") {
            
            let error = {};
            error.state = true;
            error.message = "Pokemon description is required !";

            this.setState({
                error
            });

            return false;
        }

        return true;
    }


    submit(e) {

        
        if (this.isFormValid(e)) {

            //we have to send a post request to http://localhost:5000/auth/login to Login
            fetch('http://localhost:5000/pokedex/create', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(this.state.pokemon)
            })
                .then(data => data.json()).catch(err => console.log(err))
                .then(res => {
                    console.log(res)
                });
        }
        else
        {
            e.preventDefault();
        }
    }

    componentDidMount() {


        fetch('http://localhost:5000/pokedex/all', {
            method: 'GET'
        })
            .then(data => data.json())
            .then(res => {

                console.log(res);

                let pokemons = res.pokemonColection;
                this.setState({
                    pokemons
                })
            });

    }




    render() {
        return (
            <div className="container-fluid">

                <br />
                <h1>Welcome, {localStorage.getItem('username')}</h1>
                <br />

                {this.state.error.state ? <Error output={this.state.error.message} /> :  ""   }
                <form onSubmit={this.submit}>

                    <h1>Add Pokemon</h1>
                    <div className="form-group">
                        <label htmlFor="PokemonName">Pokemon Name</label>
                        <input onChange={this.handleUpdate} type="text" name="pokemonName" className="form-control" id="PokemonName" aria-describedby="emailHelp" placeholder="Pokemon Name" />
                    </div>

                    <div className="form-group">
                        <label htmlFor="PokemonImage">Pokemon Image</label>
                        <input onChange={this.handleUpdate} type="text" name="pokemonImg" className="form-control" id="PokemonImage" aria-describedby="emailHelp" placeholder="Pokemon Image" />
                    </div>

                    <div className="form-group">
                        <label htmlFor="pokemonInfo">Pokemon Info</label>
                        <input onChange={this.handleUpdate} type="text" name="pokemonInfo" className="form-control" id="pokemonInfo" placeholder="Pokemon Info" />
                    </div>
                    <div>
                        <button type="submit" className="btn btn-primary">Add</button>
                    </div>
                </form>
                <br />
                <br />
                {this.state.pokemons.length < 1 ? <h1>No Pokemons in Db.</h1> : this.state.pokemons.map(pok => <Pokemon item={pok} />)}

            </div>
        )
    }

}
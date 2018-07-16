import React from 'react';

import Rooster from './Rooster';
import Details from './Details';
import fetcher from '../../fetcher';

//this is how the server take data from bioDb and epDb files.
const ROOSTER_ENPOINT = '/roster';
const DETAILS_ENDPOINT = '/character/';

export default class Characters extends React.Component {

    constructor(props) {
        super(props);

        this.state =
            {
                images: [],
                details: {
                    id: null,
                    name: null,
                    url: null,
                    bio: null
                }
            }
    }

    /*
        {
            "id": "0",
            "name": "Rick",
            "url": "https://avatarfiles.alphacoders.com/889/88985.png",
            "bio": "Rick Sanchez is the co-eponymous main character and leading protagonist of the show. He is a genius scientist whose alcoholism and reckless, nihilistic behavior are a source of concern for his daughter's family, as well as the safety of their son, Morty. He is voiced by Justin Roiland."
        },
        {
            "id": "1",
            "name": "Morty",
            "url": "https://orig00.deviantart.net/eb23/f/2015/312/1/2/profile_picture_by_the_mortiest_morty-d9g21p0.png",
            "bio": "Mortimer 'Morty' Smith Sr. is one of the two eponymous main protagonists in Rick and Morty. He is the grandson of Rick and is often forced to tag along on his various misadventures. Morty attends Harry Herpson High School along with his sister, Summer."
        },
        {
            "id": "2",
            "name": "Evil Morty",
            "url": "https://vignette.wikia.nocookie.net/katie-sandows-adentures/images/5/5a/Evil_Morty_Close-Up.png",
            "bio": "Evil Morty is one of infinitely many versions of Morty, who is currently serving as the first democratically-elected President of the Citadel of Ricks. He first appeared in 'Close Rick-Counters of the Rick Kind', as the hidden true main antagonist, and was seen being rounded up with the other Rickless Mortys."
        },
        {
            "id": "3",
            "name": "Mr Meeseeks",
            "url": "https://vignette.wikia.nocookie.net/rickandmorty/images/6/6c/MeeseeksHQ.png/revision/latest?cb=20150930232412",
            "bio": "Mr. Meeseeks (voiced by Justin Roiland) is the name of all the Meeseeks summoned by activating a Meeseeks Box. The Meeseeks appear in the fifth episode of the first season, 'Meeseeks and Destroy'. They are known to inhabit planets across the universe"
        } 
    */


    componentDidMount() {
        this.fetchRoaster();    
        this.fetchDetails(0);
        console.log(this.state);
    }



        //we set 'images' to the array in the bioDb file
        fetchRoaster = () =>
            fetcher.get(ROOSTER_ENPOINT, data => {

            //we use .map() to deteriorate the object
            this.setState({
                images: data.map(i => ({
                    id: i.id,
                    url: i.url
                }))

            });
        });


        fetchDetails = (id) =>
            fetcher.get(DETAILS_ENDPOINT + id, data => {

            //we use .map() to deteriorate the object
            this.setState({
                details: data
            });

        });


        //this function recves an id and extracts the character with that id from the bioDb file.
        selectCharacter = (id, condition) => { 

            this.selected = true;
            return this.fetchDetails(id)
        }
        
        selected = false;

    //we have to pass the state proeprtiest to the other components. 
    render = () => (
        <div>
            {/*We pass  the state and the function selectCharacter to the Roaster Component */}
            <Rooster images={this.state.images} select={this.selectCharacter} />

            {/*Here we directly pu the object in*/}
            <Details {...this.state.details} selected={this.selected}/>
        </div>
    )
}
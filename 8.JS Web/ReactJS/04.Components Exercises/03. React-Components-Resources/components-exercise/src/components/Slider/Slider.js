import React from 'react';
import fetcher from '../../fetcher';

const IMAGE_URL = '/episodePreview/';

export default class Slider extends React.Component {

    constructor(props)
    {
        super(props);

        this.state = {
            url: null,
            id: null
        }
    }


    //we pull data from a server with the fetcher, updates the state
    fetchEpisode = id => 
    fetcher.get(IMAGE_URL + id, data => {
        this.setState(data);
    });

    componentDidMount = () => {
        this.fetchEpisode(0)
    }

    OtherImage = id => {

        fetcher.get(IMAGE_URL + id, data => {
            this.setState(data);
        });
    }
    
    render = () => (
            <section id="slider">
                <img className="button"  onClick={() => this.OtherImage(this.state.id - 1)} src="/left.png" title="previous" alt="nav" />
                <div className="image-container">
                    <img src={this.state.url} alt="episode" />
                </div>
                <img className="button" onClick={() => this.OtherImage(this.state.id + 1)} src="/right.png" title="previous" alt="nav" />
            </section>
        );
}
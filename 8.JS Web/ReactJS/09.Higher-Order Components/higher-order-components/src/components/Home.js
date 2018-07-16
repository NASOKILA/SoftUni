import React from 'react';
import withLogging from '../helpers/withLogging';

class HomeBase extends React.Component {

    render(){

        const homeMessage = this.props.message || "Home Page";

        return (
        
            <div>
                <h1>{homeMessage}</h1>
            </div>
        )
    }

}

//we attach a properti to the component so we can use it later in it
HomeBase.displayName = "Home";

const Home = withLogging(HomeBase);

//export the new returned component
export default Home;

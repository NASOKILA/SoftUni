import React from 'react';
import { Route } from 'react-router-dom';

const Footer = () => {
    return (
            //we can use the Router like an inline component to render whatever we want on a path that we want.
            //we can render whatever we want on a route that we want.
        <div>
            <footer>My Footer</footer>
            <Route path="/random" render={() => (
                 <h2>Random Router Function Return.</h2>
            )}/>
        </div>
    )
}

export default Footer;
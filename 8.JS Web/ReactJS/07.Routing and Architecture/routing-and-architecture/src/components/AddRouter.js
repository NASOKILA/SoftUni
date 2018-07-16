import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';

import Home from './Home';
import Add from './Add';
import All from './All';
import About from './About';
import Contacts from './Contacts';
import PathNotFound from './PathNotFound'

const Router = () => (
    <div>

        {/*If we have two same links it renders the firstOne*/}
        <Switch>
            <Route path="/home" component={Home} />
            <Route path="/" exact component={Home} />

            {/*URL Params:  foodId is an optional parameter */}
            <Route path="/all/:food/:foodId?" component={All} />

            <Route path="/add" exact component={Add} />
            <Route path="/about" exact component={About} />
            <Route path="/contacts" exact component={Contacts} />
            <Route path="/path-not-found" component={PathNotFound} />
            <Redirect to="/path-not-found"/>
        </Switch>
    </div>
)

export default Router;
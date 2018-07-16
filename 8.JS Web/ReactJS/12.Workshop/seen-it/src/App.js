import React, { Component } from 'react';
import {Route} from 'react-router-dom';

import './App.css';
import './styles/site.css';
import Header from './components/common/Header';
import HomeContainer from './components/home/HomeContainer';
import Notification from './components/common/Notification';
import CatalogContainer from './components/post/CatalogContainer';
import Logout from './components/user/Logout';
import { withAdminAuthorization } from './hocs/withAuthorization';
import PostDetailsContainer from './components/post/PostDetailsContainer';

class App extends Component {
    render() {
        return (
            <div className="App">
                <main className="content">
                    <Header />
                    <Notification />
                    <Route path='/' exact component={HomeContainer} />
                    <Route path='/catalog' exact component={withAdminAuthorization(CatalogContainer)} />
                    <Route path='/logout' component={Logout} />
                    <Route path='/catalog/details/:id' component={PostDetailsContainer} />
                </main>
            </div>
        );
    }
}

export default App;

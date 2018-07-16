import React, { Component } from 'react';
import './styles/site.css';
import './App.css';
import { Route } from 'react-router-dom'
import Header from  './components/common/Header';
import Home from  './components/home/Home';
import Notification from  './components/common/Notification';
import Catalog from  './components/catalog/Catalog';
import Logout from  './components/user/Logout';

import './styles/comments.css'
import './styles/header.css'
import './styles/menu.css'
import './styles/notifications.css'
import './styles/post.css'
import './styles/submit.css'
import './styles/site.css'

class App extends Component {
  render() {
    return (
      <div className="App">
      <main className="content">
        <Header />  
        <Notification />
        <Route path="/" exact component={Home}/>
        <Route path="/logout" exact component={Logout}/>
        <Route path="/catalog" exact component={Catalog}/>
      </main>
    </div>

    );
  }
}

export default App;

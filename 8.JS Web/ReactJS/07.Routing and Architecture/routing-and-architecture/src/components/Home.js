import React from 'react';
import All from './All';
import { Route } from 'react-router-dom';

//we can use thi simple version as a component because it's just so simple.
const Home = (props) => 
(
    <div>
    <h1>Home Page</h1>
    <h2>Welcome, {props.username}</h2>

    {/*Get current url true the props*/}
    {/*We can nest urls by using the curent url BUT WE HAVE TO TAKE OF THE 'exact' KEYWORD*/}

    <Route path={props.match.url + "/all"}  component={All} />
    </div>  
);

//we can extract the property name of the props object like this:
const Home2 = ({username}) => <h1>Welcome, {username}</h1>;
const Home3 = ({username, age}) => <h1>Welcome, {username} - {age}</h1>;

export default Home;


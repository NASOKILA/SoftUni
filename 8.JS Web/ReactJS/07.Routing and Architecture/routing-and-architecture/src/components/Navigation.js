import React from 'react';

import { Link } from 'react-router-dom';

const Navigation = () => (

<div className="menu">
    <div>My Navigation</div>
    <Link to="/home">Home</Link> 
    <Link to="/about">About</Link>
    <Link to="/contacts">Contacts</Link>
    <Link to="all/foods">All Foods</Link>
</div>
);

export default Navigation;





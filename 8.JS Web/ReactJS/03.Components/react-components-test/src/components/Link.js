import React, { Component } from 'react';

//Properties can be passed to components to make a deference between them.
class Link extends Component {
    render() {
  
      //we can declare the propertes here and set them in the main component
      return (
        <div>
          <br/>
          <a href={this.props.url}>Go To {this.props.name}</a>
          <br/>
        </div>
      );
  
    }
  } 
  
  export default Link;
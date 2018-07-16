
import React, { Component } from 'react';
import Navigation from '../common/Navigation';
import PostList from '../post/PostList';

export default class Catalog extends Component {
    constructor(props) {
        super(props);

        this.state = {
        }
    }

    render() {
        return (
            <section id="viewCatalog">            
            <Navigation />
                <div class="posts">
                    <PostList />
                </div>
            </section>
        )
    }
}



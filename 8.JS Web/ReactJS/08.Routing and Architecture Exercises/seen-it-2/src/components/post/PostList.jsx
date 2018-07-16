
import React, { Component } from 'react';
import requester from '../../Infrastructure/remote'
import Post from '../post/Post'



export default class PostList extends Component {
    constructor(props){
        super(props);

        this.state = {
            posts: []
        }
    }


    componentDidMount = () => this.getPosts()


    getPosts = () => {
        requester.get('appdata', 'posts', 'kinvey')
        .then(posts => {
            let counter = 0;
            
            console.log(posts)
            
            posts.forEach(post => {
                post.id = counter;
                counter++;
            });

            this.setState({
                posts
            });
            
        })
        .catch(err => console.log(err));
    }

render()
{
    return (
        <div>
            {this.state.posts.map(p => <Post key={p.id} {...p} />)}
        </div>
    )
}

}
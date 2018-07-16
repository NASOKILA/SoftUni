import React, {Component, Fragment} from 'react';

import Navigation from '../common/Navigation';
import requester from '../../infrastructure/requester'
import postService from '../../services/postService';
import CommentForm from '../comments/CommentForm';
import CommentsList from '../comments/CommentsList';

export default class PostDetailsContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            _id: '',
            title: '',
            imageUrl: '',
            url: '',
            description: '',
            author: '',
            createdOn: '',
            comments: []
        }
    }

    addComment = comment => {
        this.setState(prevState => {
            return { comments: [...prevState.comments, comment] }
        });
    }

    removeComment = ev => {
        let commentIndex = ev.target.getAttribute('data-comment-index');
        let comment = this.state.comments[commentIndex]
        let commentId = comment._id;
        requester.remove('appdata', 'comments/' + commentId, 'kinvey')
            .then(res => {
                this.setState(prevState => {
                    prevState.comments.splice(commentIndex, 1);
        
                    return { comments : prevState.comments }
                })
            })
            .catch(console.log);
    }

    componentDidMount = () => {
        let postId = this.props.match.params.id;
        requester.get('appdata', 'posts/' + postId, 'kinvey')
            .then(res => {
                this.setState({
                    createdOn: res._kmd.ect,
                    ...res
            })})
            .catch(console.log);

        requester.get('appdata', 'comments', 'kinvey', { postId })
            .then(res => {
                this.setState({ comments: res })
            })
    }

    render = () => {
        return (
            <Fragment>
                <Navigation />
                <section id="viewPostDetails">
                    <article id="postDetails" className="post">
                        <div className="col thumbnail">
                            <img src={this.state.url} />
                        </div>
                        <div className="post-content">
                            <div className="title">
                                <strong>{this.state.title}</strong>
                            </div>
                            <div className="details">
                                {this.state.description}
                            </div>
                            <span>
                                {postService.createdBeforeDays(this.state.createdOn)} by {this.state.author} 
                            </span>
                        </div>
                    </article>
            
                    <CommentForm extraState={{postId: this.state._id}} success={this.addComment} />

                    <CommentsList comments={this.state.comments} remove={this.removeComment} />

                </section>
            </Fragment>
        )
    }
}
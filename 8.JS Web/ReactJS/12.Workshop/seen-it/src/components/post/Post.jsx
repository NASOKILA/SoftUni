import React, { Component } from 'react';
import {Link} from 'react-router-dom';

import postService from '../../services/postService'

export default class Post extends Component {
    render = () => (
        <article className="post">
            <div className="col rank">
                <span>{this.props.index + 1}</span>
            </div>
            <div className="col thumbnail">
                <a href={this.props.url}>
                    <img src={this.props.imageUrl} />
                </a>
            </div>
            <div className="post-content">
                <div className="title">
                    <a href={this.props.url}>
                        {this.props.title}
                    </a>
                </div>
                <div className="details">
                    <div className="info">
                        {postService.createdBeforeDays(this.props._kmd.ect)}
                    </div>
                    <div className="controls">
                        <ul>
                            <li className="action">
                                <Link to={'/catalog/details/' + this.props._id}>Details</Link>
                            </li>
                            <li className="action">
                                <Link to='/' className="editPost">Edit</Link>
                            </li>
                            <li className="action">
                                <Link to="/" className="deletePost">Delete</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </article>
    )
}
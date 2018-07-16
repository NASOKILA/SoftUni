
import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export default class Post extends Component {
    constructor(props){
        super(props);

        this.state = {
            author: "",
            title: "",
            url:"",
            imgeUrl: "",
            description: "",
            rank: "",
            date: "",
        }
    }

    createBeforeDays = () => {
            let dateIsoFormat = this.props._kmd.ect.createdOn; 
        
            let diff = new Date() - (new Date(dateIsoFormat));
            diff = Math.floor(diff / 60000);
            if (diff < 1) return 'less than a minute';
            if (diff < 60) return diff + ' minute' + pluralize(diff);
            diff = Math.floor(diff / 60);
            if (diff < 24) return diff + ' hour' + pluralize(diff);
            diff = Math.floor(diff / 24);
            if (diff < 30) return diff + ' day' + pluralize(diff);
            diff = Math.floor(diff / 30);
            if (diff < 12) return diff + ' month' + pluralize(diff);
            diff = Math.floor(diff / 12);
         
            return diff + ' year' + pluralize(diff);
         
            function pluralize(value) {
                if (value !== 1) return 's';
                else return '';
            }
                
    }

    render(){

        return (
            <article className="post">
            <div className="col rank">
                <span>{this.props.rank}</span>
            </div>
            <div className="col thumbnail">
                <a href={this.props.url}>
                    <img src={this.props.imageUrl} alt="Not avaliable" />
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
                        submitted {this.createBeforeDays} day ago by {this.props.author}
                    </div>
                    <div className="controls">
                        <ul>
                            <li className="action"><Link className="commentsLink" to="/comments">comments</Link></li>
                            <li className="action"><Link className="editLink" to="/edit">edit</Link></li>
                            <li className="action"><Link className="deleteLink" to="/delete">delete</Link></li>
                        </ul>
                    </div>
                </div>
            </div>
        </article>
        )
    }
}
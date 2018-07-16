import React, {Component} from 'react'

export default class Comment extends Component {
    render = () => {
        console.log('Key', this.props.index)
        return (
            <article className="comment">
                <div className="comment-content">
                   {this.props.content}
                </div>
                <a href="#" 
                   data-comment-index={this.props.index} 
                   className="action" 
                   onClick={this.props.remove}>
                    [Delete]
                </a>
            </article>
        )
    }
}
import React, { Component } from 'react';
import addStyle from '../helpers/addStyle';

class Article extends Component {
    constructor(props){
        super(props);

        this.state = {

        }
    }

    render(){

        return (
            <article>
                <header><span className="title">Article Title</span></header>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet magni labore voluptatibus. Vel sunt voluptate fugiat et ducimus voluptates doloremque, eum illo exercitationem dignissimos sequi cum, id molestiae debitis atque.</p>
            </article>
            )
    }
} 


Article.warning = true;

const ArticleWarning = addStyle(Article);

export default ArticleWarning;
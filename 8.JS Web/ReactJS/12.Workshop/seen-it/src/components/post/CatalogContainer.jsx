import React, {Component, Fragment} from 'react';
import Navigation from './../common/Navigation';
import PostsList from './../post/PostsList';

export default class CatalogContainer extends Component {
    render = () => {
        return (
            <Fragment>
                <Navigation />
                <PostsList />
            </Fragment>
        )
    }
}
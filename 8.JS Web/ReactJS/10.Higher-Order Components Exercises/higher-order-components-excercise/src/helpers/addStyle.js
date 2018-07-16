import React, { Component } from 'react';


const withWarning = (WrappedComponent) => {

    return class extends Component {
        constructor(props) {
            super(props);

            this.state = {
                warning: null
            }
        }


        componentDidMount() {

            this.setState({
                warning: WrappedComponent.warning
            })
        }

        render() {

            if (this.state.warning) {

                return (

                    <div className="alert">
                        <span className="alert-symbol">&#9888;</span>
                        <WrappedComponent error={this.state.warning} {...this.props} />
                    </div>

                )
            }

            return <WrappedComponent />
        }

    }

}

export default withWarning;


import React, {Component} from 'react'
import LoginForm from '../user/LoginForm'
import RegisterForm from '../user/RegisterForm'
import About from './About';

export default class Home extends Component {

    render(){
        return (
            <div>
                <section id="viewSignIn">
                    <div className="welcome">
                        <About />
                        <div className="signup">
                            <LoginForm {...this.props}/>
                            <RegisterForm />
                        </div>
                    </div>
                </section>
            </div>
        ) 
    }
}

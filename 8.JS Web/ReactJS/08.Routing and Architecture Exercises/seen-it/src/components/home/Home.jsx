import React, {Component} from 'react'
import LoginForm from '../user/LoginForm'
import RegisterForm from '../user/RegisterForm'
import About from '../home/About';

export default class Home extends Component {

    render(){
        return (
            <div>
                <section id="viewWelcome">
                    <div class="welcome">
                        <About />
                        <div class="signup">
                            <LoginForm />
                            <RegisterForm />
                        </div>
                    </div>
                </section>
            </div>
        ) 
    }
}

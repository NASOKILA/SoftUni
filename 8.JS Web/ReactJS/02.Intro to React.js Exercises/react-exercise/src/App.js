import React from 'react';
import './App.css';
import contacts from './contacts.json';
import rerender from './index';



let currentIndex = 0;

const ContactDetails = (contact) => {
    return <div className="content">
    <div className="info">
        <div className="col">
            <span className="avatar">&#9787;</span>
        </div>
        <div className="col">
            <span className="name">{contact.firstName}</span>
            <span className="name">{contact.lastName}</span>
        </div>
    </div>
    <div className="info">
        <span className="info-line">&phone; {contact.phone}</span>
        <span className="info-line">&#9993; {contact.email}</span>
    </div>
</div>
}

 

//Change index and rerender
const SelectDetailsContact = (index) => {
    
    currentIndex = index;
    rerender(App(), document.getElementById('root'));
}


const showResult = () => {

    let finalList = [];
  
    for(let i = 0; i < contacts.length; i++){
      let contact = contacts[i]
      finalList.push(CreateContact(contact, i));
    }
  
    return finalList;
}
   

function CreateContact(contact, i) {
  let fullname = contact.firstName + " " + contact.lastName;

  //this is how we pass a parameter in a function in "onClick" event whtout calling the function write away !!!
  return <div key={i} onClick={(e) => SelectDetailsContact(i, e)} className="contact" data-id="id">
          <span className="avatar small">&#9787;</span>
          <span className="title">{fullname}</span>
        </div>;
}

const App = () => (     
      <div className="container">
    <header>&#9993; Contact Book</header>
    <div id="book">
        <div id="list">
            <h1>Contacts</h1>
            <div className="content">
                
              {/*contacts.map((contact, i) => CreateContact(contact, i))*/}
              {showResult()}
            </div>
        </div>
        <div id="details">
            <h1>Details</h1>

            {ContactDetails(contacts[currentIndex])}
            
        </div>
    </div>
    <footer>Contact Book SPA &copy; 2017</footer>
    </div>
    );

export default App;

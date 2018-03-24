

class Contact
{
    constructor(firstName, lastName, phone, email)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.online = false;
    }
    
    render(id)
    {

        //suzdavame class info
        let classInfo =$('<div class="info" style="display:none;">')
            .append(`<span>&phone; ${this.phone}</span>`)
            .append(`<span>&#9993; ${this.email}</span>`)


        //suzdavame si butona
        let btn = $(`<button class="btn">&#8505;</div>`);
        
        //opredelqme dali sme online i ako sme si dobavqme class 'online'
        let divClass = 'title'
        if(this.online === true){
            divClass = 'online title';
        }

        let div = $(`<div class="${divClass}">${this.firstName} ${this.lastName} </div>`)
            .append(btn[0]);
         
        //suzdaveme si artikula
        let article = $('<article></article>');
        article.append(div); //zakachame mu diva
        article.append(classInfo); //zakacham mu i klassInfo        

        let mainDiv = $(`#${id}`)
            .append(article);//zakachame artikula za elementa s podadenoto ID
        


        //Zakachame klick event
        $(btn).click(function(e){
            let currentDiv = $(this).parent().parent().children()[1];
        
            if($(currentDiv).css('display') === 'none')
                $(currentDiv).css('display', 'block');        
            else
                $(currentDiv).css('display', 'none');        
        })
         
    }

    get online()
    {
        return this._online;
    }
    set online(value)
    {
        this._online = value;

        //when online status is changed update the generated HTML
        if(value === true){    
            let article = $(`span:contains("${this.email}")`)[0];
            let rightDiv = $(article).parent().parent().children()[0];
            $(rightDiv).removeClass('title');
            $(rightDiv).addClass('online title');
        }
        else 
        {
            let article = $(`span:contains("${this.email}")`)[0];
            let rightDiv = $(article).parent().parent().children()[0];
            $(rightDiv).removeClass('online title');
            $(rightDiv).addClass('title');
        }

    }   
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
  ];
  contacts.forEach(c => c.render('main'));
  
  // After 1 second, change the online status to true
  setTimeout(() => contacts[2].online = true, 2000);

  setTimeout(() => contacts[2].online = false, 4000);


function increment(selector) {

    
    let textarea = document.createElement('textarea');
    $(textarea).addClass('counter');

    let textAreaValue = 0;
    $(textarea).text(textAreaValue);


    $(textarea).text();
    $(textarea).attr('disabled', 'disabled');

    let incrementBtn = $('<button class="btn" id="incrementBtn">Increment</button>')
    
    let addBtn = $('<button>');
    addBtn.addClass('btn');
    addBtn.attr('id','addBtn');
    addBtn.text('Add');

    let ul = $(`<ul class="results"></ul>`)
    
    $(selector)
        .append(textarea)
        .append(incrementBtn)
        .append(addBtn)
        .append(ul);


    //Events:

    incrementBtn.click(function(){
        textAreaValue++;
        textarea.textContent = textAreaValue;
    })

    addBtn.on('click', function(){
        
        let li = $('<li>');
        
        li.text(textAreaValue.toString());

        li.appendTo($('.results'));
    })

}













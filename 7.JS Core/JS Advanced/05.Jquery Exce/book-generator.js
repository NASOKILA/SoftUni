




function createBook(selector, title, author, ISBN) {

    let bookIdCount = document.getElementsByTagName('div').length;
        
    (function bookGenerator() {

        let book = $('<div>');
        let currentId = ('book' + bookIdCount.toString());
        
        book.attr('id', currentId);
        book.attr('style', 'border: medium none;');

        //create and attch <p> to the book
        let titleParagraph = $('<p class="title"></p>');
        titleParagraph.text(title);
        book.append(titleParagraph);

        let authorParagraph = $(`<p class="author"></p>`);
        $(authorParagraph).text(author);
        book.append(authorParagraph);

        let isbnParagraph = $('<p class="isbn"></p>');
        isbnParagraph.text(ISBN);
        book.append(isbnParagraph);


        //create and attach events to book
        let selectBtn = $(`<button>Select</button>`);
        let deselectBtn = $(`<button>Deselect</button>`);

        selectBtn.click(function(){
            book.css('border','2px solid blue');
        });

        deselectBtn.click(function(){
            book.css('border', '');
        });

        book.append(selectBtn);
        book.append(deselectBtn);

        $(selector).append(book);

    })();

}
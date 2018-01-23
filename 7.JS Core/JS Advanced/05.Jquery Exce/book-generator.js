
function createBook(selector, title, author, ISBN) {

    let id = document.querySelectorAll('div').length;

    (function bookgenerator() {

        let div = $('<div></div>');
        div.attr('id', id);

        div.append(`<p class="title">${title}</p>`);
        div.append(`<p class="author">${author}</p>`);
        div.append(`<p class="isbn">${ISBN}</p>`);
        div.append(`<button id="select">Select</button>`);
        div.append(`<button id="deselect">Deselect</button>`);

        $(selector).append(div);

    })();

    $('button').click(function () {

        let value = $(this).text();
        if(value.indexOf('select') !== -1)
            $(this).parent().css('border', 'none');
        else
            $(this).parent().css('border', '2px solid blue');

    });

}
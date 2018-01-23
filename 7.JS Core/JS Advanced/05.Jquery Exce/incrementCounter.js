
function increment(selector) {

    let wrapper = $(selector);

    let textarea = $('<textarea class="counter" disabled></textarea>');
    textarea.val(0);
    let buttonIncrement = $('<button class="btn" id="incrementBtn">Increment</button>');
    let buttonAdd = $('<button class="btn" id="addBtn">Add</button>');
    let ul = $('<ul class="results"></ul>');


    $(buttonIncrement).on('click', function () {
        let num = Number($('.counter').val());
        num++;
        $('.counter').val(num);
    });

    $(buttonAdd).on('click', function () {
        let num = Number($('.counter').val());
        ul.append($(`<li>${num}</li>`));
    });

    wrapper.append(textarea);
    wrapper.append(buttonIncrement);
    wrapper.append(buttonAdd);
    wrapper.append(ul);

}













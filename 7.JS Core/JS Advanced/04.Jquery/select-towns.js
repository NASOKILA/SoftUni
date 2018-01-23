
function attachEvents() {
    //samo na li-tata zakachame eventa
    $('#items').on('click', 'li', function () {

        console.log('wdaww');
        if($(this).attr('data-selected'))
        {
            $(this).css('background-color','');
            $(this).removeAttr('data-selected');
        } else
        {
            $(this).css('background-color','#DDD');
            $(this).attr('data-selected', 'true');
            //slagame mu i true za da go setne na true.
        }

        $('#showTownsButton').click(function () {
            //selektirame samo tezi koito imat attribute sus stoinost 'true'
            let towns = $(`li[data-selected = 'true']`)
                .toArray().map(t => t.textContent);

            $('#selectedTowns')
                .text(`Selected towns: ${towns.join(', ')}`);
        })
    })
}




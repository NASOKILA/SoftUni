
function attachEvents() {
    //samo na li-tata zakachame eventa
    $('#items > li').on('click', function(){

        if($(this).attr('data-selected'))
        {
            $(this).removeAttr('data-selected');
            $(this).css('background-color','');
        }    
        else
        {
            $(this).attr('data-selected', 'true');
            $(this).css('background-color','#DDD');
        }
    });


    $('#showTownsButton').on('click', function(){
        $('#selectedTowns').text("");

        let selectedTowns = $('#items > li').toArray()
            .filter(l => l.hasAttribute('data-selected'));

            $('#selectedTowns')
                .text("Selected towns: " + selectedTowns
                .map(e => $(e).text())
                .join(','));
        
    });


}




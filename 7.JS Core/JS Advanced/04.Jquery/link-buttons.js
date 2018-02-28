
function attachEvents() {
    $('.button').on('click', function(event){

            $('.button').removeClass('selected');
        
            $(event.target).addClass('selected');
        });

}













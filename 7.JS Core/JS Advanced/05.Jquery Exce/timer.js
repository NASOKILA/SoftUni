

function timer() {

    let startBtn = $('#start-timer');
    let stopBtn = $('#stop-timer');

    let seconds = 0;
    let minutes = 0;
    let hours = 0;
    
    let  timer;
    let stopped = true;

    startBtn.click(function(){

        if(stopped)
        {
            timer = setInterval(Step, 1000);
            stopped = false;
        }
        
        function Step(){

            seconds++;
    
            if(seconds === 60)
            {
                seconds = 0;
                minutes++;
            }
    
            if(minutes === 60)
            {
                minutes = 0;
                hours++;
            }
    
            $('#hours').text(('0' + hours).slice(-2));
            $('#minutes').text(('0' + minutes).slice(-2));
            $('#seconds').text(('0' + seconds).slice(-2));
    
        }
    

    });

    stopBtn.click(function(){
        clearInterval(timer);
        stopped = true;
    });


}

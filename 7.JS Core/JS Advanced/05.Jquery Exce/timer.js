

function timer() {
    let sec = 0;
    let minutes = 0;
    let hours = 0;

    let stopped = true;
    let t;
    $('#start-timer').click(function () {
        if(stopped)
        {
            t = setInterval(tick,1000);
            stopped = false;
        }

        function tick()
        {
            sec++;
            if(sec >= 60)
            {
                sec = 0;
                minutes++;
            }
            if(minutes >= 60)
            {
                minutes = 0;
                hours++;
            }


            $('#seconds').text(('0' + sec).slice(-2));
            $('#minutes').text(('0' + minutes).slice(-2));
            $('#hours').text(('0' + hours).slice(-2));

        }
        //clearInterval(t)
    });

    $('#stop-timer').click(function () {
        clearInterval(t);
        stopped = true;
    });

}











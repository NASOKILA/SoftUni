

function attachGradientEvents() {

    let gradient = document.getElementById('gradient-box');
    let result = document.getElementById('result');

    gradient.addEventListener('mousemove', gradientMove);
    gradient.addEventListener('mouseout', gradientOut);


    function gradientMove (event) {

        let power = event.offsetX / (event.target.clientWidth -1);
        power = Math.trunc(power * 100);
        console.log(power);
        result.textContent =  Math.round(power) + '%';
    }

    function gradientOut(event) {
        document.getElementById('result').textContent = "";
    }


}
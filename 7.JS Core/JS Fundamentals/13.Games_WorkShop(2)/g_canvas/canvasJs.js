
/*
function restartGame(){
    console.log('clocked');

    monsterReady = true;
    heroReady = true;


    ctx.fillStyle = "pink";
    ctx.font = "50px Helvetica";
    ctx.fillText("", 110, 200);
    ctx.fillText("", 120, 250);

    main();
}
*/


//01.Get the canvas and its context:
//vzimame si kanvasa
let canvas = document.getElementById('can')
let ctx = canvas.getContext('2d')


//02.Load Images:
//zarejdame backgrount image i imame promenliva koqto e true kogato 
//e zaredena snimkata
let bgReady = false;
let bgImage = new Image();
bgImage.onload = function () {
    bgReady = true;
};
bgImage.src = "./images/background.png";

//zarejdame i heroImage
let heroReady = false;
let heroImage = new Image();
heroImage.onload = function () {
    heroReady = true;
};
heroImage.src = "./images/hero.png";

//zarejdame i monsterImage
let monsterReady = false;
let monsterImage = new Image();
monsterImage.onload = function () {
    monsterReady = true;
};
monsterImage.src = "./images/monster.png";


//03. Game Objects:
//nashiq geroi si ima koodrinati i burzina 
let hero = {
    speed: 5, // movement in pixels per second
    x: 0,
    y: 0
};

//monstera si ima samo koordinati, toi ne se dviji
let monster = {
    speed:3,
    x: 0,
    y: 0
};

//tuk pazim kolko monsteri sme hvanali
let monstersCaught = 0;


//04. Player input
//Pri natiskane na butonite da s edviji chovecheto
//kopchetata ot klavieturata prerdstavlqvat chisla !!!

//Polzvaiki keydown kogato natisnem dadeno kopche to vliza v tozi obekt sus stoinost 'true' !!!
let keysDown = {};
addEventListener("keydown", function (e) {
    keysDown[e.keyCode] = true;
});

//kogato otpusnem kopcheto to se trie ot obekta
addEventListener("keyup", function (e) {
    delete keysDown[e.keyCode];
});



//05.New Game   
//Reset the game when you catch a monster !

//Geroqt ni vinagi go puska v sredata na canvasa
let reset = function () {
    hero.x = canvas.width / 2;
    hero.y = canvas.height / 2;

    // monstera go puska nqkude random
    // Throw the monster somewhere on the screen randomly
    monster.x = 32 + (Math.random() * (canvas.width - 64));
    monster.y = 32 + (Math.random() * (canvas.height - 64));
};

function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}


//06.Update the objects
//Tuk proverqvame za natisnati kopcheta, vuv funkciqta update
//Shte mestim poziciqta na obektite kato shte gledame da ne izlizame ot kanvasa !!!
let update = function () {

    if (38 in keysDown && hero.y > 20) { // Player holding up, 38 e arrowUp
        hero.y -= hero.speed; //mestim nagore geroq s 5
    }
    if (40 in keysDown && hero.y < 420) { // Player holding down, 40 e arrowDown
        hero.y += hero.speed; //mestom go nadolo s 5, speed = 5
    } 
    if (37 in keysDown && hero.x > 30) { // Player holding left
        hero.x -= hero.speed; //mestim geroq na lqvo
    }
    if (39 in keysDown && hero.x < 450) { // Player holding right
        hero.x += hero.speed; //mestim geroq na dqsno
    }


    if(87 in keysDown)
    {
        if(monster.y <= 0)
            monster.y += 450;

        monster.y -= monster.speed;
    }
    if(83 in keysDown) 
    {
        if(monster.y >= 450)
            monster.y -= 450;

        monster.y += monster.speed;
    }
        
    if(65 in keysDown){
        if(monster.x <= 0)
            monster.x += 480;
        
        monster.x -= monster.speed;
    }
        
    if(68 in keysDown)
    {
        if(monster.x >= 480)
            monster.x -= 480;
        
        monster.x += monster.speed; 
    }   

    // Are they touching?
    //Tuk proverqvame dali se dokosvat
    //Ako se dokosvat uvelichavame promenlivata monstersCought i resetvame igrata !!!
    if (
        hero.x <= (monster.x + 32)
        && monster.x <= (hero.x + 32)
        && hero.y <= (monster.y + 32)
        && monster.y <= (hero.y + 32)
    ) {

        ++monstersCaught;
        reset();
    }
};


//07.Check if Images are loaded, then draw them
//Tazi funkciq proverqva dali vseki image e zareden,
//Ako edin image e zareden da go narisuva na canvasa
let render = function () {

    if (bgReady) {
        ctx.drawImage(bgImage, 0, 0);
    }

    if (heroReady) {
        ctx.drawImage(heroImage, hero.x, hero.y);
    }

    if (monsterReady) {
        ctx.drawImage(monsterImage, monster.x, monster.y);
    }

    //Tuk si izpisvame kolko monstera sme hvanali, gore v lqvo na kanvasa !!!
    // Score
    ctx.fillStyle = "rgb(250, 250, 250)";
    ctx.font = "12px Helvetica";
    ctx.textAlign = "left";
    ctx.textBaseline = "top";
    ctx.fillText("Monsters caught: " + monstersCaught, 32, 62);
    ctx.fillText("Hero controls: Up Down Left Right", 32, 32);
    ctx.fillText("Monster controls: W S A D", 342, 32);
 
 
    //KOGATO HERO PECHELI IGRATA
 if(monstersCaught == 5){

    ctx.fillStyle = "red";
    ctx.font = "50px Helvetica";
    ctx.fillText("Game Over!", 110, 200);
    ctx.fillText("Hero Won!", 120, 250);

    monsterReady = false;
    heroReady = false;

    document.getElementById('restartBtn')
    .style.display = 'block';

    document.getElementsByTagName('body')[0]
    .style.background = 'red';
}
};
    



//08.
let main = function () {
    update();
    render();
    requestAnimationFrame(main);
};

let w = window;
requestAnimationFrame = w.requestAnimationFrame || w.webkitRequestAnimationFrame || w.msRequestAnimationFrame || w.mozRequestAnimationFrame;

reset()
main()




 

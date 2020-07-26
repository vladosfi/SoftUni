; (function game() {
    const gameStartEl = document.getElementById('game-start');
    const gameScoreEl = document.getElementById('game-score');
    const gameSAreaEl = document.getElementById('game-area');
    const gameOverEl = document.getElementById('game-over');
    const wizard = document.getElementById('wizard');
    const pressedKeys = new Set();

    const gameplay ={
        loopId: null
    };

    function init() {
        wizard.style.top = '200px';
        wizard.style.left = '200px';
        wizard.classList.remove('hidden')
        gameLoop();
    }

    const pressedKeyActionMap = {
        ArrowUp(){},
        ArrowDown(){},
        ArrowLest(){},
        ArrowRight(){}
    }

    function processPressedKeys(){
        pressedKeys.forEach(pressedKey => {
            const handler = pressedKeyActionMap[pressedKey];
            if(handler){return;}
            handler();
        });
    }

    function gameLoop(){
        gameplay.loopId = window.requestAnimationFrame(gameLoop);
    }

    gameStartEl.addEventListener('click', function gameStartHandler() {
        gameStartEl.classList.add('hidden');
        init();
        onGameStart();
    });

    function onGameStart() {
        //alert('Game started');
    }


    document.addEventListener('keyup', function keyupHandler(e) {
        pressedKeys.delete(e.code);
    });
    
    document.addEventListener('keydown', function keydownHandler(e) {
        pressedKeys.add(e.code);
    });

}());
; (function game() {
    const gameStartEl = document.getElementById('game-start');
    const gameScoreValueEl = document.getElementById('score-value');
    const gameAreaEl = document.getElementById('game-area');
    const gameOverEl = document.getElementById('game-over');
    const wizardEl = document.getElementById('wizard');
    const pressedKeys = new Set();

    const config = {
        speed: 2,
        wizardMovingMultiplier: 4,
        fireballMovingMultiplier: 5,
        fireInterval: 1000,
        cloudSpanInterval: 3000
    };

    const utils = {
        pxToNumber(val) {
            return parseInt(val.replace('px', ''));
        },
        numberToPx(val) {
            return `${val}px`;
        },
        randomNumberBetween(min, max) {
            return Math.floor(Math.random() * max) + min;
        }
    };

    const scene = {
        get fireBalls() {
            return Array.from(document.querySelectorAll('.fire-ball'));
        },
        get clouds() {
            return Array.from(document.querySelectorAll('.cloud'));
        }
    };

    const wizardCoordinates = {
        wizard: wizardEl,
        set x(newX) {
            if (newX < 0) {
                newX = 0;
            } else if (newX + wizardEl.offsetWidth >= gameAreaEl.offsetWidth) {
                newX = gameAreaEl.offsetWidth - wizardEl.offsetWidth;
            }
            this.wizard.style.left = utils.numberToPx(newX);
        },
        get x() {
            return utils.pxToNumber(this.wizard.style.left);
        },
        set y(newY) {
            if (newY < 0) {
                newY = 0;
            } else if (newY + wizardEl.offsetHeight >= gameAreaEl.offsetHeight) {
                newY = gameAreaEl.offsetHeight - wizardEl.offsetHeight;
            }
            this.wizard.style.top = utils.numberToPx(newY);
        },
        get y() {
            return utils.pxToNumber(this.wizard.style.top);
        }
    };

    function createGamePlay() {
        return {
            loopId: null,
            nextRenderQueue: [],
            lastFireBallTimeStamp: 0,
            lastCloudSpanTimestamp: 0
        };
    }

    let gameplay;

    function init() {
        gameplay = createGamePlay();
        gameScoreValueEl.innerText = 0;
        wizardCoordinates.x = 200;
        wizardCoordinates.y = 200;
        wizardEl.classList.remove('hidden');
        gameLoop(0);
    }

    function addFireBall(x, y) {
        const fbe = document.createElement('div');
        fbe.classList.add('fire-ball');
        fbe.style.left = utils.numberToPx(x);
        fbe.style.top = utils.numberToPx(y);
        gameAreaEl.appendChild(fbe);
    }

    function addCloud(x, y) {
        const ce = document.createElement('div');
        ce.classList.add('cloud');
        ce.style.left = utils.numberToPx(x);
        ce.style.top = utils.numberToPx(y);
        gameAreaEl.appendChild(ce);
    }

    const pressedKeyActionMap = {
        ArrowUp() {
            wizardCoordinates.y -= config.speed * config.wizardMovingMultiplier;
        },
        ArrowDown() {
            wizardCoordinates.y += config.speed * config.wizardMovingMultiplier;;
        },
        ArrowLeft() {
            wizardCoordinates.x -= config.speed * config.wizardMovingMultiplier;;
        },
        ArrowRight() {
            wizardCoordinates.x += config.speed * config.wizardMovingMultiplier;;
        }
        ,
        Space(timestamp) {
            if (wizardEl.classList.contains('wizard-fire') ||
                timestamp - gameplay.lastFireBallTimeStamp < config.fireInterval
            ) { return; }

            addFireBall(wizardCoordinates.x + 50, wizardCoordinates.y);
            gameplay.lastFireBallTimeStamp = timestamp;
            wizardEl.classList.add('wizard-fire');
            gameplay.nextRenderQueue = gameplay.nextRenderQueue.concat(function clearWizardFire() {
                if (pressedKeys.has('Space')) { return false; }
                wizardEl.classList.remove('wizard-fire');
                return true;
            });
        }
    };

    function processFireBalls() {
        scene.fireBalls.forEach(fbe => {
            const newX = (config.speed * config.fireballMovingMultiplier) + utils.pxToNumber(fbe.style.left);
            if (newX + fbe.offsetWidth >= gameAreaEl.offsetWidth) {
                fbe.remove();
                return;
            }
            fbe.style.left = utils.numberToPx(newX);
        });
    }

    function processNextRenderQueue() {
        gameplay.nextRenderQueue = gameplay.nextRenderQueue.reduce((acc, currFn) => {
            if (currFn()) { return acc; }

            return acc.concat(currFn);
        }, []);
    }

    function processPressedKeys(timestamp) {
        pressedKeys.forEach(pressedKey => {
            const handler = pressedKeyActionMap[pressedKey];
            if (handler) { handler(timestamp); }
        });
    }

    function processClouds(timestamp) {
        if (timestamp - gameplay.lastCloudSpanTimestamp > config.cloudSpanInterval ) {
            const x = gameAreaEl.offsetWidth - 200;
            const y = utils.randomNumberBetween(0, gameAreaEl.offsetHeight - 200);
            addCloud(x, y);
            gameplay.lastCloudSpanTimestamp = timestamp;
        }
        scene.clouds.forEach(ce => {
            const newX = utils.pxToNumber(ce.style.left) - config.speed;
            if(newX + 200 < 0){
                ce.remove();
            }
            ce.style.left = utils.numberToPx(newX);
        });
    }

    function applyGravity() {
        const isInAir = wizardCoordinates.y != gameAreaEl.offsetHeight;

        if (isInAir) { wizardCoordinates.y += config.speed; }
    }

    function gameLoop(timestamp) {
        gameplay.loopId = window.requestAnimationFrame(gameLoop);
        processPressedKeys(timestamp);
        applyGravity(timestamp);
        processNextRenderQueue(timestamp);
        processFireBalls(timestamp);
        processClouds(timestamp);
        gameScoreValueEl.innerText++;
    }

    gameStartEl.addEventListener('click', function gameStartHandler() {
        gameStartEl.classList.add('hidden');
        init();
        onGameStart();
    });

    function onGameStart() {
        //alert('Game started');
    }


    document.addEventListener('keyup', function keyupHandler(e) { pressedKeys.delete(e.code); });
    document.addEventListener('keydown', function keydownHandler(e) { pressedKeys.add(e.code); });

}());
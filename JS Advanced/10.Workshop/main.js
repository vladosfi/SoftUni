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
        fireInterval: 300,
        cloudSpanInterval: 3000,
        bugSpanInterval: 5000,
        bugKillScore: 2000
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
        },
        hasCollision(el1, el2) {
            const el1Rect = el1.getBoundingClientRect();
            const el2Rect = el2.getBoundingClientRect();

            return !(
                el1Rect.top > el2Rect.bottom ||
                el1Rect.bottom < el2Rect.top ||
                el1Rect.right < el2Rect.left ||
                el1Rect.left > el2Rect.right
            );
        }
    };

    const scene = {
        get fireBalls() {
            return Array.from(document.querySelectorAll('.fire-ball'));
        },
        get clouds() {
            return Array.from(document.querySelectorAll('.cloud'));
        },
        get bugs() {
            return Array.from(document.querySelectorAll('.bug'));
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
            lastCloudSpanTimestamp: 0,
            lastBugSpanTimestamp: 0
        };
    }

    let gameplay;

    function init() {
        gameplay = createGamePlay();
        gameScoreValueEl.innerText = 0;
        wizardCoordinates.x = 200;
        wizardCoordinates.y = 200;
        wizardEl.classList.remove('hidden');
        gameOverEl.classList.add('hidden');
        gameLoop(0);
    }

    function gameOver() {
        window.cancelAnimationFrame(gameplay.loopId);
        gameOverEl.classList.remove('hidden');
        gameStartEl.classList.remove('hidden');
    }

    // function addFireBall(x, y) {
    //     const fbe = document.createElement('div');
    //     fbe.classList.add('fire-ball');
    //     fbe.style.left = utils.numberToPx(x);
    //     fbe.style.top = utils.numberToPx(y);
    //     gameAreaEl.appendChild(fbe);
    // }

    // function addCloud(x, y) {
    //     const ce = document.createElement('div');
    //     ce.classList.add('cloud');
    //     ce.style.left = utils.numberToPx(x);
    //     ce.style.top = utils.numberToPx(y);
    //     gameAreaEl.appendChild(ce);
    // }

    function addGameElementFactory(className) {
        return function addElement(x, y,) {
            const e = document.createElement('div');
            e.classList.add(className);
            e.style.left = utils.numberToPx(x);
            e.style.top = utils.numberToPx(y);
            gameAreaEl.appendChild(e);
        };
    }

    const addFireBall = addGameElementFactory('fire-ball');
    const addCloud = addGameElementFactory('cloud');
    const addBug = addGameElementFactory('bug');

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


    const processClouds = processGameElementFactory(addCloud, 200, 'lastCloudSpanTimestamp', 'clouds', 'cloudSpanInterval');
    const processBugs = processGameElementFactory(addBug, 60, 'lastBugSpanTimestamp', 'bugs', 'bugSpanInterval', bugElementProcessor);

    function bugElementProcessor(bugEl) {
        const fireball = scene.fireBalls.find(fe => utils.hasCollision(fe, bugEl));
        if (fireball) {
            bugEl.remove();
            fireball.remove();
            gameScoreValueEl.innerHTML = config.bugKillScore + parseInt(gameScoreValueEl.innerHTML);
            return true;
        };
        if (utils.hasCollision(bugEl, wizardEl)) {
            gameOver();
            return true;
        }
        return false;
    }

    function processGameElementFactory(
        addFn,
        elementWidth,
        gameplayTimestampName,
        sceneName,
        configName,
        additionalElementProcessor
    ) {
        return function (timestamp) {
            if (timestamp - gameplay[gameplayTimestampName] > config[configName]) {
                const x = gameAreaEl.offsetWidth - elementWidth;
                const y = utils.randomNumberBetween(0, gameAreaEl.offsetHeight - 200);
                addFn(x, y);
                gameplay[gameplayTimestampName] = timestamp;
            }
            scene[sceneName].forEach(ce => {
                const newX = utils.pxToNumber(ce.style.left) - config.speed;
                if (additionalElementProcessor && additionalElementProcessor(ce)) { return; }
                if (newX + 200 < 0) {
                    ce.remove();
                }
                ce.style.left = utils.numberToPx(newX);
            });
        }
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
        processBugs(timestamp);
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
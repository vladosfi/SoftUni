import monkeys from './monkeys.js';

window.addEventListener('load', async () => {
    const rootEl = document.querySelector('section');

    // Зареждане на темплейт -> текст
    const templateStr = await (await fetch('./main-template.hbs')).text();
    Handlebars.registerPartial('monkey', await (await fetch('./monkey.hbs')).text());

    // компилиране на темплейта -> функция 
    const templateFn = Handlebars.compile(templateStr);

    // изпълнение на темплейта с нашите данни (променливи) -> текст (HTML)
    const generatedHTML = templateFn({ monkeys });

    // поставяне на генерирания HTML в DOM
    rootEl.innerHTML = generatedHTML;

    //set up iteraction
    rootEl.addEventListener('click', onClick);

    function onClick(e) {
        if (e.target.tagName !== 'BUTTON') { return; }

        const pEl = e.target.parentNode.querySelector('p');

        if (pEl.style && pEl.style.display == 'none') {
            pEl.style.removeProperty('display');
        } else {
            pEl.style.display = 'none';
        }
    }

});


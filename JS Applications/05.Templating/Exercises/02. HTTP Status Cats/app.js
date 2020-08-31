window.addEventListener('load', async () => {
    const rootEl = document.querySelector('#allCats');

    // Зареждане на темплейт -> текст
    const templateStr = await (await fetch('./main-template.hbs')).text();
    Handlebars.registerPartial('cat', await (await fetch('./cat-template.hbs')).text());

    // компилиране на темплейта -> функция 
    const templateFn = Handlebars.compile(templateStr);

    // изпълнение на темплейта с нашите данни (променливи) -> текст (HTML)
    const generatedHTML = templateFn({ cats });

    // поставяне на генерирания HTML в DOM
    rootEl.innerHTML = generatedHTML;

    //set up iteraction
    rootEl.addEventListener('click', onClick);

    function onClick(e) {
        if (e.target.tagName !== 'BUTTON') { return; }

        const div = e.target.parentNode.querySelector('.status');

        if (div.style && div.style.display == 'none') {
            div.style.removeProperty('display');
            e.target.textContent = 'Hide status code';
        } else {
            div.style.display = 'none';
            e.target.textContent = 'Show status code';
        }
    }
});
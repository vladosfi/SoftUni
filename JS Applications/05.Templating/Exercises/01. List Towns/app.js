/*globals Handlebars*/
window.addEventListener('load',async () => {
    // Зареждане на темплейт -> текст
    const templateStr = await (await fetch('./main-template.hbs')).text();
    Handlebars.registerPartial('town', await(await(fetch('./town-template.hbs'))).text());
    
    // компилиране на темплейта -> функция 
    const templateFn = Handlebars.compile(templateStr); 

    document.querySelector('#btnLoadTowns').addEventListener('click', renderTowns);
    const input = document.querySelector('#towns');
    const rootEl = document.querySelector('#root');

    function renderTowns(e) {
        e.preventDefault();
        const towns = input.value.split(', ');

        // изпълнение на темплейта с нашите данни (променливи) -> текст (HTML)
        const generatedHTML = templateFn({ towns });
        console.log(generatedHTML);
        // поставяне на генерирания HTML в DOM
        rootEl.innerHTML = generatedHTML;
    }
});
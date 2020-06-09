function solve() {
    document.querySelector('button').addEventListener('click', onClick);
    const list = {};

    const items = document.querySelector('ol').querySelectorAll('li');
    [...items].forEach(e => {
        if (e.textContent.trim().length === 0) {
            return;
        }
        const letter = e.textContent[0].toLocaleUpperCase();
        list[letter] = e.textContent;
    })

    function onClick() {
        const input = document.querySelector('input');
        const letter = input.value.charAt(0).toLocaleUpperCase();
        const inputName = letter + input.value.slice(1).toLocaleLowerCase();

        if (list.hasOwnProperty(letter) === false) {
            list[letter] = inputName;
            console.log(list[letter]);
        } else {
            list[letter] =  list[letter] + ', ' + inputName;
            console.log(list[letter]);
        }        

        const index = letter.charCodeAt(0) - 65;
        items[index].textContent = list[letter];
        input.value = '';
    }
}
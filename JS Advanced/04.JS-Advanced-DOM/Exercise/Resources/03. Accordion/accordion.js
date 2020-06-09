function toggle() {
    const button = document.getElementsByClassName('button')[0];
    const divContent = document.querySelector('#extra');

    if (button.textContent === 'More') {
        button.textContent = 'Less';
        divContent.style.display = 'block';
    } else {
        button.textContent = 'More';
        divContent.style.display = 'none';
    }
}
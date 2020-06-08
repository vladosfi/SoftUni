function toggle() {
    let button = document.getElementsByClassName('button')[0];
        let divElement = document.getElementById('extra');

        if(button.textContent === 'More'){
            button.textContent = 'Less';
            divElement.style.display = 'block';
        }else if(button.textContent === 'Less'){
            button.textContent = 'More';
            divElement.style.display = 'none';
        }
}
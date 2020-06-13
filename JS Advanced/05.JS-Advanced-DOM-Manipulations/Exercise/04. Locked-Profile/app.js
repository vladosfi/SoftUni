function lockedProfile() {
    document.querySelector('#main').addEventListener('click', onClick);

    function onClick(e) {
        if (e.target.nodeName === 'BUTTON') {
            const btn = e.target;

            const isUnlocked = e.target.parentNode.querySelector('input[type="radio"][value="unlock"]');
            const contentDiv = [...e.target.parentNode.querySelectorAll('div')].filter(d=>d.id.includes('HiddenFields'))[0] ;
            
            if (isUnlocked.checked !== true) { return; }

            if (contentDiv.style.display !== 'block') {
                contentDiv.style.display = 'block';
                btn.textContent = 'Hide it';
            } else {
                contentDiv.style.display = 'none';
                btn.textContent = 'Show more';
            }
        }
    }
}
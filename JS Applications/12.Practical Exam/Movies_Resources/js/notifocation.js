const elements = {};

export function showInfo(message) {
    elements.info = document.querySelector('#successBox'),
    elements.info.addEventListener('click', hideInfo);
    elements.info.textContent = message;
    elements.info.parentElement.style.display = 'block';
    setTimeout(hideInfo, 3000);
}

export function showError(message) {
    elements.error = document.querySelector('#errorBox'),
    elements.error.addEventListener('click', hideError);
    elements.error.textContent = message;
    elements.error.parentElement.style.display = 'block';
}

function hideInfo() {
    elements.info.parentElement.style.display = 'none';
    elements.info.removeEventListener('click', hideInfo);
}

function hideError() {
    elements.error.parentElement.style.display = 'none';
    elements.error.removeEventListener('click', hideError);
}
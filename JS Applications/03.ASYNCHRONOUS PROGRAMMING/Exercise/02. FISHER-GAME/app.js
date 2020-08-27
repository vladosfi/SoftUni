import * as api from './data.js';
import el from './dom.js';

const mainDiv = document.querySelector('#catches');


function attachEvents() {
    const loadBtnEl = document.querySelector('button.load');
    loadBtnEl.addEventListener('click', loadEntries);
    const addBtnEl = document.querySelector('button.add');
    addBtnEl.addEventListener('click', addEntry);
}

async function addEntry() {
    const anglerEl = document.querySelector('aside .angler');
    const weightEl = document.querySelector('aside .weight');
    const speciesEl = document.querySelector('aside .species');
    const locationEl = document.querySelector('aside .location');
    const baitEl = document.querySelector('aside .bait');
    const captureTimeEl = document.querySelector('aside .captureTime');

    const { value: angler } = anglerEl;
    const { value: weight } = weightEl;
    const { value: species } = speciesEl;
    const { value: location } = locationEl;
    const { value: bait } = baitEl;
    const { value: captureTime } = captureTimeEl;

    const data = await api.createEntry({ angler, weight, species, location, bait, captureTime });

}

async function loadEntries() {
    const data = await api.getData();
    console.log(data);
    mainDiv.innerHTML = '';

    Object.entries(data).forEach(([id, entry]) => {
        renderEntries(id, entry);
    });
}

async function renderEntries(id, entrie) {
    const angler = el('input', '', { 'type': "text", className: 'angler' });
    angler.setAttribute('value', entrie.angler);
    const weight = el('input', '', { 'type': "text", className: 'weight' });
    weight.setAttribute('value', entrie.weight);
    const species = el('input', '', { 'type': "text", className: 'species' });
    species.setAttribute('value', entrie.species);
    const location = el('input', '', { 'type': "text", className: 'location' });
    location.setAttribute('value', entrie.location);
    const bait = el('input', '', { 'type': "text", className: 'bait' });
    bait.setAttribute('value', entrie.bait);
    const captureTime = el('input', '', { 'type': "text", className: 'captureTime' });
    captureTime.setAttribute('value', entrie.captureTime);

    const deleteBtnEl = el('button', 'Delete', { className: 'delete' });
    deleteBtnEl.addEventListener('click', deleteEntry);
    const updateBtnEl = el('button', 'Update', { className: 'update' });
    updateBtnEl.addEventListener('click', updateEntry);

    const divEl = el('div', [
        el('label', 'Angler'),
        angler,
        el('hr', ''),
        el('label', 'Weight'),
        weight,
        el('hr', ''),
        el('label', 'Species'),
        species,
        el('hr', ''),
        el('label', 'Location'),
        location,
        el('hr', ''),
        el('label', 'Bait'),
        bait,
        el('hr', ''),
        el('label', 'Capture Time'),
        captureTime,
        el('hr', ''),
        deleteBtnEl,
        updateBtnEl,
    ], { className: 'catch' });

    divEl.setAttribute('data-id', id);
    mainDiv.appendChild(divEl);

    async function deleteEntry() {
        const id = this.parentElement.getAttribute('data-id');
        const result = await api.deleteEntry(id);
    }

    async function updateEntry() {
        const anglerEl = this.parentElement.querySelector('.angler');
        const weightEl = this.parentElement.querySelector('.weight');
        const speciesEl = this.parentElement.querySelector('.species');
        const locationEl = this.parentElement.querySelector('.location');
        const baitEl = this.parentElement.querySelector('.bait');
        const captureTimeEl = this.parentElement.querySelector('.captureTime');

        const { value: angler } = anglerEl;
        const { value: weight } = weightEl;
        const { value: species } = speciesEl;
        const { value: location } = locationEl;
        const { value: bait } = baitEl;
        const { value: captureTime } = captureTimeEl;

        const id = this.parentElement.getAttribute('data-id');
        const result = await api.updateEntry(id,{ angler, weight, species, location, bait, captureTime });
    }
}

attachEvents();


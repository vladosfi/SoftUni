import * as api from './data.js';

function attachEvents() {
    // const baseURL = 'http://localhost:8000/phonebook';

    const elements = {
        person() { return document.querySelector('input#person') },
        phone() { return document.querySelector('input#phone') },
        createContact() { return document.querySelector('button#btnCreate') },
        loadContact() { return document.querySelector('button#btnLoad') },
        phonebookUl() { return document.querySelector('ul#phonebook') },
    }

    elements.createContact().addEventListener('click', createElement);

    elements.loadContact().addEventListener('click', loadPhoneBook);

    async function createElement() {
        const { value: person } = elements.person();
        const { value: phone } = elements.phone();

        await api.createEntry({ person, phone })

        elements.person().value = '';
        elements.phone().value = '';
    }

    async function loadPhoneBook() {
        const data = await api.getData();

        elements.phonebookUl().innerHTML = '';
        for (const [key, value] of Object.entries(data)) {

            const btnDelete = document.createElement('button');
            btnDelete.textContent = 'Delete';
            btnDelete.value = key;
            btnDelete.addEventListener('click', deleteRecord);

            const listItem = document.createElement('li');
            listItem.textContent = `${value.person}: ${value.phone}`;
            listItem.appendChild(btnDelete);

            elements.phonebookUl().appendChild(listItem);
        }

        async function deleteRecord() {
            try {
                //disable button 
                this.textContent = 'Please wait...';
                this.disabled = true;
                await api.deleteData(this.value);
                this.parentElement.remove();
            } catch (err) {
                this.textContent = 'Delete';
                this.disabled = false;
                alert(err);
                console.error(err.message);
            }
        }
    }
}

attachEvents();

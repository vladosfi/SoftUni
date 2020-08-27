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

    elements.createContact().addEventListener('click', addContact);

    elements.loadContact().addEventListener('click', loadPhoneBook);

    async function addContact() {
        const { value: person } = elements.person();
        const { value: phone } = elements.phone();

        const result = await api.createEntry({ person, phone })

        elements.person().value = '';
        elements.phone().value = '';

        const id = Object.keys(result)[0];
        createElement(result, result[id]);
    }

    async function loadPhoneBook() {
        const data = await api.getData();

        elements.phonebookUl().innerHTML = '';
        Object.entries(data).forEach(([id, entry]) => {
            createElement(id, entry);
        });
    }

    function createElement(id, entry) {
        const btnDelete = document.createElement('button');
        btnDelete.textContent = 'Delete';
        btnDelete.value = id;
        btnDelete.addEventListener('click', deleteRecord);

        const listItem = document.createElement('li');
        listItem.textContent = `${entry.person}: ${entry.phone}`;
        listItem.appendChild(btnDelete);

        elements.phonebookUl().appendChild(listItem);

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

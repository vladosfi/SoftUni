function attachEvents() {
    const baseURL = 'http://localhost:8000/phonebook';

    const elements = {
        person() { return document.querySelector('input#person') },
        phone() { return document.querySelector('input#phone') },
        createContact() { return document.querySelector('button#btnCreate') },
        loadContact() { return document.querySelector('button#btnLoad') },
        phonebookUl() { return document.querySelector('ul#phonebook') },
    }

    elements.createContact().addEventListener('click', () => {
        const { value: person } = elements.person();
        const { value: phone } = elements.phone();

        fetch(baseURL, {
            method: "POST",
            body: JSON.stringify({ person, phone })
        })
            .then(response => response.json())
            .then(response => console.log(response));

        elements.person().value = '';
        elements.phone().value = '';
    });

    elements.loadContact().addEventListener('click', () => {
        fetch(baseURL)
            .then(response => response.json())
            .then(response => loadPhoneBook(response));

        function loadPhoneBook(data) {
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
        }

        function deleteRecord() {
            fetch(baseURL + `/${this.value}`, {
                method: 'DELETE',
            })
                .then(response => response.json())
                .then(response => console.log(response));
        }
    });
}

attachEvents();

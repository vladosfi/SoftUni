function solve() {
    const containerEl = document.querySelector('#container');
    const movieSection = document.querySelector('#movies > ul');
    const archiveSection = document.querySelector('#archive > ul');
    const inputs = containerEl.querySelectorAll('input');
    const inputName = inputs[0];
    const inputHall = inputs[1];
    const inputPrice = inputs[2];
    const onScreenBtn = containerEl.querySelector('button');

    onScreenBtn.addEventListener('click', addMovie);
    const brnClearArchive = document.querySelector('#archive > button');

    brnClearArchive.addEventListener('click', () => {
        archiveSection.innerHTML = '';
    });

    function addMovie(e) {
        e.preventDefault();

        const name = inputName.value;
        const hall = inputHall.value;
        const price = Number(inputPrice.value).toFixed(2);

        if (name.length > 0 && hall.length > 0) {

            if (!Number(inputPrice.value)) {
                return;
            }

            inputName.value = '';
            inputHall.value = '';
            inputPrice.value = '';

            const buttonArchive = el('button', 'Archive');
            const ticketSoldField = el('input', '', { placeholder: 'Tickets Sold' });

            const movie = el('li', [
                el('span', name),
                el('strong', `Hall: ${hall}`),
                el('div', [
                    el('strong', price),
                    ticketSoldField,
                    buttonArchive
                ])
            ]);

            movieSection.appendChild(movie);

            buttonArchive.addEventListener('click', () => {

                if (Number(ticketSoldField.value)) {
                    const totalProfit = (Number(ticketSoldField.value) * price).toFixed(2);
                    const buttonDelete = el('button', 'Delete');
                    movie.remove();

                    const archivedMovie = el('li', [
                        el('span', name),
                        el('strong', `Total amount: ${totalProfit}`),
                        buttonDelete
                    ]);

                    archiveSection.appendChild(archivedMovie);

                    buttonDelete.addEventListener('click', () => {
                        archivedMovie.remove();
                    });
                }
            });
        }
    }


    function el(type, content, attributes) {
        const result = document.createElement(type);

        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }

        if (Array.isArray(content)) {
            content.forEach(append);
        } else {
            append(content);
        }

        function append(node) {
            if (typeof node === 'string' || typeof node === 'number') {
                node = document.createTextNode(node);
            }
            result.appendChild(node);
        }

        return result;
    }

}
function solve() {
    const inputContainer = document.querySelector('#container').childNodes;
    const inputName = inputContainer.item(1);
    const inputAge = inputContainer.item(3);
    const inputKind = inputContainer.item(5);
    const inputCurrentOwner = inputContainer.item(7);
    const adoptionList = document.querySelector('#adoption > ul');
    const adoptedList = document.querySelector('#adopted > ul');

    document.querySelector('#container > button').addEventListener('click', addPet);

    function addPet(e) {
        e.preventDefault();

        const petName = inputName.value.trim();
        const petAge = Number(inputAge.value.trim());
        const petKind = inputKind.value.trim();
        const inputPetOwner = inputCurrentOwner.value.trim();
        const contactBtn = el('button', 'Contact with owner');
        const buttonTakeIt = el('button', 'Yes! I take it!');

        const nameContainer = el('div', [
            el('input', '', { placeholder: 'Enter your names' }),
            buttonTakeIt
        ]);

        if (petName.length > 0 && petKind.length > 0 && inputPetOwner.length > 0 && !isNaN(petAge)) {
            const currentPetOwner = el('span', `Owner: ${inputPetOwner}`);
            const newPet = el('li', [
                el('p', [
                    el('strong', `${petName}`),
                    ' is a ',
                    el('strong', `${petAge}`),
                    ' year old ',
                    el('strong', petKind),
                ]),
                currentPetOwner,
                contactBtn
            ]);

            adoptionList.appendChild(newPet);

            contactBtn.addEventListener('click', (e) => {
                contactBtn.remove();
                newPet.appendChild(nameContainer);

                buttonTakeIt.addEventListener('click', (e) => {
                    const newOwner = nameContainer.querySelector('div > input');

                    if (newOwner.value.length > 0) {
                        currentPetOwner.textContent = 'New Owner: ' + newOwner.value;
                        newOwner.remove();
                        nameContainer.remove();
                        const buttonChecked = el('button', 'Checked');
                        adoptedList.appendChild(newPet);
                        newPet.appendChild(buttonChecked);

                        buttonChecked.addEventListener('click', (e) => { newPet.remove(); });
                    }
                });
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


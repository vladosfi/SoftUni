function attachEvents() {
    const baseUrl = 'http://localhost:8000/messenger';

    const elements = {
        author() { return document.querySelector('#author') },
        content() { return document.querySelector('#content') },
        submitBtn() { return document.querySelector('#submit') },
        refreshBtn() { return document.querySelector('#refresh') },
        messages() { return document.querySelector('#messages') },
    };

    elements.submitBtn().addEventListener('click', () => {
        const { value: author } = elements.author();
        const { value: content } = elements.content();

        fetch(baseUrl, {
            method: "POST",
            body: JSON.stringify({ author, content })
        })
            .then(response => response.json())
            .then(response => console.log(response));

        elements.author().value = '';
        elements.content().value = '';
    });

    elements.refreshBtn().addEventListener('click', () => {
        elements.messages().value = '';
        fetch(baseUrl)
            .then(response => response.json())
            .then(response => {
                for (const [key, value] of Object.entries(response)) {
                    const msg = `${value.author}: ${value.content}\n`;
                    elements.messages().value += msg;
                }

                // for(const el in response){
                //     console.log(response[el].author);
                // };
            });
    })

}

attachEvents();
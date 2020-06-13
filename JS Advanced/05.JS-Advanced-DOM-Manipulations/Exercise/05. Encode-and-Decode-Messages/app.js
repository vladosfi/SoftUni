function encodeAndDecodeMessages() {
    document.querySelector('main').addEventListener('click', onClick);
    const textArias = [...document.querySelectorAll('main div textarea')];

    function onClick(e) {
        const element = e.target;

        if (element.nodeName === 'BUTTON') {
            if (element.textContent === 'Encode and send it') {
                let messageToSend = textArias[0] //element.parentNode.querySelector('textarea');
                let encodedTexBox = textArias[1];
                encodedTexBox.value = encode(messageToSend.value);
                messageToSend.value = '';
            } else {
                let encodedTexBox = textArias[1];
                encodedTexBox.value = decode(encodedTexBox.value);
            }
        }
    }

    function encode(message) {
        let result = '';

        for (let index = 0; index < message.length; index++) {
            result += String.fromCharCode(message.charCodeAt(index) + 1);
        }
        return result;
    }

    function decode(message) {
        let result = '';

        for (let index = 0; index < message.length; index++) {
            result += String.fromCharCode(message.charCodeAt(index) - 1);
        }
        return result;
    }
}
function solve() {
    const binaryOption = document.createElement("option");
    binaryOption.textContent = 'Binary';
    binaryOption.value = 'binary';
    const hexOption = document.createElement("option");
    hexOption.textContent = 'Hexadecimal';
    hexOption.value = 'hexadecimal';
    const select = document.querySelector('#selectMenuTo');
    select.appendChild(binaryOption);
    select.appendChild(hexOption);


    document.querySelector('button').addEventListener('click', e => {
        let input = document.querySelector('#input');
        let num = Number(input.value);
        let result = document.querySelector('#result');
        e = document.querySelector('#selectMenuTo');
        selectedOption = e.options[e.selectedIndex].text;

        if (selectedOption === 'Binary') {
            result.value = convertToBinary(num);
        } else if(selectedOption === 'Hexadecimal'){
            result.value = convertToHex(num);
        }
    });

    function convertToBinary(num) {
        return num.toString(2);
    }

    function convertToHex(num) {
        return num.toString(16).toUpperCase();
    }

}

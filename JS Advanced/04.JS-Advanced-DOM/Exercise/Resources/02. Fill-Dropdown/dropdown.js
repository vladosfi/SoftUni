function addItem() {
    const textInput = document.querySelector('#newItemText');
    const textValue = document.querySelector('#newItemValue');
    const itemText = textInput.value;
    const itemValue = textValue.value;

    const option = document.createElement('option');
    option.value = itemValue;
    option.textContent = itemText;

    document.querySelector('#menu').appendChild(option);

    textInput.value = '';
    textValue.value = '';
}
function addRemoveelement(arr) {
    let val = 0;
    const resultArr = [];

    for (let index = 0; index < arr.length; index++) {
        val++;
        switch (arr[index]) {
            case 'add':
                resultArr.push(val);
                break;
            case 'remove':
                resultArr.pop();
                break;
        }
    }
    return resultArr.length === 0 ? 'Empty' : resultArr.join('\n')
}

console.log(addRemoveelement(['add', 'add', 'add', 'add']));
console.log(addRemoveelement(['add', 'add', 'remove', 'add', 'add']));
console.log(addRemoveelement(['remove', 'remove', 'remove']));



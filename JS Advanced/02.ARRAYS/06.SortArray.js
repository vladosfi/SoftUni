function sortByLenAndAlpha(array) {
    console.log(array.sort(sortByAscending).join('\n'));

    function sortByAscending(a, b) {
        const result = a.length - b.length;
        if (result < 0) {
            return -1;
        }
        else if (result > 0) {
            return 1;
        }

        let nameA = a.toUpperCase();
        let nameB = b.toUpperCase();
        if (nameA < nameB) { return -1; }
        if (nameA > nameB) { return 1; }
        return 0;
    }
}

function sortShort(arr) {
    console.log(arr.sort((a, b) => a.length - b.length || a.toUpperCase().localeCompare(b.toUpperCase())).join('\n'));
}

sortShort(['alpha', 'beta', 'gamma']);
sortShort(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortShort(['test', 'Deny', 'omen', 'Default']);

sortByLenAndAlpha(['alpha', 'beta', 'gamma']);
sortByLenAndAlpha(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortByLenAndAlpha(['test', 'Deny', 'omen', 'Default']);
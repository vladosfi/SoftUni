function solve() {
    const list = [];

    const instance = {
        add,
        remove,
        get,
        size: 0
    };

    function add(element) {
        list.push(element);
        list.sort(comparator);
        instance.size++;
        return instance;
    }

    function remove(index) {
        _validate(index);
        list.splice(index, 1);
        instance.size--;
        return instance;
    }

    function get(index) {
        _validate(index);
        return list[index];
    }

    function _validate(index) {
        if (index < 0 || index >= list.length) {
            throw new Error('Index is out of bounds');
        }
    }

    function comparator(a, b) {
        return a - b;
    }

    return instance;
}

let myList = solve();
myList.get(0);


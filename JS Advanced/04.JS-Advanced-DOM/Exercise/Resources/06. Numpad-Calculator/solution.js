function solve() {
    const expr = document.querySelector('#expressionOutput');
    const output = document.querySelector('#resultOutput');

    document.querySelector('.clear').addEventListener('click', e => {
        mem.first = '';
        mem.operator = '';
        mem.second = '';
        expr.textContent = '';
        output.textContent = '';
    });

    [...document.querySelector('div.keys').querySelectorAll('button')].forEach(b => {
        b.addEventListener('click', onClick);
    })

    const mem = {
        first: '',
        second: '',
        operator: ''
    };

    const operators = {
        '+': () => Number(mem.first) + Number(mem.second),
        '-': () => Number(mem.first) - Number(mem.second),
        '*': () => Number(mem.first) * Number(mem.second),
        '/': () => Number(mem.first) / Number(mem.second),
        '=': true,
    };

    function onClick(e) {
        const val = e.target.value;
        const num = Number.parseInt(val)
        let isNan = false;

        if (operators.hasOwnProperty(val)) {
            if (Number(mem.first) && mem.second === '' && mem.operator !== '' && val === '=') {
                isNan = true;
            } else if (val === '=') {
                output.textContent = operators[mem.operator]();
            } else {
                mem.operator = val;
            }
        } else {
            if (mem.operator === '') {
                mem.first += val;
            } else {
                mem.second += val;
            }
        }
        if (isNan) {
            output.textContent = "NaN";
        } else {
            expr.textContent = `${mem.first} ${mem.operator} ${mem.second}`;
        }
    }
}
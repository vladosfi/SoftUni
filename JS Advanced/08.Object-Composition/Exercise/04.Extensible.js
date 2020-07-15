function solve() {
    // създаваме обект със зададен прототип
    const proto = {};

    const instance = Object.create(proto);

    // дефинираме функция, копираща свойства и методи
    instance.extend = function (template) {
        // обхождаме шаблона
        for (let prop in template) {
            if (typeof template[prop] === 'function') {
                // ако е функция, копираме върху прототипа
                proto[prop] = template[prop];
            } else {
                // иначе копираме върху инстанцията
                instance[prop] = template[prop];
            }
        }
    };

    return instance;
}

const myInstance = solve();

myInstance.extend({
    extensionMethod: function () { /* do something */ },
    extensionProperty: 'someString'
});

console.log('instance props:', myInstance);
console.log('prototype props: ', Object.getPrototypeOf(myInstance));
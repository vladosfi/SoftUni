class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return '0x' + this.value.toString(16).toUpperCase();
    }

    /**
     * Add to current value
     * @param{Hex} hex Hex number to add to current
     */
    plus(hex) {
        return new Hex(this.value + hex);
    }

    /**
     * Subtract from current value
     * @param{Hex} hex Hex number to subtract from current
     */
    minus(hex) {
        return new Hex(this.value - hex);
    }

    static parse(hexValue) {
        return parseInt(hexValue, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');

let test = new Hex(255);
console.log(Hex.parse(test));

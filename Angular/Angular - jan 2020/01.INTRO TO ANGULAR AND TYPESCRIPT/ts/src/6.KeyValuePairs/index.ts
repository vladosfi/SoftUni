class KeyValuePair<T, U>{
    private _key: T;
    private _value: U;

    setKeyValue(key: T, value: U) {
        this._key = key;
        this._value = value;
    }

    display(): void {
        console.log(`key = ${this._key}, value = ${this._value}`);
    }
}

let kvp = new KeyValuePair<number, string>();
kvp.setKeyValue(1, "Steve");
kvp.display();

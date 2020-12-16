var KeyValuePair = /** @class */ (function () {
    function KeyValuePair() {
    }
    KeyValuePair.prototype.setKeyValue = function (key, value) {
        this._key = key;
        this._value = value;
    };
    KeyValuePair.prototype.display = function () {
        console.log("key = " + this._key + ", value = " + this._value);
    };
    return KeyValuePair;
}());
var kvp = new KeyValuePair();
kvp.setKeyValue(1, "Steve");
kvp.display();

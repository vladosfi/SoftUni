const StringBuilder = require('./string-builder.js');
const expect = require('chai').expect;

describe('check string builder object constructor', () => {
    it('should return correct object instance of StringBuilder', () => {
        let result = new StringBuilder();
        expect(result.constructor.name).to.equal('StringBuilder');
    });
    it('should be instantiated without arguments', () => {
        let result = new StringBuilder();
        expect(result._stringArray.length).to.equal(0);
    });
    it('should be instantiated with string argument', () => {
        let result = new StringBuilder('tst');
        expect(result._stringArray.length).to.equal(3);
    });
});

describe('check functionality of object', () => {
    it('should append string to array at the end', () => {
        let result = new StringBuilder('tst');
        result.append('-123');
        expect(result.toString()).to.equal('tst-123');
    });

    it('should prepend string to array at the beginning', () => {
        let result = new StringBuilder('tst');
        result.prepend('123-');
        expect(result.toString()).to.equal('123-tst');
    });

    it('should insert string to array at the given index', () => {
        let result = new StringBuilder('tst');
        result.insertAt('123', 1);
        expect(result.toString()).to.equal('t123st');
    });

    it('should remove elements from array at the given start index and lenght', () => {
        let result = new StringBuilder('tst');
        result.remove(1, 2);
        expect(result.toString()).to.equal('t');
    });

    it('should returns a string with all elements joined by an empty string', () => {
        let result = new StringBuilder('tst');
        expect(result.toString()).to.equal('tst');
    });

    it('should throws a type error', () => {
        let result = new StringBuilder();
        expect(function () {
            result.append(2);
        }).to.throw(TypeError, 'Argument must be string');
        expect(function () {
            result.prepend(2);
        }).to.throw(TypeError, 'Argument must be string');
        expect(function () {
            result.insertAt(2,2);
        }).to.throw(TypeError, 'Argument must be string');
    });
});
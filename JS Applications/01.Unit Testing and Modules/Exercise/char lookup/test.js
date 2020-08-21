const lookupChar = require('./app.js');
const expect = require('chai').expect;

describe('Char Lookup Tests', () => {
    const testString = 'string';

    it('shuld return undefined if string parameter is not of type string', () => {
        expect(lookupChar(12, 1)).to.equal(undefined);
    });

    it('shuld return undefined if integer parameter is not of type integer', () => {
        expect(lookupChar('', 'ind')).to.equal(undefined);
        expect(lookupChar(testString, 3.14)).to.equal(undefined);
    });

    it('shold return \'Incorrect index\' string lenght <= index or index < 0 ', () => {
        expect(lookupChar('', 1)).to.equal('Incorrect index');
        expect(lookupChar(testString, 6)).to.equal('Incorrect index');
        expect(lookupChar('', 0)).to.equal('Incorrect index');
        expect(lookupChar(testString, -1)).to.equal('Incorrect index');
    });

    it('should return correct char at given index', () => {
        expect(lookupChar(testString, 1)).to.equal('t');
    });
})
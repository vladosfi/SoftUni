import { getNumber } from './module.js';
import './app.js';

describe('Main', () => {
    it('should return 5', () => {
        expect(getNumber()).to.equal(5);
    });
});

describe('Output', () => {
    it('should print 7', () => {
        const result = document.querySelector('#output').textContent;
        expect(result).to.contains('7');
    });
});
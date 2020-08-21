import * as myModule from './module.js';

const myVar = 2;

const result = myModule.addNumber(myVar, myModule.getNumber());

myModule.output('The result is ' + result);
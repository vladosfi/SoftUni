import { register, login, logout } from './data.js';

window.addEventListener('load', () => {
    window.testApi = function (){
        console.log(register('Peter','Johnson','peter','123'));
    };
});
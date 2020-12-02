import { homePage } from './controllers/catalog.js';
import * as api from './data.js';

window.api = api;

const app = Sammy('#root', function (context) {
    //Template engine setup
    this.use('Handlebars', 'hbs');

    // Home routes
    this.get('/', homePage);
    this.get('/home', homePage);
    this.get('/index.html', homePage);
});

app.run();
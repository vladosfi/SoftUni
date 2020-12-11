import { createPage, homePage, postCreate, detailsPage, deleteArticle, dashboardPage, likeArticle } from './controllers/catalog.js';
import { registerPage, loginPage, postRegister, postLogin, logoutPage } from './controllers/user.js';
// import * as api from './data.js';
import { getUserData } from './util.js';

// window.api = api;

const app = Sammy('#root', function (context) {
    //Template engine setup
    this.use('Handlebars', 'hbs');

    const user = getUserData();
    this.userData = user;

    // Home routes
    this.get('/', homePage);
    this.get('/#/home', homePage);
    this.get('/index.html', homePage);
    this.get('#/register', registerPage);
    this.get('#/login', loginPage);
    this.get('#/create', createPage);
    this.get('#/details/:id', detailsPage);
    this.get('#/delete/:id', deleteArticle);
    this.get('#/logout', logoutPage);
    this.get('#/dashboard', dashboardPage);
    this.get('#/like/:id', likeArticle);

    this.post('#/register', (ctx) => { postRegister(ctx); });
    this.post('#/login', (ctx) => { postLogin(ctx); });
    this.post('#/create', (ctx) => { postCreate(ctx); });

    this.get('', function () {
        this.swap('<h1> 404 page not found!</h1>');
    });
});

app.run();
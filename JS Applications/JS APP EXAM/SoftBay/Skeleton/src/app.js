import { createPage, homePage, postCreate, dashboardPage, detailsPage, editPage, postEdit, postDelete, deleteOffer } from './controllers/catalog.js';
import { registerPage, loginPage, postRegister, postLogin, logoutPage, profilePage,buyPage } from './controllers/user.js';
import { getUserData } from './util.js';

// window.api = api;

const app = Sammy('#root', function (context) {
    this.use('Handlebars', 'hbs');

    const user = getUserData();
    this.userData = user;

    // Home routes
    this.get('/', homePage);
    this.get('/#/home', homePage);
    this.get('/index.html', homePage);
    this.get('#/register', registerPage);
    this.get('#/login', loginPage);
    this.get('#/logout', logoutPage);

    this.get('#/create', createPage);
    this.get('#/dashboard', dashboardPage);
    this.get('#/edit/:id', editPage);
    this.get('#/delete/:id', deleteOffer);
    this.get('#/details/:id', detailsPage);
    this.get('#/profile/:id', profilePage);
    this.get('#/buy/:id', buyPage);



    this.post('#/register', (ctx) => { postRegister(ctx); });
    this.post('#/login', (ctx) => { postLogin(ctx); });
    this.post('#/create', (ctx) => { postCreate(ctx); });
    this.post('#/edit/:id', (ctx) => { postEdit(ctx); });
    this.post('#/delete/:id', (ctx) => { postDelete(ctx); });


    this.get('', function () {
        this.swap('<h1> 404 page not found!</h1>');
    });
});

app.run();
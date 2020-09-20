import { getHome } from './controller/home.js';
import { getLogin, getProfile, getRegister, postLogin, postRegister, getLogout } from './controller/user.js';
import { getCreate, postCreate, getDetails, getEdit, postEdit, getClose, getJoin } from './controller/events.js';

const app = Sammy("body", function () {
    this.use("Handlebars", "hbs");

    this.get('#/home', getHome);

    this.get('#/login', getLogin);

    this.get('#/register', getRegister);

    this.get('#/profile', getProfile);

    this.post('#/register', postRegister);

    this.post('#/login', postLogin);

    this.get('#/logout', getLogout);

    this.get('#/create', getCreate);

    this.post('#/create', postCreate);

    this.get('#/details/:id', getDetails);

    this.get('#/edit/:id', getEdit);

    this.post('#/edit/:id', postEdit);

    this.get('#/close/:id', getClose);

    this.get('#/join/:id', getJoin);


});
app.run('#/home');
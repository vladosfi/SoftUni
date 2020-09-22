import { registerPage, registerPost, loginPage, loginPost, logout } from './controller/user.js';
import home, { createPage, createPost } from './controller/catalog.js';

window.addEventListener('load', () => {
    const app = Sammy('#rooter', function () {
        this.use('Handlebars', 'hbs');

        this.userData = {
            username: sessionStorage.getItem('username') || '',
            userId: sessionStorage.getItem('userId') || '',
            names: sessionStorage.getItem('names') || '',

        };

        this.get('/', home);
        this.get('#/home', home);
        this.get('/index.html', home);

        this.get('#/register', registerPage);
        this.get('#/login', loginPage);
        this.get('#/logout', logout);
        this.get('#/create', createPage);



        this.post('#/register', (ctx) => { registerPost.call(ctx); });
        this.post('#/login', (ctx) => { loginPost.call(ctx); });
        this.post('#/create', (ctx) => { createPost.call(ctx); });

    });

    app.run();
});
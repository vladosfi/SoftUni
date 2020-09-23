import { registerPage, registerPost, loginPage, loginPost, logout } from './controller/user.js';
import home, { createPage, createPost, editPage, editPost, detailsPage, deleteRecipeById, likeRecipe } from './controller/catalog.js';

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
        this.get('#/edit/:id', editPage);
        this.get('#/details/:id', detailsPage);
        this.get('#/delete/:id', deleteRecipeById);
        this.get('#/like/:id', likeRecipe);



        this.post('#/register', (ctx) => { registerPost.call(ctx); });
        this.post('#/login', (ctx) => { loginPost.call(ctx); });
        this.post('#/create', (ctx) => { createPost.call(ctx); });
        this.post('#/edit/:id', (ctx) => { editPost.call(ctx); });


    });

    app.run();
});
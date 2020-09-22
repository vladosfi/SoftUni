import { checkResult, createRecipe, getAll } from '../data.js';
import { showError, showInfo } from '../notofocation.js';

export default async function home() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
        catalog: await this.load('../../templates/catalog/catalog.hbs'),
        recipe: await this.load('../../templates/catalog/recipe.hbs'),
    }

    const context = Object.assign({}, this.app.userData)
    if (this.app.userData.username) {
        //load recipes from database
        const recipes = await getAll();
        context.recipes = recipes;
    }

    this.partial('../../templates/home.hbs', context);
}

export async function createPage() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
    }

    this.partial('../../templates/catalog/create.hbs', this.app.userData);
}

export async function createPost() {
    const recipe = {
        meal: this.params.meal,
        ingredients: this.params.ingredients.split(',').map(i => i.trim()),
        prepMethod: this.params.prepMethod,
        description: this.params.description,
        foodImageURL: this.params.foodImageURL,
        category: this.params.category,
        categoryImageURL: 'https://image.shutterstock.com/image-photo/assorted-dairy-products-milk-yogurt-260nw-530162824.jpg',
        likes: 0,
    };

    try {
        if (recipe.meal.length < 4) {
            throw new Error('The meal should be at least 4 characters long');
        }

        if (recipe.ingredients.length < 2) {
            throw new Error('The ingredients should at least 2 elements');
        }

        if (recipe.prepMethod.length < 10) {
            throw new Error('The preparation method and description should be at least 10 characters long');
        }

        if (recipe.description.length < 10) {
            throw new Error('The description method and description should be at least 10 characters long');
        }

        if (recipe.foodImageURL.slice(0,7) !== 'http://' && recipe.foodImageURL.slice(0,8) !== 'https://') {
            throw new Error('The foodImageURL should start with "http://" or "https://"');
        }

        if (recipe.category === 'Select category...') {
            throw new Error('Plese select category');
        }



        const result = await createRecipe(recipe);

        checkResult(result);

        showInfo('Recipe shared successfully.');

        this.redirect('#/home');
    } catch (err) {
        showError(err.message);
    }
}
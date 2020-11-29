import { getAll, createRecipe, checkResult, getRecipeById, editRecipe, likeRecipe, deleteRecipe as apiDeleteRecipe } from '../data.js'
import { showError, showInfo } from '../notofocation.js';

export default async function home() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        catalog: await this.load('./templates/catalog/catalog.hbs'),
        recipe: await this.load('./templates/catalog/recipe.hbs'),

    };

    const context = Object.assign({}, this.app.userData);
    if (this.app.userData.username) {
        const recipes = await getAll();
        context.recipes = recipes;
    }

    this.partial('./templates/home.hbs', context);
}

export async function createPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/catalog/create.hbs', this.app.userData);
}

export async function editPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    const recipe = await getRecipeById(this.params.id);
    recipe.ingredients = recipe.ingredients.join(', ');
    const context = Object.assign({ recipe }, this.app.userData);

    await this.partial('./templates/catalog/edit.hbs', context);

    document.querySelectorAll('select[name=category]>option').forEach(o => {
        if (o.textContent == recipe.category) {
            o.selected = true;
        }
    });
}

export async function detailsPage() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    const recipe = await getRecipeById(this.params.id);
    recipe.isOwner = recipe.ownerId === this.app.userData.userId ? true : false;
    const context = Object.assign({ recipe }, this.app.userData);

    this.partial('./templates/catalog/details.hbs', context);
}


export async function like() {
    try {
        const id = this.params.id;
        const result = await likeRecipe(id);
        checkResult(result);

        showInfo('You liked that recipe.');
        this.redirect('#/home');

    } catch (err) {
        showError(err.message);
    }
}

export async function deleteRecipe() {
    try {
        const id = this.params.id;
        const result = await apiDeleteRecipe(id);
        checkResult(result);

        showInfo('Your recipe was archived.');
        this.redirect('#/home');

    } catch (err) {
        showError(err.message);
    }
}

export async function createPost() {
    const recipe = {
        meal: this.params.meal,
        ingredients: this.params.ingredients.split(',').map(i => i.trim()),
        prepMethod: this.params.prepMethod,
        description: this.params.description,
        foodImageURL: this.params.foodImageURL,
        likes: 0,
        category: this.params.category,
        categoryImageURL: 'https://healthy-kids.com.au/wp-content/uploads/2013/12/ComplexCarbohydrateFamily.jpg',
    };

    try {
        if (recipe.meal.length < 4) {
            throw new Error('Meal name must be at least 4 characters long')
        }
        if (recipe.ingredients.length < 2) {
            throw new Error('There must be at least 2 ingredients')
        }
        if (recipe.prepMethod.length < 10) {
            throw new Error('Preparation method must be at least 10 characters long')
        }
        if (recipe.description.length < 10) {
            throw new Error('Description must be at least 10 characters long')
        }
        if (recipe.foodImageURL.slice(0, 7) !== 'http://' && recipe.foodImageURL.slice(0, 8) !== 'https://') {
            throw new Error('The food image URL should start with "http://" or "https://".');
        }
        if (recipe.category === 'Select category...') {
            throw new Error('Please select category from the list');
        }

        const result = await createRecipe(recipe);
        checkResult(result);

        showInfo('Recipe shared successfully!');
        this.redirect('#/home');

    } catch (err) {
        showError(err.message);
    }
}

export async function editPost() {
    const id = this.params.id;
    const recipe = await getRecipeById(id);

    recipe.meal = this.params.meal;
    recipe.ingredients = this.params.ingredients.split(',').map(i => i.trim());
    recipe.prepMethod = this.params.prepMethod;
    recipe.description = this.params.description;
    recipe.foodImageURL = this.params.foodImageURL;
    recipe.category = this.params.category;
    recipe.categoryImageURL = 'https://healthy-kids.com.au/wp-content/uploads/2013/12/ComplexCarbohydrateFamily.jpg';

    try {
        if (recipe.meal.length < 4) {
            throw new Error('Meal name must be at least 4 characters long')
        }
        if (recipe.ingredients.length < 2) {
            throw new Error('There must be at least 2 ingredients')
        }
        if (recipe.prepMethod.length < 10) {
            throw new Error('Preparation method must be at least 10 characters long')
        }
        if (recipe.description.length < 10) {
            throw new Error('Description must be at least 10 characters long')
        }
        if (recipe.foodImageURL.slice(0, 7) !== 'http://' && recipe.foodImageURL.slice(0, 8) !== 'https://') {
            throw new Error('The food image URL should start with "http://" or "https://".');
        }
        if (recipe.category === 'Select category...') {
            throw new Error('Please select category from the list');
        }

        const result = await editRecipe(id, recipe);
        checkResult(result);

        showInfo('Recipe edited successfully!');
        this.redirect('#/home');

    } catch (err) {
        showError(err.message);
    }
}
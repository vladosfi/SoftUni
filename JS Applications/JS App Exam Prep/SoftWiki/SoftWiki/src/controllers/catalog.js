import { getAll } from "../data.js";
import { addPartials } from "../util.js";

export async function homePage() { 
    await addPartials(this);

    const context = {
        articles: await getAll()
    };

    this.partial('/templates/catalog/homePage.hbs');
}
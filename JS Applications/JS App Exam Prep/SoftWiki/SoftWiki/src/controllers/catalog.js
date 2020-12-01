import { getAll } from "../data.js";
import { addPartials } from "../util.js";

export async function homePage() {
    await addPartials(this);
    this.partials.article = await this.load('/templates/catalog/article.hbs');

    // const context = {
    //     articles: await getAll()
    // };

    const context = {
        js: [
            {
                title: 'Article1',
                category: 'JavaScript',
                content: 'Lorem ipsum ',
            },
            {
                title: 'Article2',
                category: 'JavaScript',
                content: 'Lorem ipsum ',
            }
        ],
        java: [
            {
                title: 'Article1',
                category: 'java',
                content: 'Lorem ipsum ',
            }
        ],
    }

    this.partial('/templates/catalog/homePage.hbs', context);
}
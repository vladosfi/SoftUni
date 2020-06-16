function getArticleGenerator(articles) {
    const div = document.querySelector('#content');

    function showNext() {
        if (articles.length > 0) {
            const newArticle = document.createElement("article");
            newArticle.textContent = articles.shift();
            div.appendChild(newArticle);
        }
    }

    return showNext;
}

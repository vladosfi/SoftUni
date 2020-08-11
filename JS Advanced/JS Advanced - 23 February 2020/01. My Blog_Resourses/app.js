function solve() {
   const inputCreator = document.querySelector('#creator');
   const inputTitle = document.querySelector('#title');
   const inputCategory = document.querySelector('#category');
   const inputContent = document.querySelector('#content');
   const articlesSection = document.querySelector('main > section');
   const archiveSection = document.querySelector('.archive-section ul');
   //document.querySelector('button').addEventListener('click', create);
   document.querySelector('.btn.create').addEventListener('click', create);
   const archiveList = [];

   function create(e) {
      e.preventDefault();
      const creator = inputCreator.value;
      const title = inputTitle.value;
      const category = inputCategory.value;
      const content = inputContent.value;

      if (!(creator.length > 0 && title.length > 0 && category.length > 0 && content.length > 0)) {
         return;
      }

      const articleTitle = el('h1', title)
      const btnDelete = el('button', 'Delete', { className: 'btn delete' });
      const btnArchive = el('button', 'Archive', { className: 'btn archive' });

      const buttonsDiv = el('div', [
         btnDelete,
         btnArchive,
      ], { className: 'buttons' });

      const article = el('article', [
         articleTitle,
         el('p', ['Category: ', el('strong', category)]),
         el('p', ['Creator: ', el('strong', creator)]),
         el('p', content),
         buttonsDiv
      ])

      articlesSection.appendChild(article);

      btnDelete.addEventListener('click', () => {
         article.remove();
      })

      btnArchive.addEventListener('click', () => {

         while (archiveSection.firstChild) {
            archiveSection.removeChild(archiveSection.firstChild);
         }

         archiveList.push(title)
         archiveList.sort((a, b) => b.localeCompare(a));

         archiveList.forEach(li => {
            archiveSection.appendChild(el('li', li));
         });

         article.remove();
      })
   }


   function el(type, content, attributes) {
      const result = document.createElement(type);

      if (attributes !== undefined) {
         Object.assign(result, attributes);
      }

      if (Array.isArray(content)) {
         content.forEach(append);
      } else {
         append(content);
      }

      function append(node) {
         if (typeof node === 'string' || typeof node === 'number') {
            node = document.createTextNode(node);
         }
         result.appendChild(node);
      }

      return result;
   }

}

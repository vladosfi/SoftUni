function solve() {
   const products = document.querySelector('#products > ul');
   const order = document.querySelector('#myProducts > ul');

   const form = document.querySelector('#add-new');
   const inputName = form.item('1');
   const inputQty = form.item('2');
   const inputPrice = form.item('3');

   form.item(4).addEventListener('click', addProduct);

   function addProduct(e){
      e.preventDefault();
      const 

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
          if (typeof node === 'string') {
              node = document.createTextNode(node);
          }
          result.appendChild(node);
      }

      return result;
  }
}
function solve() {
  const [generate, buy] = [...document.querySelectorAll('button')];
  const [inputAria, outputAria] = [...document.querySelectorAll('textarea')];

  generate.addEventListener('click', onGenerate);
  buy.addEventListener('click', onBuy);
  tableBody = document.querySelector('tbody');

  function onGenerate(e) {
    const button = e.target;
    const furnitureList = JSON.parse(inputAria.value)

    for (const el of furnitureList) {
      const tableRow = document.createElement('tr');
      let td1 = document.createElement('td');
      let td2 = document.createElement('td');
      let td3 = document.createElement('td');
      let td4 = document.createElement('td');
      let td5 = document.createElement('td');

      let name = document.createTextNode(el.name);
      let img = document.createElement("IMG");
      img.src = el.img;
      let price = document.createTextNode(el.price);
      let decFactor = document.createTextNode(el.decFactor);
      let mark = document.createElement("INPUT");
      mark.setAttribute("type", "checkbox");

      td2.appendChild(img);
      td1.appendChild(name);
      td3.appendChild(price);
      td4.appendChild(decFactor);
      td5.appendChild(mark);

      tableRow.appendChild(td2);
      tableRow.appendChild(td1);
      tableRow.appendChild(td3);
      tableRow.appendChild(td4);
      tableRow.appendChild(td5);

      tableBody.appendChild(tableRow);
    }

    inputAria.value = '';
  }

  function onBuy(e) {
    const boughtItems = [...tableBody.querySelectorAll('input')]
      .filter(i => i.checked)
      .map(i => i.parentNode.parentNode)
      .map(row => ({
        name: row.children[1].textContent.trim(),
        price: Number(row.children[2].textContent),
        decFactor: Number(row.children[3].textContent)
      }));

    const result = [
      `Bought furniture: ${boughtItems.map(i => i.name).join(', ')}`,
      `Total price: ${boughtItems.reduce((p, c, i, a) => p + c.price, 0).toFixed(2)}`,
      `Average decoration factor: ${boughtItems.reduce((p, c, i, a) => p + c.decFactor, 0) / boughtItems.length}`
    ]

    outputAria.value = result.join('\n');
  }
}
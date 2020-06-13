function solve() {
   document.querySelector('#player1Div').addEventListener('click', onClickP1);
   document.querySelector('#player2Div').addEventListener('click', onClickP2);
   const resultSpans = document.querySelector('#result').querySelectorAll('span');
   let history = document.querySelector('#history');
   let playerOneCard;
   let playerTwoCard;

   function onClickP1(e) {
      const element = e.target;
      element.src = 'images/whiteCard.jpg';
      resultSpans[0].textContent = element.name;
      playerOneCard = element;
      compare();
   }

   function onClickP2(e) {
      const element = e.target;
      element.src = 'images/whiteCard.jpg';
      playerTwoCard = element;
      resultSpans[2].textContent = element.name;
      compare();
   }

   function compare() {
      const resultP1 = Number(resultSpans[0].textContent);
      const resultP2 = Number(resultSpans[2].textContent);

      if (resultP1 !== 0 && resultP2 !== 0) {
         if (resultP1 > resultP2) {
            playerOneCard.style.border = '2px solid green';
            playerTwoCard.style.border = '2px solid red';
         } else {
            playerTwoCard.style.border = '2px solid green';
            playerOneCard.style.border = '2px solid red';
         }

         history.textContent = history.textContent + `[${resultP1} vs ${resultP2}] `;
         playerOneCard = '';
         playerTwoCard = '';
         resultSpans[0].textContent = '';
         resultSpans[2].textContent = '';
      }
   }
}
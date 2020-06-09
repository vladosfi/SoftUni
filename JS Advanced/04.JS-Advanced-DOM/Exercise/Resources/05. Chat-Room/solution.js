function solve() {
   document.querySelector('button').addEventListener('click', onClick);

   function onClick(){
      const message = document.querySelector('#chat_input');
      const textMessage = message.value;
      
      const newMessage = document.createElement('div');
      newMessage.textContent = textMessage;
      newMessage.classList.add('message');
      newMessage.classList.add('my-message');

      document.querySelector('#chat_messages').appendChild(newMessage);
      message.value = '';
   }
}



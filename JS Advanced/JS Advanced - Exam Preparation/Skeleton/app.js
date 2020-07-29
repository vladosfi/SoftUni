function solve() {
    //Запазване на референции към елементите, които ще манипулираме през целия живот на приложението
    const sections = document.querySelectorAll('section');
    const openDiv = sections.item(1).querySelectorAll('div').item(1);
    const progressDiv = sections.item(1).querySelectorAll('div').item(1);
    const finishedDiv = sections.item(1).querySelectorAll('div').item(1);

    const inputTask = document.querySelector('#task');
    const inputDesk = document.querySelector('#description');
    const inputDate = document.querySelector('#date');

    document.querySelector('#add').addEventListener('click', addTask);
    //Създаване на задачи (DOM елементи)
    function addTask(e) {
        e.preventDefault();
        //Прочитаме съдържанието на формуляра и валидираме
        const 
        //създаваме елементите
        //закачаме функционалност
        //добавяме елементи в DOM дървото
    }
}
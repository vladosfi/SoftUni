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
        const taskName = inputTask.value;
        const taskDesk = inputDesk.value;
        const taskDate = inputDate.value;

        if (taskName.length > 0 && taskDesk.length > 0 && taskDate > 0) {
            const btnDiv = el('div');

            
            const task = el('article',[
                el('h3', taskName),
                el('p',`Description: ${taskDesk}`),
                el('p',`Due Date: ${taskDate}`),
                btnDiv
            ]);
            //създаваме елементите
            //закачаме функционалност
            //добавяме елементи в DOM дървото
        }
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
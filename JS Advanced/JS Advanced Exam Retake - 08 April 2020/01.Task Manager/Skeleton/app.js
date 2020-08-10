function solve() {
    const inputTaskName = document.querySelector('#task');
    const inputDescription = document.querySelector('#description');
    const inputDate = document.querySelector('#date');
    const sections = document.querySelectorAll('section');
    const openDiv = sections[1].querySelectorAll('div')[1];
    const inProgressDiv = sections[2].querySelectorAll('div')[1];
    const completeDiv = sections[3].querySelectorAll('div')[1];


    document.querySelector('#add').addEventListener('click', addTask);

    function addTask(e) {
        e.preventDefault();
        const taskName = inputTaskName.value;
        const taskDescription = inputDescription.value;
        const taskDate = inputDate.value;

        if (taskName && taskDescription && taskDate) {

            const btnStart = el('button', 'Start', { className: 'green' });
            const btnDelete = el('button', 'Delete', { className: 'red' });
            const btnFinish = el('button', 'Finish', { className: 'orange' });
            const divFlex = el('div', [btnStart, btnDelete], { className: 'flex' })

            const task = el('article', [
                el('h3', taskName),
                el('p', `Description: ${taskDescription}`),
                el('p', `Due Date: ${taskDate}`),
                divFlex
            ]);

            openDiv.appendChild(task);

            btnDelete.addEventListener('click', () => {
                task.remove();
            });

            btnStart.addEventListener('click', () => {
                btnStart.remove();
                divFlex.appendChild(btnFinish);
                inProgressDiv.appendChild(task);
            });

            btnFinish.addEventListener('click', () => {
                divFlex.remove();
                completeDiv.appendChild(task);
            });

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
            if (typeof node === 'string' || typeof node === 'number') {
                node = document.createTextNode(node);
            }
            result.appendChild(node);
        }

        return result;
    }
}
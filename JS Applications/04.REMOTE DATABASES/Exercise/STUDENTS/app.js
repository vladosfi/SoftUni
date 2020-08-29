import * as api from './data.js';
import el from './dom.js';

window.addEventListener('load', () => {
    const tbodyEl = document.querySelector('tbody');
    tbodyEl.innerHTML = '<tr><td colspan="4">Loading...</td></tr>';

    const addStud = el('td', '+');
    addStud.setAttribute('colspan', '5')
    addStud.addEventListener('click', () => {
        tbodyEl.appendChild(renderNewRow());
        addStudentEl.remove();
    });
    const addStudentEl = el('tr');
    addStudentEl.appendChild(addStud);
    addStudentEl.style.backgroundColor = "white";
    addStudentEl.style.color = 'blue';

    async function loadStudents() {
        const students = await api.getStudents();
        tbodyEl.innerHTML = '';
        students
            .sort((a, b) => a.ID - b.ID)
            .forEach(s => {
                tbodyEl.appendChild(renderStudent(s));
            });
        tbodyEl.appendChild(addStudentEl);
    }
    loadStudents();


    function renderStudent(student) {
        const id = el('td', student.ID);
        const firstName = el('td', student.FirstName);

        firstName.addEventListener('dblclick', () => updateStudentTable(firstName, student.FirstName));

        const lastName = el('td', student.LastName);
        const facultyNumber = el('td', student.FacultyNumber);
        const grade = el('td', student.Grade);

        const tdElemets = {
            Id: id,
            FirstName: firstName,
            LastName: lastName,
            FacultyNumber: facultyNumber,
            Grade: grade,
        }

        const tr = el('tr', [
            tdElemets.Id,
            tdElemets.FirstName,
            tdElemets.LastName,
            tdElemets.FacultyNumber,
            tdElemets.Grade,
        ]);

        return tr;

        function updateStudentTable(elToEdit, inputValie) {
            console.log(inputValie);
            const editedElement = el('input');
            elToEdit.textContent = '';
            editedElement.value = inputValie;
            elToEdit.appendChild(editedElement);

            elToEdit.addEventListener("keyup", async function (event) {
                if (event.keyCode === 13) {
                    const input = editedElement.value;
                    if (input.lenght <= 0) { return; };
                    elToEdit.innerHTML = '';
                    const data = await api.updateStudent({
                        FirstName: editedElement.value,
                        objectId: student.objectId,
                    });
                    elToEdit.innerHTML = editedElement.value;
                }
            });
        }
    }

    function renderNewRow() {
        const createInputs = {
            firstName: el('input', '', { 'placeholder': "Please enter First Name" }),
            lastName: el('input', '', { 'placeholder': "Please enter Last Name" }),
            facultyNumber: el('input', '', { 'placeholder': "Please enter Faculty Number" }),
            grade: el('input', '', { 'placeholder': "Please enter Grade" }),
        };

        const addLink = el('td', 'Add');
        addLink.addEventListener('click', async () => {
            addLink.textContent = 'Please wait...';
            const nextId = parseInt(await api.getStudentsCount()) + 1;
            const student = ({
                ID: nextId,
                FirstName: createInputs.firstName.value,
                LastName: createInputs.lastName.value,
                FacultyNumber: createInputs.facultyNumber.value,
                Grade: Number(createInputs.grade.value),
            });

            console.log('id: - ' + nextId);
            const result = await api.createStudent(student);
            tr.remove();
            tbodyEl.appendChild(renderStudent(student));
            tbodyEl.appendChild(addStudentEl);
        });

        const firstName = el('td', createInputs.firstName);
        const lastName = el('td', createInputs.lastName);
        const facultyNumber = el('td', createInputs.facultyNumber);
        const grade = el('td', createInputs.grade);

        const tr = el('tr', [
            addLink,
            firstName,
            lastName,
            facultyNumber,
            grade,
        ]);

        return tr;
    }
});
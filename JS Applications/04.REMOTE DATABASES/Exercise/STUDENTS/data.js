const apiKey = '7C4FA567-B589-16DB-FF0D-458BD6ABA000';
const restApi = 'FFB4645E-2CE6-4514-B1BF-0941FB2ABEDA';

function host(endpoint) {
    return `https://api.backendless.com/${apiKey}/${restApi}/data/${endpoint}`;
}

export async function getStudents() {
    const result = await fetch(host('students'));
    const data = await result.json();
    return data;
}

export async function createStudent(student) {
    const response = await fetch(host('students'), {
        method: 'POST',
        body: JSON.stringify(student),
    });

    const data = response.json();
    return data;
}

export async function getStudentsCount() {
    const result = await fetch(host('students/count'));
    const data = await result.json();
    return data;
}

export async function updateStudent(studentData) {
    const id = studentData.objectId;
    const response = await fetch(host(`students/${id}`), {
        method: 'PUT',
        body: JSON.stringify(studentData),
    });

    const data = response.json();
    return data;
}
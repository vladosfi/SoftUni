function createTableFromJSON(input) {
    const rows = [];
    rows.push('<table>');

    for (let line of input) {
        const person = JSON.parse(line);
        rows.push(`\t<tr>\n\t\t<td>${person.name}</td>\n\t\t<td>${person.position}</td>\n\t\t<td>${person.salary}</td>\n\t</tr>`);
    }
    
    rows.push('</table>');
    console.log(rows.join('\n'));
}

createTableFromJSON([
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']
)
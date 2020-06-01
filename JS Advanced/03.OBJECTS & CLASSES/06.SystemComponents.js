"use strict";

function solve(input) {
    const catalog = {};

    for (const line of input) {
        const [systemName, componentName, subcomponentName] = line.split(' | ');

        if (catalog.hasOwnProperty(systemName) === false) {
            catalog[systemName] = {};
        }
        if (catalog[systemName].hasOwnProperty(componentName) === false) {
            catalog[systemName][componentName] = [];
        }
        catalog[systemName][componentName].push(subcomponentName);
    }

    const sortedCatalog = Object.entries(catalog).sort((a, b) => {
        return Object.keys(b[1]).length - Object.keys(a[1]).length || a[0].localeCompare(b[0]);
    }).forEach(([system, component]) => {
        console.log(system);
        Object.entries(component)
            .sort((a,b) => b[1].length - a[1].length)
            .forEach(([name, sub])=>{
                console.log(`|||${name}`);
                sub.forEach(s=>{
                    console.log('||||||' + s);
                })
            })
    });

    console.log(sortedCatalog);
}

solve([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
)
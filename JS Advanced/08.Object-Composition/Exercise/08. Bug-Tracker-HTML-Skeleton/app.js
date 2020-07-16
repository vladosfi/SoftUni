function solve() {
    let currentId = 0;
    const reports = new Map();
    const elements = [];
    let selector = null;

    function report(author, description, reproducible, severity) {
        const statusSpan = el('span',`${status} | ${severity}`, {className: 'author'});
        
        const element = el('div', [
            el('div', el('p0', description), { className: 'body' }),
            el('div', [
                el('span',`Submitted by: ${author}`, {className: 'author'}),
                statusSpan
            ], { className: 'title' })
        ], {
            id: `report_${currentId}`,
            className: 'report'
        });

        reports.set(currentId, {
            ID: currentId,
            author,
            description,
            reproducible,
            severity,
            status: 'Open',
            element: null //DOM element          
        });
        currentId++;
    }

    function setStatus(id, newStatus) {
        reports.get(id).status = newStatus;
    }

    function remove(id) {
        reports.delete(id);
    }

    function sort(method) {

    }

    function output(newSelector) {
        selector = newSelector;
    }

    return {
        report,
        setStatus,
        remove,
        sort,
        output
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
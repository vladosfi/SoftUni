function solve() {
    const baseURL = 'http://localhost:8000/schedule/';
    let busStopId = 'depot';
    let busStopName = 'depot';

    const elements = {
        stopInfo() { return document.querySelector('span.info'); },
        depart() { return document.querySelector('input#depart'); },
        arrive() { return document.querySelector('input#arrive'); }
    };

    function depart() {
        fetch(baseURL + `${busStopId}.json`)
            .then(response => response.json())
            .then(response => showBusInfo(response));

        function showBusInfo(data) {
            elements.stopInfo().textContent = `Next stop ${data.name}`;
            busStopId = data.next;
            busStopName = data.name;
            switchBusState();
        }
    }

    function arrive() {
        elements.stopInfo().textContent = `Arriving at ${busStopName}`;
        switchBusState();
    }

    function switchBusState() {
        const { disabled: isDisabled } = elements.depart();

        if (isDisabled) {
            elements.arrive().disabled = true;
            elements.depart().disabled = false;
        } else {
            elements.arrive().disabled = false;
            elements.depart().disabled = true;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
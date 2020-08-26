import el from './dom.js';
import * as data from './data.js';

const symbols = {
    'Sunny': '&#x2600;',
    'Partly sunny': '&#x26C5;',
    'Overcast': '&#x2601;',
    'Rain': '&#x2614;',
    'Degrees': '&#176;',
};

window.addEventListener('load', () => {
    const elements = {
        main: () => { return document.querySelector('#forecast'); },
        today: () => { return document.querySelector('#current'); },
        upcoming: () => { return document.querySelector('#upcoming'); },
        input: () => { return document.querySelector('#location'); },
    };

    document.querySelector('#submit').addEventListener('click', getForecast);


    async function getForecast() {
        const locationName = elements.input().value;

        let code = '';
        try {
            code = await data.getCode(locationName);
        } catch (err) {
            elements.input().value = 'Error';
            return;
        }

        //console.log(code);
        /**
         const result = await Promise.all([
            data.getToday(code),
            data.getUpcoming(code)
            ]);
         */
        const todayP = data.getToday(code);
        const upcomingP = data.getUpcoming(code);

        const [today, upcoming] = [
            await todayP,
            await upcomingP
        ];
        //console.log(today);

        const symbolSpan = el('span', '', { className: 'condition symbol' });
        symbolSpan.innerHTML = symbols[today.forecast.condition];

        const tempSpan = el('span', '', { className: 'forecast-data' });
        tempSpan.innerHTML = `${today.forecast.low}${symbols.Degrees}/${today.forecast.high}${symbols.Degrees}`;

        elements.today().appendChild(el('div', [
            symbolSpan,
            el('span', [
                el('span', today.name, { className: 'forecast-data' }),
                tempSpan,
                el('span', today.forecast.condition, { className: 'forecast-data' }),
            ], { className: 'condition' }),
        ], {
            className: 'forecast'
        }));

        elements.main().style.display = 'block';


        const forecastInfoDiv = el('div', upcoming.forecast.map(renderUpcoming), { className: 'forecast-info' });
        elements.upcoming().appendChild(forecastInfoDiv);

        function renderUpcoming(forecast) {
            const symbolSpan = el('span', '', { className: 'symbol' });
            symbolSpan.innerHTML = symbols[forecast.condition];
            const tempSpan = el('span', '', { className: 'forecast-data' });
            tempSpan.innerHTML = `${forecast.low}${symbols.Degrees}/${forecast.high}${symbols.Degrees}`;

            const result = el('span', [
                symbolSpan,
                tempSpan,
                el('span', forecast.condition, { className: 'forecast-data' }),
            ], {
                className: 'upcoming'
            })

            return result;
        }
    }
});
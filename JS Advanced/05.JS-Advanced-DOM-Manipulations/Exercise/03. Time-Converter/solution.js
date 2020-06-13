function attachEventsListeners() {
    const ratios = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    function convert(value, from) {
        const inDays = value / ratios[from];
        return {
            days: inDays,
            hours: inDays * ratios.hours,
            minutes: inDays * ratios.minutes,
            seconds: inDays * ratios.seconds
        }
    }

    const days = document.querySelector('#days');
    const hours = document.querySelector('#hours');
    const minutes = document.querySelector('#minutes');
    const seconds = document.querySelector('#seconds');

    document.querySelector('main').addEventListener('click', onClick);

    function onClick(e) {
        if (e.target.nodeName === 'INPUT' && e.target.type === 'button') {
            const el = e.target.parentNode.querySelector('input[type="text"]');
            const value = Number(el.value);
            const id = el.id;
            const convertedValues = convert(value, id);
            display(convertedValues);
        }
    }

    function display(convertedValues) {
        days.value = convertedValues.days;
        hours.value = convertedValues.hours;
        minutes.value = convertedValues.minutes;
        seconds.value = convertedValues.seconds;
    }

    // function convertDays(e) {
    //     const value = Number(days.value);
    //     const convertedValues = convert(value, 'days');
    //     display(convertedValues);
    // }
    // function convertHours(e) {
    //     const value = Number(hours.value);
    //     const convertedValues = convert(value, 'hours');
    //     display(convertedValues);
    // }
    // function convertMinutes(e) {
    //     const value = Number(minutes.value);
    //     const convertedValues = convert(value, 'minutes');
    //     display(convertedValues);
    // }
    // function convertSeconsds(e) {
    //     const value = Number(hours.value);
    //     const convertedValues = convert(value, 'seconsds');
    //     display(convertedValues);
    // }
}
function attachEventsListeners() {
    const ratios = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconsd: 86400
    }

    function convert(value, from) {
        const inDays = value / ratios[from];
        return {
            days: inDays,
            hours: inDays * ratios[hours],
            minutes: inDays * ratios[minutes],
            seconsd: inDays * ratios[seconsd]
        }
    }

    console.log('TODO:...');
}
function walk(steps, footprintInMeters, speedInKm) {
    const distance = (steps * footprintInMeters);
    let time = Math.round(distance / speedInKm * 3.6);
    time += Math.floor(distance / 500) * 60;

    const secconds = time % 60;
    time -= secconds;
    time /= 60;
    const minutes = time % 60;
    time -= minutes;
    time /= 60;
    const hours = time;

    console.log(`${padWithZero(hours)}:${padWithZero(minutes)}:${padWithZero(secconds)}`);

    function padWithZero(num){
        return ('0' + num).slice(-2);
    }
}

walk(4000, 0.60, 5);
walk(2564, 0.70, 5.5);
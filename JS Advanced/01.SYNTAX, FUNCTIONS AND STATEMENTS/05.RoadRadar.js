function radar(params) {
    const speed = params[0];
    const aria = params[1];
    let overLimit = 0;

    switch (aria) {
        case 'motorway':
            overLimit = speed - 130;
            break;
        case 'interstate':
            overLimit = speed - 90;
            break;
        case 'city':
            overLimit = speed - 50;
            break;
        case 'residential':
            overLimit = speed - 20;
            break;
    }

    if (overLimit > 40) {
        console.log('reckless driving');
    } else if (overLimit > 20) {
        console.log('excessive speeding');
    }
    else if (overLimit > 0){
        console.log('speeding');
    }
}

radar([40, 'city']);
radar([21, 'residential']);
radar([120, 'interstate']);
radar([200, 'motorway']);

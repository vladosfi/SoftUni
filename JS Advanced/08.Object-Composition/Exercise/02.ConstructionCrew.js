function solve(data) {
    const worker = {
        weight: data.weight,
        experience: data.experience
    }

    let levelOfHydrated = data.levelOfHydrated;

    if(data.dizziness){
        levelOfHydrated += 0.1 * data.weight * data.experience;
    }

    worker.levelOfHydrated = levelOfHydrated;

    worker.dizziness = false;

    return worker;
}

const result = solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
);

console.log(result);
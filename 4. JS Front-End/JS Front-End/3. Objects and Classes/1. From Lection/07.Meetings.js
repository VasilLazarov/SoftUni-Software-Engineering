function schedule(arr){
    const scheduleObj = arr.reduce((acc, curr) => {
        const [day, name] = curr.split(' ');
        if(acc.hasOwnProperty(day)){
            console.log(`Conflict on ${day}!`);
        }
        else{
            acc[day] = name;
            console.log(`Scheduled for ${day}`);
        }
        return acc;
    }, {});
    Object.entries(scheduleObj).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}

schedule([
    'Monday Peter',
    'Wednesday Bill',
    'Monday Tim',
    'Friday Tim'
]);
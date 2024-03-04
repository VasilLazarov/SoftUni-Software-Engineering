function calculateCircleArea(radius){
    let circleArea;
    if(typeof radius !== "number"){
        console.log(`We can not calculate the circle area, because we receive a ${typeof radius}.`);

    }
    else{
        circleArea = Math.pow(radius, 2) * Math.PI;
        console.log(circleArea.toFixed(2));
    }
}
calculateCircleArea(5);
calculateCircleArea('name');
calculateCircleArea(25);
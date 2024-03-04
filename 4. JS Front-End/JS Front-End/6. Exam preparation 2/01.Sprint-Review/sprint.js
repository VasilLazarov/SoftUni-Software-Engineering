function solve(input){
    const ticketLines = Number(input.shift());
    const tickets = input.slice(0, ticketLines);
    const commands = input.slice(ticketLines);

    const board = tickets.reduce((acc, curr) => {
        const [assignee, taskId, title, status, estimatedPoints] = curr.split(":");
        if(!acc.hasOwnProperty(assignee)){
            acc[assignee] = [];
        }
        acc[assignee].push({
            taskId,
            title,
            status,
            estimatedPoints: Number(estimatedPoints),
        });
        return acc;
    }, {});

    const commandRunner ={
        'Add New': addNewTask,
        'Change Status': changeTaskStatus,
        'Remove Task': removeTask,
    };

    commands.forEach((command) => {
        const [commandName, ...rest] = command.split(":");
        commandRunner[commandName](...rest);
    });

    let todoPoints = 0;
    Object.values(board).forEach((arr) => {
        arr.forEach((currentTask) => {
            if(currentTask.status === "ToDo"){
                todoPoints += currentTask.estimatedPoints;
            }
        })
    });
    console.log(`ToDo: ${todoPoints}pts`);
    let inProgressPoints = 0;
    Object.values(board).forEach((arr) => {
        arr.forEach((currentTask) => {
            if(currentTask.status === "In Progress"){
                inProgressPoints += currentTask.estimatedPoints;
            }
        })
    });
    console.log(`In Progress: ${inProgressPoints}pts`);
    let codeReviewPoints = 0;
    Object.values(board).forEach((arr) => {
        arr.forEach((currentTask) => {
            if(currentTask.status === "Code Review"){
                codeReviewPoints += currentTask.estimatedPoints;
            }
        })
    });
    console.log(`Code Review: ${codeReviewPoints}pts`);
    let donePoints = 0;
    Object.values(board).forEach((arr) => {
        arr.forEach((currentTask) => {
            if(currentTask.status === "Done"){
                donePoints += currentTask.estimatedPoints;
            }
        })
    });
    console.log(`Done Points: ${donePoints}pts`);
    const totalPointWithoutDone = inProgressPoints + codeReviewPoints + todoPoints;
    if(donePoints >= totalPointWithoutDone){
        console.log("Sprint was successful!");
    }
    else{
        console.log("Sprint was unsuccessful...");
    }

    function addNewTask(assignee, taskId, title, status, estimatedPoints){
        if(!board.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }
        board[assignee].push({
            taskId,
            title,
            status,
            estimatedPoints: Number(estimatedPoints),
        });
    }
    function changeTaskStatus(assignee, taskId, newStatus){
        if(!board.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }
        const task = board[assignee].find((t) => t.taskId === taskId);
        if(!task){
            console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
            return;
        }
        task.status = newStatus;
    }
    function removeTask(assignee, index){
        if(!board.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }
        if(index < 0 || index >= board[assignee].length){
            console.log("Index is out of range!");
            return;
        }
        board[assignee].splice(index, 1);
    }


};

solve([
    '5',
    'Kiril:BOP-1209:Fix MinorBug:ToDo:3',
    'Mariya:BOP-1210:Fix MajorBug:In Progress:3',
    'Peter:BOP-1211:POC:Code Review:5',
    'Georgi:BOP-1212:Investigation Task:Done:2',
    'Mariya:BOP-1213:New Account Page:In Progress:13',
    'Add New:Kiril:BOP-1217:AddInfo Page:In Progress:5',
    'Change Status:Peter:BOP1290:ToDo',
    'Remove Task:Mariya:1',
    'Remove Task:Joro:1',
    ]);
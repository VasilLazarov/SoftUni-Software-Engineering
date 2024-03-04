function calculateTicketPrice(typeOfDay, age){
    let ticketPrice;
    if(age < 0 || age > 122){
        console.log("Error!");
    }
    else if(age <= 18){
        switch(typeOfDay){
            case "Weekday":
                ticketPrice = 12;
                break;
            case "Weekend":
                ticketPrice = 15;
                break;
            case "Holiday":
                ticketPrice = 5;
                break;
        }
        console.log(`${ticketPrice}$`);
    }
    else if(age <= 64){
        switch(typeOfDay){
            case "Weekday":
                ticketPrice = 18;
                break;
            case "Weekend":
                ticketPrice = 20;
                break;
            case "Holiday":
                ticketPrice = 12;
                break;
        }
        console.log(`${ticketPrice}$`);
    }
    else if(age <= 122){
        switch(typeOfDay){
            case "Weekday":
                ticketPrice = 12;
                break;
            case "Weekend":
                ticketPrice = 15;
                break;
            case "Holiday":
                ticketPrice = 10;
                break;
        }
        console.log(`${ticketPrice}$`);
    }
}

calculateTicketPrice("Weekday", 42);
calculateTicketPrice("Holiday", -12);
calculateTicketPrice("Holiday", 15);
calculateTicketPrice("Weekend", 123);
calculateTicketPrice("Weekend", 120);
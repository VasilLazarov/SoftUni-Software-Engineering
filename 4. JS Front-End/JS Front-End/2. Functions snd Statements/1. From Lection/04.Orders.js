function calculateTotalPrice(product, quantity){
    const products ={
        coffee: 1.50,
        water:1.00,
        coke: 1.40,
        snacks: 2.00,
    };
    let totalPrice = products[product] * quantity;
    console.log(totalPrice.toFixed(2));
}
calculateTotalPrice('coke', 10);
calculateTotalPrice('water', 5);
calculateTotalPrice('coffee', 2);
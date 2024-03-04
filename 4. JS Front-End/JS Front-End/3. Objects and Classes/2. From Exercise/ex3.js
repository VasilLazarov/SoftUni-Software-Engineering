function solve(startingProducts, deliveredProducts){
    const products = {};
    for (let index = 0; index < startingProducts.length; index += 2 ) {
        
        products[startingProducts[index]] = Number(startingProducts[index + 1]);
    }
    for (let index = 0; index < deliveredProducts.length; index += 2 ) {
        if(!products.hasOwnProperty(deliveredProducts[index])){
            products[deliveredProducts[index]] = Number(deliveredProducts[index + 1]);
        }
        else{
            products[deliveredProducts[index]] += Number(deliveredProducts[index + 1]);
        }
    }
    Object.entries(products).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}

solve(
    [
    'Chips', '5', 'CocaCola', '9', 'Bananas', 
    '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 
    'Tomatoes', '70', 'Bananas', '30'
    ]
);
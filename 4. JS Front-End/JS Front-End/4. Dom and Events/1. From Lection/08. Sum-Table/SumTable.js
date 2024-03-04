function sumTable() {
    const prices = Array.from(document.querySelectorAll("tr td:nth-child(2)"));
    const lastRowForTotalPrize = prices.pop();

    /*let totalPrice = 0;
    for (const price of prices) {
        totalPrice += Number.parseFloat(price.textContent);
    }*/
    /*other way */
    const totalPrice = prices.reduce((acc, price) => {
        return acc + Number.parseFloat(price.textContent);
    }, 0);

    lastRowForTotalPrize.textContent = totalPrice.toFixed(2);
}
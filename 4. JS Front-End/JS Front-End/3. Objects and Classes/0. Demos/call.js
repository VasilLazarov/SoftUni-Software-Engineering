/*function Car(type, fuelType){
	this.type = type;
	this.fuelType = fuelType;
}

function setBrand(brand){
	Car.call(this, "convertible", "petrol");
	this.brand = brand;
	console.log(`Car details = `, this);
}

function definePrice(price){
	Car.call(this, "convertible", "diesel");
	this.price = price;
	console.log(`Car details = `, this);
}

const newBrand = new setBrand('Brand1');
const newCarPrice = new definePrice(100000);*/


function Product(name, price) {
	this.name = name;
	this.price = price;
  }
  
  function Food(name, price) {
	Product.call(this, name, price);
	this.category = 'food';
  }
  
  let ddz = new Food('cheese', 5);
  console.log(ddz.name);
  // Expected output: "cheese"

using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string input;
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputCMD = input.Split(' ');
                string serialNumber = inputCMD[0];
                string itemName = inputCMD[1];
                int itemQuantity = int.Parse(inputCMD[2]);
                decimal itemPrice = decimal.Parse(inputCMD[3]);
                Box newBox = new Box(serialNumber, itemName, itemQuantity, itemPrice);
                newBox.BoxPrice = itemPrice * itemQuantity;
                boxes.Add(newBox);
            }
            foreach(Box box in boxes.OrderByDescending(b => b.BoxPrice))
            {
                Console.WriteLine(box.ToString()); // with override ToString() in class Box(rows 55-60)
                //Console.WriteLine(box.SerialNumber);                                                     // other method 
                //Console.WriteLine($"-- {box.Item.Name} - ${box.Item.ItemPrice:f2}: {box.ItemQuantity}"); // without
                //Console.WriteLine($"-- ${box.BoxPrice:f2}");                                             // override 
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal ItemPrice { get; set; }
        
    }

    public class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal BoxPrice { get; set; }
        public Box(string serialNumber, string itemName, int itemQuantity, decimal itemPrice)
        {
            Item = new Item();
            this.SerialNumber = serialNumber;
            this.ItemQuantity = itemQuantity;
            this.Item.ItemPrice = itemPrice;
            this.Item.Name = itemName;
        }
        public override string ToString()
        {

            return $"{this.SerialNumber}{Environment.NewLine}-- {this.Item.Name} - ${this.Item.ItemPrice:f2}: {this.ItemQuantity}{Environment.NewLine}-- ${this.BoxPrice:f2}";
        }
    }
}

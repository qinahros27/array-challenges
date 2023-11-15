﻿/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

int[] CommonItems(int[][] jaggedArray)
{
    var commonItem = new List<int>();
    int[] storeItem = jaggedArray[0]; 
    for(int i = 1; i< jaggedArray.Length; i++) {
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            for(int k = 0; k<storeItem.Length; k ++) {
                if(jaggedArray[i][j] == storeItem[k]) {
                    bool alreadyExist = commonItem.Contains(storeItem[k]);
                    if(!alreadyExist) {
                        commonItem.Add(storeItem[k]);
                    }
                }
            }
        }
    }
    return commonItem.ToArray();
}
int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
//int[][] arr2 = { new int[] { 1, 2, 3 }, new int[] { 2, 1, 5 } , new int[] { 3, 4, 5 }};
//int[][] arr3 = { new int[] { 1, 2, 5, 6 }, new int[] { 2, 1, 5 } , new int[] { 3, 4, 5 }};
int[] arr1Common = CommonItems(arr1);
//int [] arr2Common = CommonItems(arr2);
//int [] arr3Common = CommonItems(arr3);

/* write method to print arr1Common */
Console.WriteLine(string.Join(";", arr1Common));

/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/

void InverseJagged(int[][] jaggedArray)
{
    for(int i = 0; i<jaggedArray.Length; i++) {
        var storeInverseItems = new List<int>();
        for(int j=jaggedArray[i].Length-1; j>=0; j--) {
            storeInverseItems.Add(jaggedArray[i][j]);
        }
        jaggedArray[i] = storeInverseItems.ToArray();
    }
}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);
// /* write method to print arr2 */
Console.WriteLine("Exercise 2: ");
for(int i=0; i< arr2.Length; i++) {
    Console.WriteLine("This is row " + i + ": " + string.Join(",", arr2[i]));
}

// /* 
// Challenge 3.Find the difference between 2 consecutive elements of an array.
// For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
// Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
//  */
void CalculateDiff(int[][] jaggedArray)
{
    for(int i = 0; i<jaggedArray.Length; i++) {
        int diff = 0;
        var storeItems = new List<int>();
        for(int j = 0; j<jaggedArray[i].Length-1; j++) {
            diff = jaggedArray[i][j] - jaggedArray[i][j+1]; 
            storeItems.Add(diff);
        }
        jaggedArray[i] = storeItems.ToArray();
    }
}
int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(arr3);

// /* write method to print arr3 */
Console.WriteLine("Exercise 3: ");
for(int i=0; i< arr3.Length; i++) {
    Console.WriteLine("This is row " + i + ": " + string.Join(",", arr3[i]));
}

// /* 
// Challenge 4. Inverse column/row of a rectangular array.
// For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
// Expected result: {{1,4},{2,5},{3,6}}
//  */
int[,] InverseRec(int[,] recArray)
{
    int[,] intArray = new int[recArray.GetLength(1), recArray.GetLength(0)];
    for(int i = 0 ; i<recArray.GetLength(0) ; i++) {
        for(int j =0; j<recArray.GetLength(1); j++) {
            intArray[j,i] = recArray[i,j];
        }
    }
    return intArray;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);
// /* write method to print arr4Inverse */
Console.WriteLine("Exercise 4: ");
string row = string.Empty;
for(int i = 0 ; i<arr4Inverse.GetLength(0) ; i++) {
        for(int j =0; j<arr4Inverse.GetLength(1); j++) {
            row += arr4Inverse[i,j] +  " ";
        }
        row += "\n";
}
Console.WriteLine(row);
// /* 
// Challenge 5. Write a function that accepts a variable number of params of any of these types: 
// string, number. 
// - For strings, join them in a sentence. 
// - For numbers then sum them up. 
// - Finally print everything out. 
// Example: Demo("hello", 1, 2, "world") 
// Expected result: hello world; 3 */
void Demo(params object[] args)
{
    string sentence = string.Empty;
    int sum = 0;
    foreach(object arg in args) {
        if(arg is string) {
            sentence = sentence + arg+ " ";
        }
        else if (arg is int){
            sum = sum + Convert.ToInt32(arg);
        }
    }
    Console.WriteLine(sentence + "; " + sum);
}
Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


// /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
// and if they’re string, lengths have to be more than 5. 
// If they’re numbers, they have to be more than 18. */
void SwapTwo<T>(ref T arg1, ref T arg2) 
{
    if(arg1 != null  && arg2 != null) {
        if(arg1.GetType() == arg2.GetType()){
            if(arg1.GetType() == typeof(string)) {
                if(arg1.ToString().Length > 5 && arg2.ToString().Length >  5) {
                    T storeString = arg1;
                    arg1 = arg2;
                    arg2 = storeString;
                }
                else {
                    Console.WriteLine("The string's length have to be more than 5.");
                }
            }
            else if (arg1.GetType() == typeof(int)) {
                if(Convert.ToInt32(arg1) > 18 && Convert.ToInt32(arg2) > 18) {
                    T storeNum = arg1;
                    arg1 = arg2;
                    arg2 = storeNum;
                }
                else {
                    Console.WriteLine("Number have to be more than 18");
                }
            }
        }
    }
}
string s1 = "helloworld";
string s2 = "hifriend";
int n1 = 19;
int n2 = 20;
SwapTwo(ref s1, ref s2);
Console.WriteLine("This is s1: " + s1);
Console.WriteLine("This is s2: " +  s2);
SwapTwo(ref n1, ref n2);
Console.WriteLine("This is n1: " + n1.ToString());
Console.WriteLine("This is n2: " + n2.ToString());

// /* Challenge 7. Write a function that does the guessing game. 
// The function will think of a random integer number (lets say within 100) 
// and ask the user to input a guess. 
// It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
    Random rnd = new Random();
    int randomNumber = rnd.Next(100);
    bool isCorrect = false;
    while(!isCorrect) {
        Console.Write("Enter you guessing number (1-100): ");
        int guessingNumber = Convert.ToInt32(Console.ReadLine());
        if(guessingNumber < randomNumber) {
            Console.WriteLine($"Your guess, {guessingNumber} , is too low.");
        }
        else if (guessingNumber > randomNumber) {
            Console.WriteLine($"Your guess, {guessingNumber} , is too high.");
        }
        else if (guessingNumber == randomNumber) {
            Console.WriteLine("Congrat !!! You are correct.");
            isCorrect = true;
        }
    }
}
GuessingGame();

// /* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
// Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

// get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1..3];
Console.WriteLine(subCart);
Console.WriteLine(cart);

class Product
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }

    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
    }

    /* Override ToString() method so the item can be printed out conveniently with Id, Price, and Quantity */
    public override string ToString()
    {
        return $"Id: {Id}, Price: {Price}, Quantity: {Quantity}";
    }
}

class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    /* Write indexer property to get nth item from _cart */
    public OrderItem this[int index]
    {
        get
        {
            if (index >= 0 && index < _cart.Count)
                return _cart[index];
            else
                throw new IndexOutOfRangeException();
        }
    }

    /* Write indexer property to get items of a range from _cart */
    public List<OrderItem> this[Range range]
    {
        get
        {
            var (start, length) = range.GetOffsetAndLength(_cart.Count);
            return _cart.GetRange(start, length);
        }
    }

    public void AddToCart(params OrderItem[] items)
    {
        /* this method should check if each item exists --> increase value / or else, add item to cart */
        for(int i=0; i<items.Length; i++) {
            int indexcheck = Index(items[i]);
            if(indexcheck != 0) {
                int index = Index(items[i]);
                _cart[index].Quantity += items[i].Quantity;
            }
            else {
                _cart.Add(items[i]);
            }
        }
    }
    /* Write another method called Index */
    public int Index(OrderItem item) 
    {   
        int num = 0;
        for(int i = 0; i < _cart.Count ; i++) {
            if(_cart[i].Id == item.Id) {
                num = i;
                break;
            }
        }
        return num;
    }
    
    /* Write another method called GetCartInfo(), which out put 2 values: 
    total price, total products in cart*/
    public void GetCartInfo(out int totalPrice , out int totalProduct) {
        totalPrice = 0;
        totalProduct = 0;
        for(int i = 0 ; i < _cart.Count ; i++) {
            totalPrice += _cart[i].Price * _cart[i].Quantity;
            totalProduct += _cart[i].Quantity;
        }
    }

    /* Override ToString() method so Console.WriteLine(cart) can print
    id, unit price, unit quantity of each item*/
    public override string ToString()
    {
       string cartString = string.Empty; 
       for(int i = 0; i<_cart.Count  ; i++) {
            cartString += _cart[i] + "\n";
       }
       return cartString;
    }
}

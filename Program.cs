using System;
using System.Collections.Generic;
using System.Linq;

namespace linq {

    public class Bank {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
    public class MillionaireEntry {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
        public IEnumerable<string> Millionaires { get; set; }

    }
    class Program {
        static void Main (string[] args) {

            ///Part 1 

            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string> () { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
            where fruit.StartsWith ("L")
            select fruit;

            // foreach (string fruit in LFruits) {
            //     Console.WriteLine (fruit);
            // }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where (
                n => n % 4 == 0 && n % 6 == 0);

            // foreach (int n in fourSixMultiples) {
            //     Console.WriteLine(n);
            // }

            ///Part 2

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string> () {
                "Heather",
                "James",
                "Xavier",
                "Michelle",
                "Brian",
                "Nina",
                "Kathleen",
                "Sophia",
                "Amir",
                "Douglas",
                "Zarley",
                "Beatrice",
                "Theodora",
                "William",
                "Svetlana",
                "Charisse",
                "Yolanda",
                "Gregorio",
                "Jean-Paul",
                "Evangelina",
                "Viktor",
                "Jacqueline",
                "Francisco",
                "Tre"
            };

            IEnumerable<string> nameInDesc = from name in names
            orderby name
            orderby name descending
            select name;

            // foreach (string name in nameInDesc) {
            //     Console.WriteLine(name);
            // }

            // Build a collection of these numbers sorted in ascending order
            List<int> newNumbers = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            IEnumerable<int> newNumbersInAscend = from num in newNumbers
            orderby num ascending
            select num;

            // foreach (int num in newNumbersInAscend) {
            //     Console.WriteLine(num);
            // }

            ///Part 3

            // Output how many numbers are in this list
            List<int> partThreeNumbers = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            // Console.WriteLine($"Amount {partThreeNumbers.Count()}");

            // How much money have we made?
            List<double> purchases = new List<double> () {
                2340.29,
                745.31,
                21.76,
                34.03,
                4786.45,
                879.45,
                9442.85,
                2454.63,
                45.65
            };

            // Console.WriteLine($"These is the purchase sum {purchases.Sum()}");

            // What is our most expensive product?
            List<double> prices = new List<double> () {
                879.45,
                9442.85,
                2454.63,
                45.65,
                2340.29,
                34.03,
                4786.45,
                745.31,
                21.76
            };

            // Console.WriteLine($"These is the highest price: {purchases.Max()}");

            ////Part 4 

            /*
    Store each number in the following List until a perfect square
    is detected.

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/
            List<int> wheresSquaredo = new List<int> () {
                66,
                12,
                8,
                27,
                82,
                34,
                7,
                50,
                19,
                46,
                81,
                23,
                30,
                4,
                68,
                14
            };

            List<int> nonSquares = wheresSquaredo.TakeWhile (n => Math.Sqrt (n) % 1 != 0).ToList ();
            // foreach (var item in nonSquares)
            // {
            //     Console.WriteLine(item.ToString());
            // }

            List<Customer> customers = new List<Customer> () {
                new Customer () { Name = "Bob Lesman", Balance = 80345.66, Bank = "FTB" },
                new Customer () { Name = "Joe Landy", Balance = 9284756.21, Bank = "WF" },
                new Customer () { Name = "Meg Ford", Balance = 487233.01, Bank = "BOA" },
                new Customer () { Name = "Peg Vale", Balance = 7001449.92, Bank = "BOA" },
                new Customer () { Name = "Mike Johnson", Balance = 790872.12, Bank = "WF" },
                new Customer () { Name = "Les Paul", Balance = 8374892.54, Bank = "WF" },
                new Customer () { Name = "Sid Crosby", Balance = 957436.39, Bank = "FTB" },
                new Customer () { Name = "Sarah Ng", Balance = 56562389.85, Bank = "FTB" },
                new Customer () { Name = "Tina Fey", Balance = 1000000.00, Bank = "CITI" },
                new Customer () { Name = "Sid Brown", Balance = 49582.68, Bank = "CITI" }
            };

            IEnumerable<MillionaireEntry> groupedByBank = customers.Where (c => c.Balance >= 1000000).GroupBy (
                p => p.Bank, // Group banks
                p => p.Name, // by millionaire names
                (bank, millionaires) => new MillionaireEntry () {
                    Bank = bank,
                        Millionaires = millionaires
                }
            );

            // foreach (var item in groupedByBank) {
            //     Console.WriteLine ($"{item.Bank}: {string.Join(" and ", item.Millionaires.Count())}");
            // }

            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            List<Customer> millionaireReport = customers.Where (c => c.Balance >= 1000000)
                .Select (c => new Customer () {
                    Name = c.Name,
                        Bank = banks.Find(b => b.Symbol == c.Bank).Name,
                        Balance = c.Balance
                })
                .ToList ();

            foreach (Customer customer in millionaireReport) {
                Console.WriteLine ($"{customer.Name} at {customer.Bank}");
            }

        }
    }
}
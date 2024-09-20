using System;

namespace Coding.Exercise
{
    internal class Program
    {
        public delegate void StockPriceChangedHandler(string message);

        public class Stock
        {
            // The outside class can only see the delegate
            public event StockPriceChangedHandler OnStockPriceChanged;

            private decimal _price; 
            
            private decimal _threshold;
            //The fields are backed by the propeties with custom getter and setters

            // TODO: Implement the Price property with event triggering

            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (_price < Threshold)
                    {
                        //Raise Event here

                        RaiseStockPriceChangedEvent($"Stock price is below threshold!");
                    }
                }
            }


            // TODO: Implement the Threshold property

            public decimal Threshold
            {
                get { return _threshold; }
                set
                {
                    _threshold = value;
                }
            }

            // TODO: Implement the RaiseStockPriceChangedEvent method

            //The method which Invokes the message is hidden to outside classes 
            protected virtual void RaiseStockPriceChangedEvent(string message)
            {
                OnStockPriceChanged?.Invoke(message);
            }

        }

        public class StockAlert
        {
            // TODO: Implement the OnStockPriceChanged method
            //On-Prefix dentoes that method will be a Subscriber to the event

            //Subscriber class that has no access to the methods of the class Stock
            public void OnStockPriceChanged(string message)
            {
                Console.WriteLine("Stock Alert: " + message);

            }
        }

        public class Exercise
        {
            public static void TestStockPriceAlerts()
            {
                // TODO: Implement the stock price alert test

                //Input and output file

                //Instantiate the classes
                Stock stock = new Stock();
                StockAlert alert = new StockAlert();

                //Subscribe to the event
                stock.OnStockPriceChanged += alert.OnStockPriceChanged;

                //Dynamic input which can also be inputted by the user or be scrapped via a wesbite

                stock.Threshold = 120m;
                stock.Price = 130m;
                stock.Price = 150m;
                stock.Price = 110m;


            }


        }

        public static void Main()
        {
            //Runfile Thread
            //Call the static method wihtout creating an instance of the class

            Exercise.TestStockPriceAlerts();
        }
    }
}
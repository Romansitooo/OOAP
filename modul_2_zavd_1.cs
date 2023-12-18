using System;
using System.Collections.Generic;
using System.IO;

class SaleCounter
{
    private static SaleCounter _instance;
    private static readonly object lockObject = new object();

    private bool _initialized = false;

    private Dictionary<string, int> _salesCount;
    private double _totalSalesValue;
    private StreamWriter _logFile;

    private SaleCounter()
    {
        if (!_initialized)
        {
            _salesCount = new Dictionary<string, int>
            {
                { "Food", 0 },
                { "Medicine", 0 },
                { "Clothing", 0 }
            };

            _totalSalesValue = 0;
            _logFile = new StreamWriter("sales_log.txt", true);

            _initialized = true;
        }
    }

    public static SaleCounter Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new SaleCounter();
                    }
                }
            }

            return _instance;
        }
    }

    public void SellProduct(string productGroup, int quantity)
    {
        double priceMultiplier = 1.0;

        switch (productGroup)
        {
            case "Food":
                priceMultiplier += 0.05;
                break;
            case "Medicine":
                priceMultiplier += 0.1;
                break;
            case "Clothing":
                priceMultiplier += 0.15;
                break;
            default:
                throw new ArgumentException("Invalid product group");
        }

        Random random = new Random();
        double productPrice = random.Next(10, 100) * priceMultiplier;
        double totalPrice = productPrice * quantity;

        _salesCount[productGroup] += quantity;
        _totalSalesValue += totalPrice;

        string logEntry = $"{DateTime.Now} - Sold {quantity} {productGroup} items for a total of ${totalPrice:F2}\n";
        _logFile.WriteLine(logEntry);
    }

    public void CloseLogFile()
    {
        _logFile.Close();
    }

    public void DisplayStatistics()
    {
        Console.WriteLine($"Sales Count: Food = {_salesCount["Food"]}, Medicine = {_salesCount["Medicine"]}, Clothing = {_salesCount["Clothing"]}");
        Console.WriteLine($"Total Sales Value: ${_totalSalesValue:F2}");
    }
}

class Program
{
    static void Main()
    {
        //використання лічильника продажів
        SaleCounter counter = SaleCounter.Instance;

        //продаж продуктів
        counter.SellProduct("Food", 5);
        counter.SellProduct("Medicine", 3);
        counter.SellProduct("Clothing", 2);

        //виведення статистики
        counter.DisplayStatistics();

        //закриття файлу логу
        counter.CloseLogFile();
    }
}

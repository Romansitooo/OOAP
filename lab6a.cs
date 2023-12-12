using System;
using System.Collections.Generic;
using System.IO;

// Шаблон Одинак
public sealed class SalesCounter
{
    private static readonly SalesCounter instance = new SalesCounter();

    // Рання ініціалізація
    static SalesCounter() { }

    private SalesCounter() { }

    public static SalesCounter Instance
    {
        get
        {
            return instance;
        }
    }

    public void RecordSale(string productGroup, int quantity, double basePrice)
    {
        double additionalCharge = 0;

        // Визначення надбавки в залежності від групи товарів
        switch (productGroup.ToLower())
        {
            case "food":
                additionalCharge = 0.05;
                break;
            case "medicine":
                additionalCharge = 0.10;
                break;
            case "clothing":
                additionalCharge = 0.15;
                break;
            default:
                throw new ArgumentException("Invalid product group.");
        }

        // Розрахунок вартості
        double totalCost = (1 + additionalCharge) * quantity * basePrice;

        // Запис у файл
        string saleRecord = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - Group: {productGroup}, Quantity: {quantity}, Total Cost: {totalCost:C}\n";
        File.AppendAllText("SalesLog.txt", saleRecord);
    }
}

class Program
{
    static void Main()
    {
        // Продажі продуктів харчування
        SalesCounter.Instance.RecordSale("food", 100, 2.5);

        // Продажі ліків
        SalesCounter.Instance.RecordSale("medicine", 50, 10.0);

        // Продажі одягу
        SalesCounter.Instance.RecordSale("clothing", 20, 30.0);

        Console.WriteLine("Sales recorded. Check SalesLog.txt for details.");
    }
}

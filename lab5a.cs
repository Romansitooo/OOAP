using System;

// Інтерфейс для клієнта
public interface IClient
{
    void ProcessPurchase();
}

// Реалізація для клієнта, який купує авто з повною оплатою
public class CashClient : IClient
{
    public void ProcessPurchase()
    {
        Console.WriteLine("Оформлення покупки за готівку клієнта...");
        // Логіка для клієнта, що купує з повною оплатою
    }
}

// Реалізація для клієнта, який купує авто у кредит
public class CreditClient : IClient
{
    public void ProcessPurchase()
    {
        Console.WriteLine("Оформлення покупки для кредитного клієнта...");
        // Логіка для клієнта, що купує у кредит
    }
}

// Реалізація для клієнта, який купує авто з розтермінуванням
public class InstallmentClient : IClient
{
    public void ProcessPurchase()
    {
        Console.WriteLine("Оформлення покупки для клієнта в розстрочку...");
        // Логіка для клієнта, що купує з розтермінуванням
    }
}

// Фабричний метод для створення об'єктів клієнтів
public interface IClientFactory
{
    IClient CreateClient();
}

// Реалізація фабрики для створення об'єктів клієнтів з повною оплатою
public class CashClientFactory : IClientFactory
{
    public IClient CreateClient()
    {
        return new CashClient();
    }
}

// Реалізація фабрики для створення об'єктів клієнтів у кредит
public class CreditClientFactory : IClientFactory
{
    public IClient CreateClient()
    {
        return new CreditClient();
    }
}

// Реалізація фабрики для створення об'єктів клієнтів з розтермінуванням
public class InstallmentClientFactory : IClientFactory
{
    public IClient CreateClient()
    {
        return new InstallmentClient();
    }
}

class Program
{
    static void Main()
    {
        // Використання фабричних методів для створення об'єктів клієнтів
        IClientFactory cashClientFactory = new CashClientFactory();
        IClient cashClient = cashClientFactory.CreateClient();
        cashClient.ProcessPurchase();

        IClientFactory creditClientFactory = new CreditClientFactory();
        IClient creditClient = creditClientFactory.CreateClient();
        creditClient.ProcessPurchase();

        IClientFactory installmentClientFactory = new InstallmentClientFactory();
        IClient installmentClient = installmentClientFactory.CreateClient();
        installmentClient.ProcessPurchase();
    }
}

//zavd 1 
using System;

//інтерфейс абстракції
public interface IAlarmC
{
    void Start();
    void Stop();
    void ToWake();
}

//інтерфейс реалізації
public interface IAlarmCImpl
{
    void Ring();
    void Notify();
}

//клас абстракції
public class BasicAlarmC : IAlarmC
{
    protected IAlarmCImpl implementation;

    public BasicAlarmC(IAlarmCImpl implementation)
    {
        this.implementation = implementation;
    }

    public void Start()
    {
        Console.WriteLine("Спрацював будильник.");
    }

    public void Stop()
    {
        Console.WriteLine("Будильник зупинився.");
    }

    public void ToWake()
    {
        implementation.Ring();
        implementation.Notify();
    }
}

//клас реалізації
public class AdvancedAlarmC : IAlarmCImpl
{
    public void Ring()
    {
        Console.WriteLine("Дзвін будильника.");
    }

    public void Notify()
    {
        Console.WriteLine("Повідомлення користувача.");
    }
}

class Program
{
    static void Main()
    {
        //створення об'єкта реалізації
        IAlarmCImpl alarmImplementation = new AdvancedAlarmC();

        //створення об'єкта абстракції і передача реалізації
        IAlarmC alarm = new BasicAlarmC(alarmImplementation);

        //використання будильника
        alarm.Start();
        alarm.ToWake();
        alarm.Stop();
    }
}

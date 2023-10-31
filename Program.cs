using System;

class Employee{
    public string Name { get; }
    public string Position { get; }
    public Func<double> CalculateSalary { get; set; }

    public Employee(string name, string position){
        Name = name;
        Position = position;
    }
}

class Program{
    static void Main(string[] args){
        // створення парцівників та делегатів
        Employee departmentHead = new Employee("Рома", "Начальник вiддiлу");
        departmentHead.CalculateSalary = () => CalculateDepartmentHeadSalary();

        Employee chiefEngineer = new Employee("Андрiй", "Головний iнженер");
        chiefEngineer.CalculateSalary = () => CalculateChiefEngineerSalary();

        Employee programmer = new Employee("Катя", "програмiст");
        programmer.CalculateSalary = () => CalculateProgrammerSalary();

        Employee sysAdmin = new Employee("Iван", "Системний адмiнiстратор");
        sysAdmin.CalculateSalary = () => CalculateSystemAdministratorSalary();

        Console.WriteLine($"{departmentHead.Name} ({departmentHead.Position}): {departmentHead.CalculateSalary()}");
        Console.WriteLine($"{chiefEngineer.Name} ({chiefEngineer.Position}): {chiefEngineer.CalculateSalary()}");
        Console.WriteLine($"{programmer.Name} ({programmer.Position}): {programmer.CalculateSalary()}");
        Console.WriteLine($"{sysAdmin.Name} ({sysAdmin.Position}): {sysAdmin.CalculateSalary()}");
    }

    // ЗП
    static double CalculateDepartmentHeadSalary(){
        return 10000.0;
    }

    static double CalculateChiefEngineerSalary(){
        return 9000.0;
    }

    static double CalculateProgrammerSalary(){
        return 8000.0;
    }

    static double CalculateSystemAdministratorSalary(){
        return 7500.0;
    }
}
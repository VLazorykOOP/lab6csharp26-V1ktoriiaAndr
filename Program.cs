using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

interface IPersonalData
{
    string FirstName { get; set; }
    string LastName { get; set; }
    int Age { get; set; }
    void ShowData();
}

interface IAcademicOperations
{
    void PerformAcademicWork();
}

interface IAdministrativeOperations
{
    void PerformAdministrativeWork();
}

class Student : IPersonalData, IAcademicOperations, IComparable<Student>
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int Age { get; set; }
    public string Group { get; set; } = "";
    public double AverageGrade { get; set; }

    public Student(string firstName, string lastName, int age, string group, double averageGrade)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Group = group;
        AverageGrade = averageGrade;
    }

    public void ShowData()
    {
        Console.WriteLine($"Студент: {FirstName} {LastName}, Вік: {Age}, Група: {Group}, Середній бал: {AverageGrade}");
    }

    public void PerformAcademicWork()
    {
        Console.WriteLine($"{FirstName} виконує домашнє завдання");
    }

    public void TakeExam()
    {
        Console.WriteLine($"{FirstName} здає екзамен");
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return AverageGrade.CompareTo(other.AverageGrade);
    }
}

class Teacher : IPersonalData, IAcademicOperations, IComparable<Teacher>
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int Age { get; set; }
    public string Department { get; set; } = "";
    public string Position { get; set; } = "";
    public int Experience { get; set; }

    public Teacher(string firstName, string lastName, int age, string department, string position, int experience)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Department = department;
        Position = position;
        Experience = experience;
    }

    public void ShowData()
    {
        Console.WriteLine($"Викладач: {FirstName} {LastName}, Вік: {Age}, Кафедра: {Department}, Посада: {Position}, Стаж: {Experience} років");
    }

    public void PerformAcademicWork()
    {
        Console.WriteLine($"{FirstName} проводить лекцію");
    }

    public void CheckWorks()
    {
        Console.WriteLine($"{FirstName} перевіряє студентські роботи");
    }

    public int CompareTo(Teacher? other)
    {
        if (other == null) return 1;
        return Experience.CompareTo(other.Experience);
    }
}

class DepartmentHead : IPersonalData, IAcademicOperations, IAdministrativeOperations, IComparable<DepartmentHead>
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int Age { get; set; }
    public string Department { get; set; } = "";
    public string Position { get; set; } = "";
    public int Experience { get; set; }
    public int TeachersCount { get; set; }

    public DepartmentHead(string firstName, string lastName, int age, string department, string position, int experience, int teachersCount)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Department = department;
        Position = position;
        Experience = experience;
        TeachersCount = teachersCount;
    }

    public void ShowData()
    {
        Console.WriteLine($"Завідувач кафедри: {FirstName} {LastName}, Вік: {Age}, Кафедра: {Department}, Посада: {Position}, Стаж: {Experience} років, Викладачів: {TeachersCount}");
    }

    public void PerformAcademicWork()
    {
        Console.WriteLine($"{FirstName} проводить наукову роботу");
    }

    public void PerformAdministrativeWork()
    {
        Console.WriteLine($"{FirstName} керує кафедрою");
    }

    public void HoldMeeting()
    {
        Console.WriteLine($"{FirstName} проводить засідання кафедри");
    }

    public int CompareTo(DepartmentHead? other)
    {
        if (other == null) return 1;
        return TeachersCount.CompareTo(other.TeachersCount);
    }
}

interface IFigure : IComparable<IFigure>, ICloneable
{
    double CalculateArea();
    double CalculatePerimeter();
    void ShowInfo();
}

class Rectangle : IFigure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Прямокутник: Ширина = {Width}, Висота = {Height}, Площа = {CalculateArea():F2}, Периметр = {CalculatePerimeter():F2}");
    }

    public int CompareTo(IFigure? other)
    {
        if (other == null) return 1;
        return CalculateArea().CompareTo(other.CalculateArea());
    }

    public object Clone()
    {
        return new Rectangle(Width, Height);
    }

    public bool IsSquare()
    {
        return Math.Abs(Width - Height) < 0.001;
    }
}

class Circle : IFigure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Коло: Радіус = {Radius}, Площа = {CalculateArea():F2}, Периметр = {CalculatePerimeter():F2}");
    }

    public int CompareTo(IFigure? other)
    {
        if (other == null) return 1;
        return CalculateArea().CompareTo(other.CalculateArea());
    }

    public object Clone()
    {
        return new Circle(Radius);
    }

    public double CalculateDiameter()
    {
        return 2 * Radius;
    }
}

class Triangle : IFigure
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double CalculateArea()
    {
        double p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    public double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Трикутник: Сторони = {SideA}, {SideB}, {SideC}, Площа = {CalculateArea():F2}, Периметр = {CalculatePerimeter():F2}");
    }

    public int CompareTo(IFigure? other)
    {
        if (other == null) return 1;
        return CalculateArea().CompareTo(other.CalculateArea());
    }

    public object Clone()
    {
        return new Triangle(SideA, SideB, SideC);
    }

    public bool IsRightAngled()
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.001;
    }
}

class NegativeAreaException : Exception
{
    public NegativeAreaException() : base("Площа не може бути від'ємною") { }
    public NegativeAreaException(string message) : base(message) { }
}

class InvalidFigureParametersException : Exception
{
    public InvalidFigureParametersException() : base("Параметри фігури невалідні") { }
    public InvalidFigureParametersException(string message) : base(message) { }
}

class FigureCollection : IEnumerable<IFigure>
{
    private List<IFigure> figures = new List<IFigure>();

    public void Add(IFigure figure)
    {
        figures.Add(figure);
    }

    public IEnumerator<IFigure> GetEnumerator()
    {
        return figures.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => figures.Count;
}

class Program
{
    static void CallSpecificMethods(object obj)
    {
        switch (obj)
        {
            case Student student:
                student.TakeExam();
                break;
            case Teacher teacher:
                teacher.CheckWorks();
                break;
            case DepartmentHead head:
                head.HoldMeeting();
                break;
            case Rectangle rectangle:
                Console.WriteLine($"Це квадрат: {rectangle.IsSquare()}");
                break;
            case Circle circle:
                Console.WriteLine($"Діаметр кола: {circle.CalculateDiameter():F2}");
                break;
            case Triangle triangle:
                Console.WriteLine($"Це прямокутний трикутник: {triangle.IsRightAngled()}");
                break;
            default:
                Console.WriteLine("Невідомий тип об'єкта");
                break;
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("============================================");
        Console.WriteLine("ЗАВДАННЯ 1: Перебудована ієрархія з інтерфейсами");
        Console.WriteLine("============================================\n");

        IPersonalData[] people = new IPersonalData[]
        {
            new Student("Іван", "Петренко", 20, "КН-21", 4.5),
            new Student("Марія", "Сидоренко", 19, "КН-22", 4.8),
            new Teacher("Олександр", "Коваленко", 45, "Програмування", "Доцент", 15),
            new Teacher("Наталія", "Іваненко", 38, "Математика", "Старший викладач", 10),
            new DepartmentHead("Петро", "Шевченко", 55, "Комп'ютерні науки", "Завідувач", 25, 15)
        };

        Console.WriteLine("Виклик інтерфейсних методів:\n");
        foreach (var person in people)
        {
            person.ShowData();
        }

        Console.WriteLine("\nВиклик академічних операцій:\n");
        IAcademicOperations[] academic = new IAcademicOperations[]
        {
            new Student("Іван", "Петренко", 20, "КН-21", 4.5),
            new Teacher("Олександр", "Коваленко", 45, "Програмування", "Доцент", 15),
            new DepartmentHead("Петро", "Шевченко", 55, "Комп'ютерні науки", "Завідувач", 25, 15)
        };

        foreach (var person in academic)
        {
            person.PerformAcademicWork();
        }

        Console.WriteLine("\nВиклик особистих методів (type pattern):\n");
        foreach (var person in people)
        {
            CallSpecificMethods(person);
        }

        Console.WriteLine("\n============================================");
        Console.WriteLine("ЗАВДАННЯ 2: Figure з інтерфейсами .NET");
        Console.WriteLine("============================================\n");

        IFigure[] figures = new IFigure[]
        {
            new Rectangle(5, 10),
            new Rectangle(7, 7),
            new Circle(4),
            new Circle(6.5),
            new Triangle(3, 4, 5),
            new Triangle(6, 8, 10)
        };

        Console.WriteLine("Інформація про фігури:\n");
        foreach (var figure in figures)
        {
            figure.ShowInfo();
        }

        Console.WriteLine("\nСортування фігур за площею (IComparable):\n");
        Array.Sort(figures);
        foreach (var figure in figures)
        {
            Console.WriteLine($"{figure.GetType().Name}: Площа = {figure.CalculateArea():F2}");
        }

        Console.WriteLine("\nКлонування фігури (ICloneable):\n");
        var original = figures[0];
        var clone = (IFigure)original.Clone();
        Console.WriteLine("Оригінал:");
        original.ShowInfo();
        Console.WriteLine("Клон:");
        clone.ShowInfo();

        Console.WriteLine("\nВиклик особистих методів для фігур (type pattern):\n");
        foreach (var figure in figures)
        {
            CallSpecificMethods(figure);
        }

        Console.WriteLine("\n============================================");
        Console.WriteLine("ЗАВДАННЯ 3: Обробка винятків");
        Console.WriteLine("============================================\n");

        try
        {
            Console.WriteLine("Спроба створити масив неправильного типу...");
            object[] array = new string[5];
            array[0] = "Рядок";
            array[1] = 123;
        }
        catch (ArrayTypeMismatchException ex)
        {
            Console.WriteLine($"Помилка ArrayTypeMismatchException: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nСпроба створити трикутник з невалідними сторонами...");
            var invalid = new Triangle(-1, 2, 3);
            if (invalid.SideA < 0 || invalid.SideB < 0 || invalid.SideC < 0)
            {
                throw new InvalidFigureParametersException("Сторони трикутника не можуть бути від'ємними");
            }
        }
        catch (InvalidFigureParametersException ex)
        {
            Console.WriteLine($"Власний виняток: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nСпроба обчислити площу з невалідними параметрами...");
            var rect = new Rectangle(5, 5);
            double area = rect.CalculateArea();
            if (area < 0)
            {
                throw new NegativeAreaException($"Обчислена площа {area} є від'ємною");
            }
            Console.WriteLine($"Площа успішно обчислена: {area}");
        }
        catch (NegativeAreaException ex)
        {
            Console.WriteLine($"Власний виняток: {ex.Message}");
        }

        Console.WriteLine("\n============================================");
        Console.WriteLine("ЗАВДАННЯ 4: IEnumerable для foreach");
        Console.WriteLine("============================================\n");

        FigureCollection collection = new FigureCollection();
        collection.Add(new Rectangle(5, 10));
        collection.Add(new Circle(3));
        collection.Add(new Triangle(3, 4, 5));

        Console.WriteLine($"Колекція містить {collection.Count} фігур:\n");
        foreach (var figure in collection)
        {
            figure.ShowInfo();
        }

        Console.WriteLine("\nПрограма завершена.");
    }
}

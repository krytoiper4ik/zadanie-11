using System;

namespace ConsoleApp11
{
    class Program
    {
        // 1. Создание структуры Point с полями x и y типа double
        struct Point
        {
            public double x;
            public double y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        // 2. Инициализация структуры Rectangle с полями width и height
        struct Rectangle
        {
            public int width;
            public int height;

            public Rectangle(int width, int height)
            {
                this.width = width;
                this.height = height;
            }

            // 3. Метод для расчета площади
            public int GetArea()
            {
                return width * height;
            }
        }

        // 4. Объявление enum для дней недели
        enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        // 6. Enum Colors с базовым типом byte
        enum Colors : byte
        {
            Red,
            Green,
            Blue
        }

        // 7. Enum для прав доступа с флагами
        [Flags]
        enum AccessRights
        {
            Read = 1,
            Write = 2,
            Execute = 4
        }

        // 8. Enum Status с комментариями
        enum Status
        {
            Pending,         // Ожидает выполнения
            InProgress,      // В процессе выполнения
            Completed,       // Завершено
            Error            // Ошибка
        }

        // 9. Структура Employee с полем Department (enum)
        enum Department
        {
            IT,
            Sales,
            Marketing
        }

        struct Employee
        {
            public string Name;
            public double Salary;
            public Department Department;

            public Employee(string name, double salary, Department department)
            {
                Name = name;
                Salary = salary;
                Department = department;
            }
        }

        static void Main(string[] args)
        {
            // 1. Создание экземпляра структуры Point
            Point p = new Point(5.5, 10.5);
            Console.WriteLine($"Point: x = {p.x}, y = {p.y}");

            // 2. Инициализация структуры Rectangle
            Rectangle r = new Rectangle(10, 5);
            Console.WriteLine($"Rectangle: Width = {r.width}, Height = {r.height}");

            // 3. Площадь прямоугольника
            Console.WriteLine($"Area of Rectangle: {r.GetArea()}");

            // 4. Использование enum для дня недели
            Console.Write("Enter the day number (1-7): ");
            int dayNumber = int.Parse(Console.ReadLine());
            DayOfWeek day = (DayOfWeek)(dayNumber - 1);
            Console.WriteLine($"The day is: {day}");

            // 6. Размер enum Colors
            Console.WriteLine($"Size of Colors enum: {sizeof(Colors)} bytes");

            // 7. Использование флагов для прав доступа
            AccessRights rights = AccessRights.Read | AccessRights.Write;
            Console.WriteLine($"Access rights: {rights}");

            // 8. Пример использования enum Status
            Status currentStatus = Status.InProgress;
            Console.WriteLine($"Current Status: {currentStatus}");

            // 9. Пример использования структуры Employee
            Employee e = new Employee("Alice", 50000, Department.IT);
            Console.WriteLine($"{e.Name} works in {e.Department} with a salary of {e.Salary}");

            // 10. Копирование структуры Point и изменение во второй структуре
            Point p2 = p;  // Копирование структуры
            p2.x = 20.0;   // Изменение значения в p2
            Console.WriteLine($"p1: x = {p.x}, y = {p.y}");
            Console.WriteLine($"p2: x = {p2.x}, y = {p2.y}");
            // 11. Попытка изменить readonly поле
            // Эта часть не будет работать, потому что readonly поля не могут быть изменены
            // p.x = 100.0; // Ошибка компиляции

            // 12. Неизменяемая структура Date
            Date date = new Date(15, 12, 2024);
            Date newDate = date.SetDay(16);  // Создание нового объекта
            Console.WriteLine($"Old Date: {date.Day}/{date.Month}/{date.Year}");
            Console.WriteLine($"New Date: {newDate.Day}/{newDate.Month}/{newDate.Year}");
        }
    }

    // 12. Неизменяемая структура Date
    struct Date
    {
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public Date SetDay(int day) => new Date(day, Month, Year);
        public Date SetMonth(int month) => new Date(Day, month, Year);
        public Date SetYear(int year) => new Date(Day, Month, year);
    }
}
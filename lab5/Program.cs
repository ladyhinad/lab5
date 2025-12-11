class Program
    {
        static void Main(string[] args)
    {
        ex1();
        ex2();
    }
        public static void ex1()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Для коректного виводу кирилиці
            
            VendingMachine machine = new VendingMachine();

            Console.WriteLine("=== ТЕСТ 1: Товар є, готівки вистачає (Рівно) ===");
            machine.InsertMoney(20);
            machine.SelectProduct("Cola");
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("\n=== ТЕСТ 2: Товар є, готівки замало ===");
            machine.InsertMoney(10);
            machine.SelectProduct("Cola"); // Не вистачає
            machine.InsertMoney(15);       // Докидаємо (разом 25)
            machine.SelectProduct("Cola"); // Тепер вистачає (з рештою)
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("\n=== ТЕСТ 3: Товару нема ===");
            machine.InsertMoney(25);
            machine.SelectProduct("Pepsi"); // Кількість = 0
            Console.WriteLine(new string('-', 30));
            
            Console.ReadKey();
        }
        public static void ex2()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Створення співробітників
        var operatorIvan = new Operator();
        var seniorMaria = new SeniorOperator();
        var bossPetro = new DepartmentHead();

        // 2. Побудова ланцюжка: Оператор -> Старший -> Начальник
        operatorIvan.SetNext(seniorMaria).SetNext(bossPetro);

        // 3. Формування вхідних дзвінків
        var calls = new List<Call>
        {
            new Call("Олег", "До котрої ви працюєте?", Difficulty.Basic),
            new Call("Ірина", "Хочу повернути товар, він бракований", Difficulty.Intermediate),
            new Call("Максим", "Я хочу укласти партнерську угоду на мільйон", Difficulty.Advanced),
            new Call("Анонім", "Чому у Всесвіті панує ентропія?", Difficulty.Critical) // Занадто складне
        };

        // 4. Обробка
        Console.WriteLine("=== РОБОТА CALL-ЦЕНТРУ ===\n");
        
        foreach (var call in calls)
        {
            Console.WriteLine($"-> Вхідний дзвінок від: {call.ClientName} (Рівень: {call.Difficulty})");
            // Клієнт завжди звертається до першого в ланцюгу (до звичайного оператора)
            operatorIvan.HandleCall(call);
            Console.WriteLine(new string('-', 50));
        }

        Console.ReadKey();
    }
    }
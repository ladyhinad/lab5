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

        Console.WriteLine("=== РОБОТА CALL-ЦЕНТРУ ===\n");

        // 1. Створюємо єдиний об'єкт кол-центру (він сам все налаштує всередині)
        CallCenter callCenter = new CallCenter();

        // 2. Просто кидаємо туди завдання
        callCenter.ProcessCall("Олег", "До котрої ви працюєте?", Difficulty.Basic);
        
        callCenter.ProcessCall("Ірина", "Хочу повернути товар, він бракований", Difficulty.Intermediate);
        
        callCenter.ProcessCall("Максим", "Я хочу укласти партнерську угоду на мільйон", Difficulty.Advanced);
        
        callCenter.ProcessCall("Анонім", "Чому у Всесвіті панує ентропія?", Difficulty.Critical);

        Console.ReadKey();
    }
    }
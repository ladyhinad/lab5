public class DispensingState : State
    {
        public DispensingState(VendingMachine machine) : base(machine) { }

        public override void InsertMoney(decimal amount)
        {
            Console.WriteLine("Зачекайте, йде видача товару.");
        }

        public override void SelectProduct(string productName)
        {
            Console.WriteLine("Зачекайте, йде видача товару.");
        }

        public override void Dispense()
        {
            var product = _machine.SelectedProduct;
            
            // Логіка транзакції
            _machine.Inventory[product.Name].Quantity--;
            decimal change = _machine.CurrentBalance - product.Price;

            Console.WriteLine($"--- ВИДАЧА: Тримайте ваш {product.Name}. ---");

            // Ситуація 3: Товар є – готівки забагато
            if (change > 0)
            {
                Console.WriteLine($"Ситуація: ГОТІВКИ ЗАБАГАТО. Ваша решта: {change} грн.");
            }
            else
            {
                Console.WriteLine("Ситуація: ГОТІВКИ ВИСТАЧАЄ. Без решти.");
            }

            // Скидання налаштувань (Reset)
            _machine.CurrentBalance = 0;
            _machine.SelectedProduct = null;
            _machine.SetState(_machine.WaitingState);
        }
    }
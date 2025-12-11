public class HasMoneyState : State
    {
        public HasMoneyState(VendingMachine machine) : base(machine) { }

        public override void InsertMoney(decimal amount)
        {
            _machine.CurrentBalance += amount;
            Console.WriteLine($"-> Додано: {amount} грн. Баланс: {_machine.CurrentBalance} грн.");
        }

        public override void SelectProduct(string productName)
        {
            if (!_machine.Inventory.ContainsKey(productName))
            {
                Console.WriteLine($"Помилка: Товар '{productName}' відсутній у списку.");
                return;
            }

            var product = _machine.Inventory[productName];
            Console.WriteLine($"-> Спроба купити: {product.Name} (Ціна: {product.Price} грн).");

            // Ситуація 4: Товару нема фізично
            if (product.Quantity <= 0)
            {
                Console.WriteLine($"Ситуація: ТОВАРУ НЕМА. {product.Name} закінчився.");
                return; // Залишаємось у стані HasMoney, можна обрати інше
            }

            // Ситуація 2: Товар є – готівки замало
            if (_machine.CurrentBalance < product.Price)
            {
                decimal diff = product.Price - _machine.CurrentBalance;
                Console.WriteLine($"Ситуація: ГОТІВКИ ЗАМАЛО. Додайте ще {diff} грн.");
                return;
            }

            // Ситуація 1 та 3: Все добре -> перехід до видачі
            _machine.SelectedProduct = product;
            _machine.SetState(_machine.DispensingState);
            
            // Автоматично запускаємо процес видачі
            _machine.Dispense(); 
        }

        public override void Dispense()
        {
            Console.WriteLine("Помилка: Спочатку оберіть товар.");
        }
    }
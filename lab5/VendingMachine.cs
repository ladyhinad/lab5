public class VendingMachine
    {
        // Дані автомата
        public Dictionary<string, Product> Inventory { get; set; }
        public decimal CurrentBalance { get; set; }
        public Product SelectedProduct { get; set; }

        // Доступні стани
        public State WaitingState { get; private set; }
        public State HasMoneyState { get; private set; }
        public State DispensingState { get; private set; }

        private State _currentState;

        public VendingMachine()
        {
            // Ініціалізація складу
            Inventory = new Dictionary<string, Product>
            {
                { "Cola", new Product("Cola", 20, 2) },
                { "Pepsi", new Product("Pepsi", 20, 0) } // Товару нема
            };

            // Ініціалізація станів
            WaitingState = new WaitingForMoneyState(this);
            HasMoneyState = new HasMoneyState(this);
            DispensingState = new DispensingState(this);

            // Початковий стан
            _currentState = WaitingState;
        }

        public void SetState(State newState)
        {
            _currentState = newState;
        }

        // Методи, що викликає клієнт (делегування стану)
        public void InsertMoney(decimal amount) => _currentState.InsertMoney(amount);
        public void SelectProduct(string name) => _currentState.SelectProduct(name);
        public void Dispense() => _currentState.Dispense();
    }
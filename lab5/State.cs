public abstract class State
    {
        protected VendingMachine _machine;

        protected State(VendingMachine machine)
        {
            _machine = machine;
        }

        public abstract void InsertMoney(decimal amount);
        public abstract void SelectProduct(string productName);
        public abstract void Dispense();
    }
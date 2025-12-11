public class WaitingForMoneyState : State
    {
        public WaitingForMoneyState(VendingMachine machine) : base(machine) { }

        public override void InsertMoney(decimal amount)
        {
            _machine.CurrentBalance += amount;
            Console.WriteLine($"-> Внесено: {amount} грн. Баланс: {_machine.CurrentBalance} грн.");
            _machine.SetState(_machine.HasMoneyState);
        }

        public override void SelectProduct(string productName)
        {
            Console.WriteLine("Помилка: Спочатку внесіть гроші.");
        }

        public override void Dispense()
        {
            Console.WriteLine("Помилка: Немає чого видавати.");
        }
    }
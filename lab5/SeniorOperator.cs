public class SeniorOperator : CallHandler
{
    public override void HandleCall(Call call)
    {
        if (call.Difficulty == Difficulty.Intermediate)
        {
            Console.WriteLine($"[Старший оператор] Взяв трубку від {call.ClientName}. Питання вирішено професійно.");
        }
        else
        {
            Console.WriteLine($"[Старший оператор] Питання занадто складне. З'єдную з начальником...");
            base.HandleCall(call);
        }
    }
}
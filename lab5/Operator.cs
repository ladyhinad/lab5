public class Operator : CallHandler
{
    public override void HandleCall(Call call)
    {
        if (call.Difficulty == Difficulty.Basic)
        {
            Console.WriteLine($"[Оператор] Відповів {call.ClientName}: \"{call.Question}\". Проблема вирішена.");
        }
        else
        {
            Console.WriteLine($"[Оператор] Не можу вирішити питання \"{call.Question}\". Перемикаю на старшого...");
            base.HandleCall(call); // Передаємо далі по ланцюгу
        }
    }
}
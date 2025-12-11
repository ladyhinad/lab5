public class DepartmentHead : CallHandler
{
    public override void HandleCall(Call call)
    {
        if (call.Difficulty == Difficulty.Advanced)
        {
            Console.WriteLine($"[Начальник] Слухаю, {call.ClientName}. Ваше складне питання вирішено особисто мною.");
        }
        else
        {
            Console.WriteLine($"[Начальник] Це поза моєю компетенцією. Пишіть офіційний лист.");
            base.HandleCall(call);
        }
    }
}
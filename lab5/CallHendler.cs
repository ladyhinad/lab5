public abstract class CallHandler
{
    protected CallHandler _nextHandler;

    // Метод для побудови ланцюжка (повертає обробник, щоб можна було писати .SetNext().SetNext())
    public CallHandler SetNext(CallHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    // Віртуальний метод. Якщо конкретний клас не може обробити, 
    // він викликає base.HandleCall, який передає далі.
    public virtual void HandleCall(Call call)
    {
        if (_nextHandler != null)
        {
            _nextHandler.HandleCall(call);
        }
        else
        {
            Console.WriteLine($"[X] Дзвінок від {call.ClientName} не оброблено. Ніхто не знає відповіді.");
        }
    }
}
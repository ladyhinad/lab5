public enum Difficulty
{
    Basic,          // Прості питання (графік роботи, статус замовлення)
    Intermediate,   // Скарги, повернення, технічні нюанси
    Advanced,       // VIP-клієнти, складні фінансові питання
    Critical        // Питання, які навіть начальник не вирішить (для тесту)
}

public class Call
{
    public string ClientName { get; }
    public string Question { get; }
    public Difficulty Difficulty { get; }

    public Call(string name, string question, Difficulty difficulty)
    {
        ClientName = name;
        Question = question;
        Difficulty = difficulty;
    }
}
// VIEW: Exibe informações na tela
public class MarioView
{
    public void MostrarStatus(Mario mario)
    {
        Console.WriteLine($"Mario tem {mario.Vidas} vidas e {mario.Moedas} moedas.");
    }

    public void MostrarGameOver()
    {
        Console.WriteLine("💀 GAME OVER! 💀");
    }
}

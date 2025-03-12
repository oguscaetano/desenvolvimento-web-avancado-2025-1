// MODEL: Representa o personagem Mario
public class Mario
{
    public int Vidas { get; set; } = 3;
    public int Moedas { get; set; } = 0;

    public void PegarMoeda()
    {
        Moedas++;
        if (Moedas % 100 == 0) 
        {
            Vidas++; // A cada 100 moedas, ganha uma vida extra
        }
    }

    public void LevarDano()
    {
        Vidas--;
    }
}

// CONTROLLER: Controla a lógica do jogo
public class MarioController
{
    private Mario mario;
    private MarioView view;

    public MarioController(Mario mario, MarioView view)
    {
        this.mario = mario;
        this.view = view;
    }

    public void MarioPegaMoeda()
    {
        mario.PegarMoeda();
        view.MostrarStatus(mario);
    }

    public void MarioLevaDano()
    {
        mario.LevarDano();
        view.MostrarStatus(mario);

        if (mario.Vida <= 0)
        {
            view.MostrarGameOver();
        }
    }
}

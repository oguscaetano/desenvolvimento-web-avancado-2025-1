class Program
{
    static void Main(string[] args)
    {
        // Criando o Mario (Model) e a View
        Mario mario = new Mario();
        MarioView view = new MarioView();

        // Criando o Controller que conecta Model e View
        MarioController controller = new MarioController(mario, view);

        // Simulando o jogo
        controller.MarioPegaMoeda();  // Mario pega uma moeda
        controller.MarioPegaMoeda();  // Mais uma moeda
        controller.MarioLevaDano();   // Mario leva dano
        controller.MarioLevaDano();   // Mario leva dano de novo
        controller.MarioLevaDano();   // Mario morre
    }
}

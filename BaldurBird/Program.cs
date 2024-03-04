using BaldurOpenGL;
// helper: https://jsayers.dev/c-sdl-tutorial-part-2-creating-a-window/
namespace BaldurBird
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}

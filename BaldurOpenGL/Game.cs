using SDL2;

namespace BaldurOpenGL
{
    public unsafe class Game
    {
        const int SCREEN_WIDTH = 640;
        const int SCREEN_HEIGHT = 480;

        public void Run()
        {
            IntPtr window = IntPtr.Zero;
            IntPtr renderer = IntPtr.Zero;

            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("SDL Error (SDL_Init): {0}", SDL.SDL_GetError());
            }

            window = SDL.SDL_CreateWindow("Test", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL);
            if (window == IntPtr.Zero)
            {
                Console.WriteLine("SDL Error (SDL_CreateWindow): {0}", SDL.SDL_GetError());
                return;
            }

            renderer = SDL.SDL_CreateRenderer(window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if (renderer == IntPtr.Zero)
            {
                Console.WriteLine("SDL Error (SDL_CreateRenederer): {0}", SDL.SDL_GetError());
            }

            SDL.SDL_UpdateWindowSurface(window);

            
            bool running = true;

            while (running)
            {
                while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
                {
                    if (e.type == SDL.SDL_EventType.SDL_QUIT)
                        running = false;
                }

                SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);

                SDL.SDL_RenderClear(renderer);

                SDL.SDL_RenderPresent(renderer);

            }

            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();

        }
    }


    public interface IRender
    {

    }
}

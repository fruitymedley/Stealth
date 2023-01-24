using System;

namespace Stealth
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Stealth())
                game.Run();
        }
    }
}

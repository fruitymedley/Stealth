using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Compiler
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Provide an output directory");
                Console.ReadKey();
                return;
            }

            string output = args[0];

            foreach (string folder in Directory.GetDirectories("Assets"))
            {
                using (FileStream file = File.OpenWrite($"{output}\\{folder}.cs"))
                {
                    string buffer =
                        "using System;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Text;\n" +
                        "using Stealth;\n" +
                        "\n" +
                        "namespace Stealth.Assets\n" +
                        "{\n" +
                        "   {\n" +
                        $"       class {Path.GetFileName(folder)}\n" +
                        "       {\n" +
                        "           public static Sprite[] Sprites;\n" +
                        "           public static void Init()\n" +
                        "           {\n" +
                        "               Sprites = new Sprite[]\n" +
                        "               {\n";

                    foreach (string asset in Directory.GetFiles(folder))
                    {
                        using (StreamReader reader = new StreamReader(File.Open(asset, FileMode.Open)))
                        {
                            /*
                            string texture = "{", mask = "{";

                            for (int y = 0; y < bitmap.Height; y++)
                            {
                                texture += " {";
                                mask += " {";
                                byte t = 0, m = 0;
                                for (int x = 0; x < bitmap.Width; x++)
                                {
                                    if ((x & 4) == 0)
                                        t = 0;
                                    if ((x & 8) == 0)
                                        m = 0;

                                    t = (byte)((t << 2) + bitmap.GetPixel(x, y).R / 64);
                                    m = (byte)((m << 1) + bitmap.GetPixel(x, y).A == 0 ? 0 : 1);

                                    if ((x & 4) == 3)
                                        texture += $" {t},";
                                    if ((x & 8) == 7)
                                        mask += $" {m},";
                                }
                                texture += " },";
                                mask += " },";
                            }

                            texture += " }";
                            mask += " }";

                            buffer += $"                 new Sprite(new byte[] {texture}, new byte[] {mask}),\n";
                            */
                        }
                    }

                    buffer +=
                        "               };\n" +
                        "           }\n" +
                        "       }\n" +
                        "   }\n" +
                        "}\n";

                    file.Write(Encoding.ASCII.GetBytes(buffer));
                }
            }
        }
    }
}

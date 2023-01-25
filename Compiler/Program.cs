using System;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

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
                using (FileStream file = File.Create($"{output}\\{folder}.cs"))
                {
                    string buffer =
                        "using System;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Text;\n" +
                        "using Stealth;\n" +
                        "\n" +
                        "namespace Stealth.Assets\n" +
                        "{\n" +
                        $"   class {Path.GetFileName(folder)}\n" +
                        "   {\n" +
                        "       public static Sprite[] Sprites;\n" +
                        "       public static void Init()\n" +
                        "       {\n" +
                        "           Sprites = new Sprite[]\n" +
                        "           {\n";

                    foreach (string asset in Directory.GetFiles(folder))
                    {
                        Image<Rgba32> image = Image.Load<Rgba32>(File.ReadAllBytes(asset));
                        
                        string texture = "{", mask = "{";

                        for (int y = 0; y < image.Height; y++)
                        {
                            texture += " {";
                            mask += " {";
                            byte t = 0, m = 0;
                            for (int x = 0; x < image.Width; x++)
                            {
                                if ((x & 3) == 0)
                                    t = 0;
                                if ((x & 7) == 0)
                                    m = 0;

                                t = (byte)((t << 2) + image[x, y].R / 64);
                                m = (byte)((m << 1) + (image[x, y].A == 0 ? 0 : 1));

                                if ((x & 3) == 3)
                                    texture += $" {t},";
                                if ((x & 7) == 7)
                                    mask += $" {m},";
                            }
                            texture += " },";
                            mask += " },";
                        }

                        texture += " }";
                        mask += " }";

                        buffer += $"                 new Sprite(new byte[,] {texture}, new byte[,] {mask}),\n";
                            
                    }

                    buffer +=
                        "           };\n" +
                        "       }\n" +
                        "   }\n" +
                        "}\n";

                    file.Write(Encoding.ASCII.GetBytes(buffer));
                }
            }
        }
    }
}

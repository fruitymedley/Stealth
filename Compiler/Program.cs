using System;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Linq;
using System.Numerics;

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

            foreach (string folder in Directory.GetDirectories(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "Assets")))
            {
                using (FileStream file = File.Create(Path.Combine(output, Path.Combine("Assets", $"{Path.GetFileName(folder)}.cs"))))
                {
                    string buffer =
                        "using System;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Text;\n" +
                        "using Microsoft.Xna.Framework;\n" +
                        "using Stealth;\n" +
                        "\n" +
                        "namespace Stealth.Assets\n" +
                        "{\n" +
                        $"   class {Path.GetFileName(folder)}\n" +
                        "   {\n" +
                        "       public static Dictionary<int, Sprite> Sprites;\n" +
                        "       public static void Init()\n" +
                        "       {\n" +
                        "           Sprites = new Dictionary<int, Sprite>();\n";

                    if (folder == "C:\\Users\\Joshua Todd\\source\\repos\\Stealth\\Compiler\\bin\\Debug\\net5.0\\Assets\\Wall"
                        || folder == "C:\\Users\\Joshua Todd\\source\\repos\\Stealth\\Compiler\\bin\\Debug\\net5.0\\Assets\\Ceiling"
                        || folder == "C:\\Users\\Joshua Todd\\source\\repos\\Stealth\\Compiler\\bin\\Debug\\net5.0\\Assets\\Floor"
                        || folder == "C:\\Users\\Joshua Todd\\source\\repos\\Stealth\\Compiler\\bin\\Debug\\net5.0\\Assets\\Item")
                    {
                        foreach (string asset in Directory.GetDirectories(folder).Where(a => int.TryParse(Path.GetFileNameWithoutExtension(a), out _)).OrderBy(a => int.Parse(Path.GetFileNameWithoutExtension(a))))
                        {
                            Image<Rgba32> flatImage = Image.Load<Rgba32>(File.ReadAllBytes(Path.Join(asset, "flat.png")));
                            Image<Rgba32> reflectImage = Image.Load<Rgba32>(File.ReadAllBytes(Path.Join(asset, "reflect.png")));
                            Image<Rgba32> normalImage = Image.Load<Rgba32>(File.ReadAllBytes(Path.Join(asset, "normal.png")));

                            string mask = "{", flat = "{", reflect = "{", normal = "{";

                            for (int y = 0; y < flatImage.Height; y++)
                            {
                                mask += " {";
                                flat += " {";
                                reflect += " {";
                                normal += " {";
                                for (int x = 0; x < flatImage.Width; x++)
                                {
                                    mask += $" {(flatImage[x, y].A == 0 ? 0 : 1)},";
                                    flat += $" {flatImage[x, y].R / 16},";
                                    reflect += $" {reflectImage[x, y].R / 16},";
                                    Vector3 n = new Vector3((normalImage[x, y].R - 128), (normalImage[x, y].G - 128), (normalImage[x, y].B - 128));
                                    n = n.Length() > 0 ? n / n.Length() : new Vector3();
                                    normal += $" new Vector3({n.X}f, {n.Y}f, {n.Z}f),";
                                }
                                mask += " },";
                                flat += " },";
                                reflect += " },";
                                normal += " },";
                            }

                            mask += " }";
                            flat += " }";
                            reflect += " }";
                            normal += " }";

                            buffer += "           " + $"Sprites[{int.Parse(Path.GetFileNameWithoutExtension(asset))}] = new Sprite(new sbyte[,] {mask}, new sbyte[,] {flat}, new sbyte[,] {reflect}, new Vector3[,] {normal});\n";

                        }
                    }
                    else
                    {
                        foreach (string asset in Directory.GetFiles(folder).Where(a => int.TryParse(Path.GetFileNameWithoutExtension(a), out _)).OrderBy(a => int.Parse(Path.GetFileNameWithoutExtension(a))))
                        {
                            Image<Rgba32> image = Image.Load<Rgba32>(File.ReadAllBytes(asset));

                            string texture = "{", mask = "{";

                            for (int y = 0; y < image.Height; y++)
                            {
                                mask += " {";
                                texture += " {";
                                for (int x = 0; x < image.Width; x++)
                                {
                                    mask += $" {(image[x, y].A == 0 ? 0 : 1)},";
                                    texture += $" {image[x, y].R / 16},";
                                }
                                mask += " },";
                                texture += " },";
                            }

                            texture += " }";
                            mask += " }";

                            buffer += "           " + $"Sprites[{int.Parse(Path.GetFileNameWithoutExtension(asset))}] = new Sprite(new sbyte[,] {mask}, new sbyte[,] {texture});\n";

                        }
                    }

                    buffer +=
                        "       }\n" +
                        "   }\n" +
                        "}\n";

                    file.Write(Encoding.ASCII.GetBytes(buffer));
                }
            }
        }
    }
}

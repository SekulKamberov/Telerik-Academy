namespace _01.CreateStructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            using (StreamWriter writer = new StreamWriter(@"../../savedPaths.txt"))
            {
                foreach (var point in path.Points)
                {
                    writer.WriteLine(point.ToString());
                }
            }
        }

        public static Path LoadPath()
        {
            Path path = new Path();

            try
            {
                using (StreamReader reader = new StreamReader(@"../../savedPaths.txt"))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        string[] pointValues = line.Split(new char[] { '(', ',', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        path.AddPoint(new Point3D(int.Parse(pointValues[0]), int.Parse(pointValues[1]), int.Parse(pointValues[2])));
                    }
                }

                return path;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found, try adding a new file");
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
            catch (OutOfMemoryException ome)
            {
                Console.WriteLine(ome.Message);
            }

            return null;
        }
    }
}

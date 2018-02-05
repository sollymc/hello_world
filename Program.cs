using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoVirusApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cell = new Cell();
            var cells = cell.GetCells();
            var value = 0;
            var distance = 0.0;
            var cycle = 0;
            var isInfected = false;
            var message = string.Empty;
            var bloodCell = new Cell();

            Console.WriteLine("Nano Virus Application in progress, please wait...");
            Console.WriteLine("Writing to a file in \"My Documents\" Folder...");

            foreach (var _cell in cells)
            {
                while (cycle < 5)
                {
                    var randomNumber = new Random();
                    var cellIndex = 0;

                    if (cells.Where(c => c.Type == CellType.RedBloodCell).Count() > 0)
                    {
                        cellIndex = randomNumber.Next(30, 100);
                    }
                    else if (cells.Where(c => c.Type == CellType.WhiteBloodCell).Count() > 0)
                    {
                        cellIndex = randomNumber.Next(5, 30);
                    }
                    else
                    {
                        break;
                    }

                    bloodCell = cells.ElementAt(cellIndex);

                    if (!isInfected)
                    {
                        foreach (var tomorous in cells.Where(c => c.Type == CellType.TumorousCell))
                        {
                            value = ((bloodCell.X - tomorous.X) * (bloodCell.X - tomorous.X)) +
                                ((bloodCell.Y - tomorous.Y) * (bloodCell.Y - tomorous.Y)) +
                                ((bloodCell.Z - tomorous.Z) * (bloodCell.Z - tomorous.Z));

                            distance = Math.Sqrt(value);

                            if (distance <= 5000)
                            {
                                if (bloodCell.Type == CellType.TumorousCell)
                                {
                                    //cells.Remove(bloodCell);
                                }
                                else 
                                {
                                    bloodCell.Type = CellType.TumorousCell;
                                }

                                isInfected = true;
                            }
                        }
                    }

                    message = "Tumorous cells = " + cells.Where(c => c.Type == CellType.TumorousCell).Count() + "\n Red Blood Cells = " + cells.Where(c => c.Type == CellType.RedBloodCell).Count() + "\n White Blood Cells = " + cells.Where(c => c.Type == CellType.WhiteBloodCell).Count();

                    //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-to-a-text-file
                    var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    using (StreamWriter outputFile = new StreamWriter(path + @"\NanoVirusStatus.txt", true))
                    {
                        outputFile.WriteLine(message);
                    }

                    //End write to a text file

                    ++cycle;

                    if (cycle == 5)
                    {
                        cycle = 0;
                        message = "";
                        isInfected = false;
                    }
                }

                bloodCell = cells.First();

            }

            Console.WriteLine("...End of Nano Virus Application...");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DBProc.FileWork
{
    /// <summary>
    /// Class for create text-file
    /// </summary>
    public class CreateTextFile
    {
        /// <summary>
        /// Method for create text-file
        /// </summary>
        /// <param name="path">Path of file</param>
        /// <param name="mas">Array of string</param>
        /// <param name="kol">Number of params for filling</param>
        public void CreateFile_txt(string path, string[] mas, int kol) 
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    if (kol == 2) 
                    {
                        for(int i = 2; i < mas.Length; i+=2)
                        {
                            sw.WriteLine(mas[0] + mas[i] + ". " + mas[1] + mas[i + 1] + ".");

                        }
                    }
                    else if (kol == 3) 
                    {
                        for (int i = 2; i < mas.Length; i += 3)
                        {
                            sw.WriteLine(mas[0] + mas[i] + ". " + mas[1] + mas[i + 1] + ". " + mas[2] + mas[i + 2] + ".");

                        }
                    }
                    else
                    {
                        foreach (var v in mas)
                            sw.WriteLine(v);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

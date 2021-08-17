using System;
using System.Collections;
using System.IO;

namespace Application.PGN
{
    public class PGN
    {
        private string White = "Tim";
        private string Black = "Jeroen";
        private string Event = "?";
        private string Site = "?";
        private string Date = "????.??.??";
        private string Round = "?";
        private string Result = "1-0";

        private ArrayList pgn;


        public void setupPgn()
        {
            pgn = new ArrayList();

            pgn.Add("1. e3 d6");
            pgn.Add("2. Bc4 Bd7");
            pgn.Add("3. Qf3 a6");
            pgn.Add("4. Qxf7# 1-0");
        }

        public void createPgnFile()
        {
            string fileName = @"/home/tim/projects/Chess/Application/PGN/test.pgn";

            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("[Event \""+ Event + "\"]");
                    sw.WriteLine("[Site \""+ Site + "\"]");
                    sw.WriteLine("[Date \""+ Date + "\"]");
                    sw.WriteLine("[Round \""+ Round + "\"]");
                    sw.WriteLine("[White \""+ White + "\"]");
                    sw.WriteLine("[Black \""+ Black + "\"]");
                    sw.WriteLine("[Result \""+ Result + "\"]");
                    sw.WriteLine("");
                    
                    foreach (var item in pgn)
                    {
                        sw.Write(item + " ");
                    }
                }
            

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());    
            }



        }

    }
}
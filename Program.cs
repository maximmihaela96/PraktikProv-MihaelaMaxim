using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Variabeln som kommer att lagra nodens innehållet 
        string nodeContent = "";
        //Skapa ett nytt XmlDocument från en fil specificerad av en URI
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(@"C:\Users\maxim\source\repos - Web\PraktikProv-MihaelaMaxim\PraktikProv-MihaelaMaxim\readOutFile.xml");
        //Ta elementerna från nodet "trans-unit" by GetElementsByTagName
        XmlNodeList nodes = xdoc.GetElementsByTagName("trans-unit");

        //Foreach som loopa alla elementerna från noden trans-unit
        foreach (XmlNode node in nodes)
        {
            //Kondition att id ska vara lika med värdet "42007"
            if (node.Attributes["id"].Value == "42007")
            {
                nodeContent = node["target"].InnerText;
                
                if (nodeContent == null)
                {
                    Console.WriteLine("Doesn't exist");
                }
                else
                {
                    //Displaya nodens innehåll i konsolen
                    Console.WriteLine($"Noden innehåller följande text: |------ {nodeContent} ------| ");
                }
            }
        }

        //Definiera en sträng med filsökvägen
        string filNamn = @"C:\Users\maxim\source\repos - Web\PraktikProv-MihaelaMaxim\PraktikProv-MihaelaMaxim\writeInFile.txt";

        try
        {
            // Kontrollera om filen redan finns. Om ja, ta bort den.  
            if (File.Exists(filNamn))
            {
                File.Delete(filNamn);
            }
            //Skapa ny textfill
            //File.CreateText()-metoden tar ett filnamn med den fullständiga sökvägen och skapar en fil på den angivna platsen "filNamn"
            using (StreamWriter sWriter = File.CreateText(filNamn))
            {
                sWriter.WriteLine($"Ny fil skapades:  {DateTime.Now.ToString()}");
                //Skriva in i filen med hjälp av StreamWriter 
                sWriter.WriteLine($"Noden innehåller följande text: |----- {nodeContent} ------| ");
            }
            Console.WriteLine("Targets värde skrevdes i filen nämnd |-----writeInFile------|");
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.ToString());
        }
    }
}
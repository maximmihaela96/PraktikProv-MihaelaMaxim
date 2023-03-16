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
                    Console.WriteLine($"Noden innehåller följande text: {nodeContent} |text ");
                }
            }
        }
        Console.WriteLine("Targets värde skrevdes i filen nämnd |writeFile|");
        //Skriva in nodens innehållet i ett befintligt textdokument 
        File.WriteAllText(@"C:\Users\maxim\source\repos - Web\PraktikProv-MihaelaMaxim\PraktikProv-MihaelaMaxim\writeInFile.txt", nodeContent);
    }
}

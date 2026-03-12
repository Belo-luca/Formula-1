using F1_2026;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace F1
{
    internal static class Program
    {
        public static StagioneF1 stagione = new StagioneF1();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string jsonFilePath = "lista_piloti.JSON";
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonConvert.DeserializeObject<StagioneF1>(jsonData);
                stagione.Piloti = data.Piloti;
                stagione.Vetture = data.Vetture;
                stagione.Staff = data.Staff;
            }
            Application.Run(new Form1());
        }
    }
}

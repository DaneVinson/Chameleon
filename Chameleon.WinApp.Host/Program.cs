using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chameleon.WinApp.Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:6886/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine($"Host running and listening at {baseAddress}");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Console.ReadKey();
            }
        }


        internal static bool StartForm(string typeName)
        {
            var nameParts = typeName.Split('.');
            var assemblyQualifiedName = $"{typeName}, {String.Join(".", nameParts.Take(nameParts.Length - 1).ToArray())}";
            var type = Type.GetType(assemblyQualifiedName);
            if (type == null) { return false; }
            Form form = Activator.CreateInstance(type) as Form;
            if (form == null) { return false; }
            var task = Task.Run(() => { form.ShowDialog(); });
            task.Wait(1);
            return true;
        }
    }
}

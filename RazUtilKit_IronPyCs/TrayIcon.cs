using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INI;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace RazUtilKit_IronPyCs
{
    class TrayIcon : IDisposable
    {
        NotifyIcon ni;
        IniFile MyConfig = new IniFile("Settings.ini");
        ScriptEngine engine;
        ScriptScope scope;
        string code;

        //Constructior
        public TrayIcon()
        {
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
            scope.SetVariable("DevID", "");
            scope.SetVariable("Status", "");
            ni = new NotifyIcon();
            code = System.IO.File.ReadAllText("PyEngine.py");

        }

        //Display the icon in the tray
        public void Display()
        {
            ni.Icon = Properties.Resources.Beta;
            ni.Text = "Raz's UtilKit (IronPy + C#)";
            ni.Visible = true;

            //Handle MouseClicks
            ni.MouseClick += new MouseEventHandler(ni_1LC);
        }

        void ni_1LC(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Actions(int.Parse(IRead("1LC", "Icon")));
                
            }
        }

        void Actions(int count)
        {

            MessageBox.Show("The icon has been clicked!");
            engine.Execute(code);
            string result1 = scope.GetVariable<string>("DevID");
            DisableHardware.DisableDevice(n => n.ToUpperInvariant().Contains(result1), 
                true); 
            // true disables the device, false enables it
        }
        //Read a key from the INI file.
        string IRead(string name, string section = null)
        {
            try
            {
                return MyConfig.Read(name, section);
            }
            catch
            {
                //MessageBox.Show();
                Application.Exit();
                return null;
            }
        }
        //Dispose of the icon when the program closes
        public void Dispose()
        {
            ni.Dispose();
        }
    }
}

/**
    @INI Encoding@
   
    Icon
    ----
    0 -> Open Bluetooth
    1 -> Close Bluetooth
    2 -> Open Context Menu
    3 -> Open Sync Menu

    Bluetooth
    ----
    DevName -> Device Name set 
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INI;
using IronPython.Hosting;
namespace RazUtilKit_IronPyCs
{
    class TrayIcon : IDisposable
    {
        NotifyIcon ni;
        IniFile MyConfig = new IniFile("Settings.ini");

        //Constructior
        public TrayIcon()
        {
            ni = new NotifyIcon();
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
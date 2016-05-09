using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INI;

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
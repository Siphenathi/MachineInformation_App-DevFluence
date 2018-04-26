using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MachineInformationApp
{
    public class MachineInformation
    {
        public string GetOsVersion()
        {
            return Environment.OSVersion.ToString();
        }

        public string GetHostName()
        {
            return Dns.GetHostName();
        }

        public string GetQualifiedHostName()
        {
            var hostname = GetHostName();
            var hostEntry = Dns.GetHostEntry(hostname);
            return hostEntry.HostName;
        }


        public string GetIpAddress()
        {
            var ipAddress = string.Empty;
            var localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var addr in localIPs)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = addr.ToString();
                }
            }
            return ipAddress;
        }

        public string ExecutePowershell(string path)
        {
            //var path = "C:\\Users\\DevFluence\\Desktop\\updated version\\MachineInformationApp\\MachineInformationConsole\\Powershell script\\script.ps1";
            //System.IO.FileInfo scriptFile = new System.IO.FileInfo(scriptText);
            string results = string.Empty;
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(File.ReadAllText(path));

                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                if (PowerShellInstance.Streams.Error.Count > 0)
                {

                    Console.WriteLine("Error");
                    return "Error";
                }
                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        results = outputItem.ToString();

                    }

                }
            }

            return results;

        }
    }
}

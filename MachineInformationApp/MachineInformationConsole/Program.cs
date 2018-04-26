using MachineInformationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace MachineInformationConsole
{
    class Program
    {
        public static int Main(string[] args)
        {
            var machineLogic = new MachineInformation();
            
            return Parser.Default.ParseArguments<HostNameOption, IpOption,OsOption,ScriptOption>(args)
                .MapResult(
                    (HostNameOption opts) => RunHostname(opts,machineLogic),
                    (IpOption opts) => RunIpOption( machineLogic),
                    (OsOption opts) => RunOsOption( machineLogic),
                    (ScriptOption opts) => RunScriptOption(opts, machineLogic),
                    errs => 1);
        }

        private static int RunOsOption( MachineInformation machineLogic)
        {
            Console.WriteLine(machineLogic.GetOsVersion());
            return Environment.ExitCode;
            
        }

        private static int RunIpOption( MachineInformation machineLogic)
        {
            Console.WriteLine(machineLogic.GetIpAddress());
            return Environment.ExitCode;
        }

        private static int RunScriptOption(ScriptOption opts, MachineInformation machineLogic)
        {
            string path = "C:\\Users\\DevFluence\\Desktop\\updated version\\MachineInformationApp\\MachineInformationConsole\\Powershell script\\script.ps1";

            var scriptOutput = string.Empty;
              scriptOutput = machineLogic.ExecutePowershell(path);
            
            Console.WriteLine(scriptOutput);
            return Environment.ExitCode;
        }

        private static int RunHostname(HostNameOption opts, MachineInformation machineLogic)
        {
            var hostname=string.Empty;
            if (opts.FullyQualified)
            {
                hostname = machineLogic.GetQualifiedHostName();
            }
            else
            {
                hostname = machineLogic.GetHostName();
            }
            Console.WriteLine(hostname);

            return Environment.ExitCode;
        }
    }
}

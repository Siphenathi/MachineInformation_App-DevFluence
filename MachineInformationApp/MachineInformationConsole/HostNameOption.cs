using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace MachineInformationConsole
{
    [Verb("hostname", HelpText = "Outputs hostname")]
    public class HostNameOption
    {
        [Option('f', "FullyQualified", HelpText = "Outputs fully Qualified Hostname ")]
        public bool FullyQualified { get; set; }
    }
}

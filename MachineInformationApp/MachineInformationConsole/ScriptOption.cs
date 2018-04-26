using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using CommandLine;

namespace MachineInformationConsole
{
    [Verb("script", HelpText = "executes script file")]
    public class ScriptOption
    {
        [Option('f', "file", HelpText = "Outputs the contents of script file")]
        public bool runScriptFile { get; set; }
    }
 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineInformationApp;
using NUnit.Framework;
using System.IO;
using MachineInformationConsole;

namespace MachineinformationApp.Tests
{
    [TestFixture]
    class MachineInformationAppTests
    {
        [Test]
        public void GetHostName_GivenStringHostName_ShouldReturnHostname()
        {
            //Arrange
            var expected = "DevFluence6-DBN";
            var sut = CreateMachineInformation();
            //Act
            var result = sut.GetHostName();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetIpAddress_GivenStringIPAddress_ShouldReturnIpAddress()
        {
            //Arrange
            var expected = "192.168.2.178";
            var sut = CreateMachineInformation();
            //Act
            var result = sut.GetIpAddress();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetOsVersion_GivenStringOS_ShouldReturnOperatingSystem()
        {
            //Arrange
            var expected = "Microsoft Windows NT 10.0.16299.0";
            var sut = CreateMachineInformation();
            //Act
            var result = sut.GetOsVersion();
            //Assert
            Assert.AreEqual(expected, result);
        }

        //[Test]
        //public void GetMachineInfo_GivenStringHelp_ShouldReturnAvailableHelpOptions()
        //{
        //    //Arrange
        //    var input = "help";
           
        //    var expected= "For more information on a specific command, type HELP command-name" +
        //                  "hostname: returns hostname" +
        //                  "ipconfig: returns ip address" +
        //                  "os:        returns operating system version";
            
        //    var sut = CreateMachineInformation();
        //    //Act
        //    var result = sut.GetMachineInfo(input);
        //    //Assert
        //    Assert.AreEqual(expected, result);
        //}


        [Test]
        public void GetMachineInfo_GivenHostNameFullyQualified_ShouldReturnTheFullQualifiedComputerName()
        {
            //Arrange
            string expected = "DevFluence6-DBN";
            var sut = CreateMachineInformation();
            //Act
            var result = sut.GetQualifiedHostName();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExecutePowershell_GivenScriptPath_ShouldReturnHelloWorld()
        {
            //Arrange
            string expected = "hello world";
            var sut = CreateMachineInformation();
            //Act
            string path= "C:\\Users\\DevFluence\\Desktop\\updated version\\MachineInformationApp\\MachineInformationConsole\\Powershell script\\script.ps1";
            var result = sut.ExecutePowershell(path);
            //Assert
            Assert.AreEqual(expected, result);
        }


        private static MachineInformation CreateMachineInformation()
        {
            return new MachineInformation();
        }
    }
}

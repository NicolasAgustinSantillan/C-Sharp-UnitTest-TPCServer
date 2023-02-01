using UnitTest_TcpServer.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tenaris.Manager.Marking.Plugin.TCPStencilDriver;
using Tenaris.Manager.Marking.Shared.Enums;

namespace UnitTest_TcpServer
{
    [TestClass]
    public class Plugin_EBS_260
    {
        private Dictionary<string, object> dataPrint = new Dictionary<string, object>() 
        {
            { "Linea1", $"TENARIS VA 210 <API> SPEC 5L 09/22" },
            { "Linea2", "30 0,413 P2XM PSL2 SAWL" },
            { "Linea3", $"NRO:1001 LARGO:11,65 M  TESTED:1930" },
            { "Linea4", $"PF/IT:512-1  IND.ARGENTINA" }
        };

        [TestMethod]
        public void Test_3121_StartPrint()
        {
            TcpConnectionHandjetPrinterEBS260 tcpControlPrinterConnection = new TcpConnectionHandjetPrinterEBS260(Settings.Default.ip, Settings.Default.PortDefault, Settings.Default.WaitingTime, Settings.Default.EndCharacter);

            MarkingStatus startPrintStatus = tcpControlPrinterConnection.SetStartPrint();

            Assert.AreEqual(MarkingStatus.Sent, startPrintStatus);
        }

        [TestMethod]
        public void Test_5000_StartPrint()
        {
            TcpConnectionHandjetPrinterEBS260 tcpDataPrintConnection = new TcpConnectionHandjetPrinterEBS260(Settings.Default.ip, Settings.Default.PortPrint, Settings.Default.WaitingTime, Settings.Default.EndCharacter);
            
            MarkingStatus startPrintStatus = tcpDataPrintConnection.SendPrintData(dataPrint);

            Assert.AreEqual(MarkingStatus.Sent, startPrintStatus);
        }

        [TestMethod]
        public void Test_3121_GetStatus()
        {
            TcpConnectionHandjetPrinterEBS260 tcpDataPrintConnection = new TcpConnectionHandjetPrinterEBS260(Settings.Default.ip, Settings.Default.PortDefault, Settings.Default.WaitingTime, Settings.Default.EndCharacter);

            // GetStatus no retorna nada, es dificil de evaluar de esta manera 

            tcpDataPrintConnection.GetStatus();
        }
        
    }
}

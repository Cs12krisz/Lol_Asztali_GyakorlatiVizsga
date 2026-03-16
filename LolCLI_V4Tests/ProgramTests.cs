using Microsoft.VisualStudio.TestTools.UnitTesting;
using LolCLI_V4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolCLI_V4.Models;

namespace LolCLI_V4.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [DataRow(10, 64.8)]
        [DataRow(1, 45)]
        [DataRow(5, 53.8)]
        [DataRow(18, 82.4)]
        [TestMethod()]
        public void ADLevelTest(int szint, double elvartSebzes)
        {
            Hos hos = new Hos("Parzival;a mágányos Hős;Fighter; Fighter; 500;45;2,2");
            Assert.AreEqual(elvartSebzes, hos.ADLevel(szint));
        }
    }
}
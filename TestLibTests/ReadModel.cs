using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities.ReadModel;

namespace TestLibTests
{
    [TestClass]
    public class ReadModel
    {
        [TestMethod]
        public void RunGetById()
        {
            CarReadModelRepository.GetById(4);
        }

        [TestMethod]
        public void RunGetById2()
        {
            CarReadModelRepository.GetById2(4);
        }

        [TestMethod]
        public void RunGetById3()
        {
            CarReadModelRepository.GetById3(4);
        }
    }
}

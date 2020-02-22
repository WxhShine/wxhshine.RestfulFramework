using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPCoreRestfulApiDemo.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPCoreRestfulApiDemo.Utils.Tests
{
    [TestClass()]
    public class ConfigHelperTests
    {
        [TestMethod()]
        public void GetConfigTest()
        {
            Assert.AreEqual(ConfigHelper.GetConfig("KafkaMapping:BootstrapServers"), "192.168.31.50:9092");
        }
    }
}
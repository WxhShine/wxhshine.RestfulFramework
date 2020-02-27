using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPCoreRestfulApiDemo.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Configuration;

namespace ASPCoreRestfulApiDemo.Utils.Tests
{
    [TestClass()]
    public class ConfigHelperTests
    {
        [TestMethod()]
        public void GetConfigTest()
        {
            try
            {
                Program.Main(new string[] { });
                var config = ConfigEntity.Instance.kafkaMapping.BootstrapServers;
                //Assert.AreEqual(ConfigHelper.GetConfig("KafkaMapping:BootstrapServers"), "192.168.31.50:");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
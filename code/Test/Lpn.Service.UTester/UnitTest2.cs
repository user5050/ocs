using System;
using System.IO;
using OneCoin.Service.Model.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QiNiuTool.Core;

namespace OneCoin.Service.UTester
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] buffer = null;
            using (var io =(File.OpenRead("c:\\test.jpg")))
            {
                buffer=new byte[io.Length];
                io.Read(buffer, 0, (int)io.Length);
            }

            var msg = "";
            QiNiuApi.Put(WebConfig.ResourceBucket, DateTime.Now.ToString(), buffer, out msg);

        }
    }
}

﻿using System;
using FreeSrun;
using FreeSrun.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace FreeSrun.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TimeSpan ts1 = DateTime.Now - new DateTime(1970, 1, 1);
            Console.WriteLine("Total Seconds: " + ts1.TotalSeconds);

            TimeSpan ts2 = DateTime.UtcNow - new DateTime(1970, 1, 1);
            Console.WriteLine("Total Seconds(UTC): " + ts2.TotalSeconds);
        }

        [TestMethod]
        public void BuildHeartBeatPacket_Test()
        {
            byte[] result = CommonService.BuildHeartBeatPacket("10153302696068");
            Console.WriteLine(BitConverter.ToString(result));
        }

        [TestMethod]
        public void PasswordEncrpt_Test()
        {
            PasswordEncryptor pe = new PasswordEncryptor();
            long time = Convert.ToInt64((new DateTime(2014, 8, 20) - new DateTime(1970, 1, 1)).TotalSeconds);
            string en_pwd = pe.Encrypt("cjr0912", time);
            Console.WriteLine(en_pwd);
        }

        [TestMethod]
        public void Get3AIP()
        {
            //string result = WebRequestHelper.CreateRequest("http://freesrun.codeplex.com", "GET", "");
            bool result = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
   
            Console.Write(result);
        }

        [TestMethod]
        public void PickupAdd()
        {
            string result ="<html><head><meta http-equiv=\"expires\" content=\"0\"><meta http-equiv=\"cache-control\" content=\"no-cache\"><meta http-equiv=\"pragma\" content=\"no-cache\"><script language=javascript>location='http://202.204.67.15/muxjp.php?url='+document.location;</script></head></html>\r\n\r\n";
          
            Regex reg1 = new System.Text.RegularExpressions.Regex(@"<body>([\s\S]*)</body>");
            Match m1 = reg1.Match(result);
            
            if (m1.Success)
            {
                Console.Write("Success: "+m1.Groups[0].Value);
            }
            else
            {
                Console.Write("Failed!");
            }
        }

    }
}
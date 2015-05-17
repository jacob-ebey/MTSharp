using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MTSharp.Tests
{
    [TestClass]
    public class MTSharpTests
    {
        [TestMethod]
        public void VerifyMTConnectCanRetrieveDeviceStreamsAndData()
        {
            MTConnect connect = new MTConnect("http://agent.mtconnect.org");
            IEnumerable<Result> results = connect.Current()["VMC-3Axis"];

            if (results == null) Assert.Fail();

            Sample result = results.FirstOrDefault(r =>
            {
                Sample sample = r as Sample;
                return sample?.DataItem?.Name == "Sspeed";
            }) as Sample;

            if (result == null) Assert.Fail();
        }
    }
}

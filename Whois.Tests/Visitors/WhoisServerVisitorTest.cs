﻿using NUnit.Framework;
using Whois.Servers;

namespace Whois.Visitors
{
    [TestFixture]
    public class WhoisServerVisitorTest
    {
        private WhoisServerVisitor visitor;

        [SetUp]
        public void SetUp()
        {
            visitor = new WhoisServerVisitor { WhoisServerLookup = new FakeWhoisServerLookup() };
        }

        [Test]
        public void TestWhoisServerNameIsAssigned()
        {
            var record = new WhoisRecord { Domain = "example.com" };

            Assert.IsNull(record.Server);

            record = visitor.Visit(record);

            Assert.AreEqual("test.whois.com", record.Server.Url);
        }
    }
}

﻿using System.Collections.Generic;
using FlightsNorway.Lib.DataServices;
using FlightsNorway.Lib.Model;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightsNorway.Tests.FlightDataServiceTest
{
    [TestClass]
    public class StatusesServiceTest : SilverlightTest
    {
        [TestMethod, Asynchronous, Timeout(5000), Tag(Tags.WebService)]
        public void Should_be_able_to_get_airport_names()
        {
            var statusList = new List<Status>();
            EnqueueCallback(() => _service.GetStautses(r => statusList.AddRange(r.Value)));
            EnqueueConditional(() => statusList.Count > 0);
            EnqueueTestComplete();
        }

        [TestInitialize]
        public void Setup()
        {
            _service = new StatusService();
        }

        private StatusService _service;
    }
}
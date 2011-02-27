﻿using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using FlightsNorway.Model;

namespace FlightsNorway.FlightDataServices
{
    public class StatusService
    {
        private readonly RestHelper _rest;

        public StatusService()
        {
            _rest = new RestHelper();
        }

        public void GetStautses(Action<Result<IEnumerable<Status>>> callback)
        {
            _rest.Get("flightStatuses.asp", callback, ParseStatusXml);
        }

        private static IEnumerable<Status> ParseStatusXml(XmlReader reader)
        {
            var xml = XDocument.Load(reader);

            return from flightStatuses in xml.Elements("flightStatuses")
                   from status in flightStatuses.Elements("flightStatus")
                   select new Status
                              {
                                  Code = status.Attribute("code").Value,
                                  StatusTextEnglish = status.Attribute("statusTextEn").Value,
                                  StatusTextNorwegian = status.Attribute("statusTextNo").Value
                              };
        }
    }
}
﻿using System.Xml.Linq;

namespace MTSharp
{
    public class Alarm : Event
    {
        public Alarm(XElement element, Device device)
            : base(element, device)
        {
            Code = element.Attribute("code").Value;
            NativeCode = element.Attribute("nativeCode").Value;
            Severity = element.Attribute("severity").Value;
            State = element.Attribute("state").Value;
        }

        public string Code { get; private set; }

        public string NativeCode { get; private set; }

        public string Severity { get; private set; }

        public string State { get; private set; }
    }
}

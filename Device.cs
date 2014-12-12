using System.Collections.Generic;
using System.Xml.Linq;

namespace MTSharp
{
    public class Device : Component
    {
        Dictionary<string, Component> allComponents;
        Dictionary<string, DataItem> allDataItems;

        public Device(string uri, XElement element,
                      Dictionary<string, Component> components,
                      Dictionary<string, DataItem> dataItems)
            : base(null, element, components, dataItems)
        {
            Uri = uri;
            allComponents = components;
            allDataItems = dataItems;
        }

        public string Uri { get; private set; }

        public DataItem GetDataItem(string id) { return allDataItems[id]; }

        public Component GetComponent(string id) { return allComponents[id]; }
    }
}

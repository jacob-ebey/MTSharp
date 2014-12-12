MTSharp
=======

.Net library for comsuming MTConnect streams written in pure C#.

This library utilizes Linq and Xml.Linq to simplify and speed up the parsing of streams.
Dictionary<string, Device> Probe()


MTConnect.Probe()
-----------------

MTConnect.Probe() gets all the devices but not the current result set. This is great if you need 
to get the Devices in a stream but do not need the data at the time. MTConnect.Probe will make a 
request every time it is called, so if you want the devices from the last time, use MTConnect.Devices().
If MTConnect.Probe has has not been called, MTConnect.Devices will make the call for you.


MTConnect.Current()
-------------------

MTConnect.Current() is used to get all Devices in a stream along with an enumerable dataset of Result's.

Examples
-------

### Get all devices in a stream

Notice below how the example url does not contain a "/current" at the end, DO NOT add the "/current".

```C#
MTConnect connect = new MTConnect("http://url-to-stream");
IEnumerable<Device> devices = connect.Probe().Select(entry => entry.Value);
```


### Get all results for a device named "TestDevice" within the stream

MTConnect.Current returns Dictionary<string, IEnumerable<Result>>, so instead of using the indexer
you can use a Where Linq statement to make sure that if it does not exist you do not get an exception.

```C#
MTConnect connect = new MTConnect("http://url-to-stream");
IEnumerable<Result> results = connect.Current().Where(r => r.Key == "TestDevice");
```

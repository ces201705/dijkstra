using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Oceanic.DAL
{
    public class ExternalServiceHelper
    {
        public static List<TelstarSegment> GetTelstarSegments()
        {
            string url = @"http://wa-oapln.azurewebsites.net/Service/Segments?parcelWeight=4&parcelMaxDimensionSize=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string content = reader.ReadToEnd();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    List<TelstarSegment> segments = ser.Deserialize<List<TelstarSegment>>(content);
                    return segments;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();


                    // log errorText
                }
                throw;
            }
        }


        public static List<EastIndiaSegment> GetEastIndiaSegments()
        {
            string url = @"http://wa-tlpln.azurewebsites.net/api/segments";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("telstartoken", "1234");
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string content = reader.ReadToEnd();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    List<EastIndiaSegment> segments = ser.Deserialize<List<EastIndiaSegment>>(content);
                    return segments;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();


                    // log errorText
                }
                throw;
            }
        }


    }


    public class TelstarSegment
    {
        public string SourceLocationName { get; set; }
        public string EndLocationName { get; set; }
        public decimal Time { get; set; }
        public decimal Price { get; set; }
    }



    public class EastIndiaSegment
    {
        public string SourceLocationName { get; set; }
        public string DestinationLocationName { get; set; }
        public decimal Time { get; set; }
        public decimal Price { get; set; }
    }
}

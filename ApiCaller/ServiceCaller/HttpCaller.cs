using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace ApiCaller.ServiceCaller
{
    public static class HttpCaller
    {
        private static string _baseAddress { get; set; }
        private static IConfiguration _configuration;

        private static readonly IConfigurationRoot Configuration;
        private static readonly HttpClient _httpClient;
        static HttpCaller()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(1)
            };

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetBaseAddress()
        {
            var baseAddress = _configuration["ApplicationSettings:BaseAddress"];
            if (string.IsNullOrEmpty(baseAddress))
            {
                baseAddress = "http://localhost:5000"; // Default fallback
            }
            return baseAddress+"/";
        }

        #region Generic Methods For Get & Post Calls

        public static T Get<T>(string endPoint)
        {
            return GetCall<T>(endPoint);
        }

        public static T Post<T>(string endPoint,
            object data)
        {
            return PostCall<T>(endPoint, data);
        }

        private static T GetCall<T>(string endPoint)
        {
            if (!string.IsNullOrEmpty(endPoint))
            {
                HttpWebRequest request = GetWebRequestObject(endPoint);
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (Stream stream = response.GetResponseStream())
                            {
                                var result = JsonConvert.DeserializeObject<T>(new StreamReader(stream).ReadToEnd());
                                return result;
                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    string c = string.Empty;
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Stream stremm = ((HttpWebResponse)e.Response).GetResponseStream();
                        c = new StreamReader(stremm).ReadToEnd();
                    }

                    throw new SystemException(c);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return default(T);
        }

        private static T PostCall<T>(string endPoint,
            object postValues)
        {
            if (!string.IsNullOrEmpty(endPoint))
            {
                string json = JsonConvert.SerializeObject
                (
                    postValues, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

                HttpWebRequest request = GetWebRequestObject(endPoint);
                request.ContentType = "text/json";
                request.Method = "POST";
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byte1 = encoding.GetBytes(json);
                request.ContentLength = byte1.Length;

                request.Credentials = CredentialCache.DefaultCredentials;
                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }

                try
                {
                    HttpWebResponse httpResponse;
                    using (httpResponse = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream stream = httpResponse.GetResponseStream())
                        {
                            var result = JsonConvert.DeserializeObject<T>(new StreamReader(stream).ReadToEnd());
                            return result;
                        }
                    }
                }
                catch (WebException e)
                {
                    string c = string.Empty;
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Stream stremm = ((HttpWebResponse)e.Response).GetResponseStream();
                        c = new StreamReader(stremm).ReadToEnd();
                    }

                    throw new SystemException(c);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return default(T);
        }

        private static HttpWebRequest GetWebRequestObject(string endPoint)
        {
            HttpWebRequest request;
            if (endPoint.Contains("http"))
            {
                request = (HttpWebRequest)WebRequest.Create(endPoint);
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create($"{GetBaseAddress()}Api/{endPoint}");
            }

            request.ProtocolVersion = HttpVersion.Version10;
            request.ServicePoint.Expect100Continue = false;
            request.KeepAlive = false;
            request.Timeout = 60 * 60000;
            return request;
        }

        #endregion Generic Methods For Get & Post Calls
    }
}

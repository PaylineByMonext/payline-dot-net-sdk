using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace SDKPaylineDotNet
{
    public static class PaymentApiFactory
    {

        public static PaylineProperties PaylineSDKProperties
        {
            get
            {
                if (_properties == null)
                    _properties = LoadConfiguration();
                return _properties;
            }
        }

        private static PaylineProperties _properties = null;

        private static void InitClient()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate
            {
                return true;
            };
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Return credential informations with merchant ID and accessKey
        /// </summary>
        /// <returns></returns>
        private static NetworkCredential GetCredential()
        {
            return new NetworkCredential(PaylineSDKProperties.merchantID, PaylineSDKProperties.accessKey);
        }

        /// <summary>
        /// Return true if a prxy is defined in preferences
        /// </summary>
        /// <returns></returns>
        private static bool IsProxyDefined()
        {
            int proxyPort = -1;
            return PaylineSDKProperties.proxyHost != "" && PaylineSDKProperties.proxyPort != "" && int.TryParse(PaylineSDKProperties.proxyPort, out proxyPort); ;
        }

        /// <summary>
        /// Return proxy defined by Host and Port in preferences
        /// </summary>
        /// <returns></returns>
        private static WebProxy GetProxy()
        {
            int proxyPort = -1;
            int.TryParse(PaylineSDKProperties.proxyPort, out proxyPort);
            WebProxy proxy = new WebProxy(PaylineSDKProperties.proxyHost, proxyPort);
            if (PaylineSDKProperties.proxyLogin != "" && PaylineSDKProperties.proxyPassword != "")
                proxy.Credentials = new NetworkCredential(PaylineSDKProperties.proxyLogin, PaylineSDKProperties.proxyPassword);

            if (proxyPort != -1)
                return proxy;
            else
                return null;
        }

        private static T GetApiClient<T>() where T : System.Web.Services.Protocols.SoapHttpClientProtocol, new()
        {
            InitClient();
            var client = new T();
            if (IsProxyDefined())
                client.Proxy = GetProxy();
            client.Credentials = GetCredential();
            if (typeof(T) == typeof(WebPaymentAPI.WebPaymentAPI))
            {
                if (PaylineSDKProperties.Production)
                    client.Url = PaylineSDKProperties.WebPaymentAPIUrlProd;
                else
                    client.Url = PaylineSDKProperties.WebPaymentAPIUrl;
            }
            if (typeof(T) == typeof(DirectPaymentAPI.DirectPaymentAPI))
            {
                if (PaylineSDKProperties.Production)
                    client.Url = PaylineSDKProperties.DirectPaymentAPIUrlProd;
                else
                    client.Url = PaylineSDKProperties.DirectPaymentAPIUrl;
            }
           
            if (typeof(T) == typeof(ExtendedAPI.ExtendedAPI))
            {
                if (PaylineSDKProperties.Production)
                    client.Url = PaylineSDKProperties.ExtendedAPIUrlProd;
                else
                    client.Url = PaylineSDKProperties.ExtendedAPIUrl;
            }
            return client;
        }

        public static WebPaymentAPI.WebPaymentAPI GetWebPaymentAPIClient()
        {
            return GetApiClient<WebPaymentAPI.WebPaymentAPI>();
        }
        public static DirectPaymentAPI.DirectPaymentAPI GetDirectPaymentAPIClient()
        {
            return GetApiClient<DirectPaymentAPI.DirectPaymentAPI>();
        }
  
        public static ExtendedAPI.ExtendedAPI GetExtendedAPIClient()
        {
            return GetApiClient<ExtendedAPI.ExtendedAPI>();
        }

        private static PaylineProperties LoadConfiguration()
        {
            Debug.WriteLine("Payline SDK - trying to load configuration file from " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "payline.properties.xml"));
            //Get properties from payline.properties.xml
            return ((PaylineProperties)SerialXML.Load(AppDomain.CurrentDomain.BaseDirectory, "payline.properties.xml", typeof(PaylineProperties)));
        }
    }
}

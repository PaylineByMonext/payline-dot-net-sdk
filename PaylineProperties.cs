
namespace SDKPaylineDotNet
{
    public class PaylineProperties
    {
        public string DirectPaymentAPIUrl = "https://homologation.payline.com/V4/services/DirectPaymentAPI";
         public string WebPaymentAPIUrl = "https://homologation.payline.com/V4/services/WebPaymentAPI";
        public string ExtendedAPIUrl = "https://homologation.payline.com/V4/services/ExtendedAPI";

        public string DirectPaymentAPIUrlProd = "https://services.payline.com/V4/services/DirectPaymentAPI";
        public string WebPaymentAPIUrlProd = "https://services.payline.com/V4/services/WebPaymentAPI";
        public string ExtendedAPIUrlProd = "https://services.payline.com/V4/services/ExtendedAPI";

        public bool Production = false;
        public string accessKey = "abcdefghijklmnopqrst";
        public string merchantID = "123456789";
        public string proxyHost = "";
        public string proxyPort = "";
        public string proxyLogin = "";
        public string proxyPassword = "";

        //Default properties
        public string DefaultPaymentCurrency = "978";
        public string DefaultOrderCurrency = "978";
        public string DefaultSecurityMode = "SSL";
        public string DefaultLanguage = "english";
        public string DefaultLanguageCode = "EN";
        public string DefaultPaymentAction = "100";
        public string DefaultPaymentMode = "CPT";
        public string DefaultCancelUrl = "";
        public string DefaultNotificationUrl = "";
        public string DefaultReturnUrl = "";
        public string DefaultContractNumber = "CB";
        public string DefaultContractNumberList = "CB;";
        public string SecondContractNumberList = "";
        public string TermUrl = "";
        public string CustomPaymentPageCode = "";
        public string CustomPaymentTemplateUrl = "";


        public string Web2TokenKey = "";
        public string Web2TokenProdUrl = "";
        public string Web2TokenHomoUrl = "";
        public string Web2TokenContractNumber = "";
        public string Web2TokenCallbackUrl= "";

    }
}

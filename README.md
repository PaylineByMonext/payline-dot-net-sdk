## Payline .NET SDK

### Composition du SDK

Le SDK  .NET est composé d'une librairie de fonctions qui permet d'utiliser les fonctions de l'API Payline.

**Configuration du SDK :**

Une fois le SDK référence dans votre projet, vous devez renommer le fichier payline.properties.default.xml en payline.properties.xml et associer des valeurs aux paramètres de configuration.

Utiliser le .Net Framework 4.6.1 au minimum




**Exemple de configuration :**
```xml
<?xml version="1.0"?>
<PaylineProperties xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <DirectPaymentAPIUrl>https://homologation.payline.com/V4/services/DirectPaymentAPI</DirectPaymentAPIUrl>
  <MassPaymentAPIUrl>https://homologation.payline.com/V4/services/MassPaymentAPI</MassPaymentAPIUrl>
  <WebPaymentAPIUrl>https://homologation.payline.com/V4/services/WebPaymentAPI</WebPaymentAPIUrl>
  <ExtendedAPIUrl>https://homologation.payline.com/V4/services/ExtendedAPI</ExtendedAPIUrl>

  <DirectPaymentAPIUrlProd>https://services.payline.com/V4/services/DirectPaymentAPI</DirectPaymentAPIUrlProd>
  <MassPaymentAPIUrlProd>https://services.payline.com/V4/services/MassPaymentAPI</MassPaymentAPIUrlProd>
  <WebPaymentAPIUrlProd>https://services.payline.com/V4/services/WebPaymentAPI</WebPaymentAPIUrlProd>
  <ExtendedAPIUrlProd>https://services.payline.com/V4/services/ExtendedAPI</ExtendedAPIUrlProd>

  <Production>false</Production>
  <accessKey>abcdefghijklmnopqrst</accessKey>
  <merchantID>123456789</merchantID>
  <proxyHost />
  <proxyPort />
  <proxyLogin />
  <proxyPassword />
  <!-- Payline pages language -->
  <DefaultLanguageCode>EN</DefaultLanguageCode>
  <DefaultPaymentCurrency>978</DefaultPaymentCurrency>
  <DefaultOrderCurrency>978</DefaultOrderCurrency>
  <DefaultSecurityMode>SSL</DefaultSecurityMode>
  <DefaultLanguage>english</DefaultLanguage>
  <DefaultPaymentAction>100</DefaultPaymentAction>
  <DefaultPaymentMode>CPT</DefaultPaymentMode>
  <!-- Default cancel URL -->
  <DefaultCancelUrl>https://www.url.fr</DefaultCancelUrl>
  <!-- Default notification URL -->
  <DefaultNotificationUrl>https://www.url.fr</DefaultNotificationUrl>
  <!-- Default return URL -->
  <DefaultReturnUrl>https://www.url.fr</DefaultReturnUrl>
  <!-- Contract type default (ex: 001 = CB, 003 = American Express...) -->
  <DefaultContractNumber>CB</DefaultContractNumber>
  <!-- Contract type multiple values (separator: ;) -->
  <DefaultContractNumberList>CB;</DefaultContractNumberList>
  <SecondContractNumberList></SecondContractNumberList>
  <!-- For 3D Secure authentication -->
  <TermUrl>https://www.url.fr</TermUrl>
  <CustomPaymentPageCode></CustomPaymentPageCode>
  <CustomPaymentTemplateUrl></CustomPaymentTemplateUrl>
  <Web2TokenKey></Web2TokenKey>
  <Web2TokenProdUrl>https://webpayment.payline.com/webpayment/getToken</Web2TokenProdUrl>
  <Web2TokenHomoUrl>https://homologation-webpayment.payline.com/webpayment/getToken</Web2TokenHomoUrl>
  <Web2TokenContractNumber>1234567</Web2TokenContractNumber>
  <Web2TokenCallbackUrl>https://www.url.fr</Web2TokenCallbackUrl>

</PaylineProperties>
```

### Exemple d'utilisation du SDK 
```
            SDKPaylineDotNet.DirectPaymentAPI.DirectPaymentAPI myDirectPaymentAPI = SDKPaylineDotNet.PaymentApiFactory.GetDirectPaymentAPIClient();

            // Retrieve card informations
            card myCard = new card();
            myCard.number = TextBoxCardNumber.Text;
            myCard.type = DropDownListCardType.SelectedValue;
            myCard.expirationDate = TextBoxCardExpiration.Text;
            myCard.cvx = TextBoxCardCryptogram.Text;
            myCard.ownerBirthdayDate = TextBoxCardBirthday.Text;
            myCard.password = TextBoxCardPassword.Text;

            // Retrieve payment informations
            payment myPayment = new payment();
            myPayment.amount = TextBoxPaymentAmount.Text;
            myPayment.currency = TextBoxPaymentCurrency.Text;
            myPayment.action = DropDownListPaymentFunction.SelectedValue;
            myPayment.mode = DropDownListPaymentMode.SelectedValue; ;
            myPayment.contractNumber = TextBoxPaymentContract.Text;
            myPayment.differedActionDate = TextBoxPaymentDifferedDate.Text;

            // Retrieve order informations
            order myOrder = new order();
            myOrder.@ref = TextBoxOrderReference.Text;
            myOrder.origin = TextBoxOrderOrigin.Text;
            myOrder.country = TextBoxOrderCountry.Text;
            myOrder.taxes = TextBoxOrderTaxes.Text;
            myOrder.currency = TextBoxOrderCurrency.Text;
            myOrder.amount = TextBoxOrderAmount.Text;
            myOrder.date = TextBoxOrderDate.Text;
            // Retrieve order details (first part)
            orderDetail myOrderDetails1 = new orderDetail();
            myOrderDetails1.@ref = TextBoxItem1Reference.Text;
            myOrderDetails1.price = TextBoxItem1Price.Text;
            myOrderDetails1.quantity = TextBoxItem1Quantity.Text;
            myOrderDetails1.comment = TextBoxItem1Comment.Text;
            // Retrieve order details (second part)
            orderDetail myOrderDetails2 = new orderDetail();
            myOrderDetails2.@ref = TextBoxItem2Reference.Text;
            myOrderDetails2.price = TextBoxItem2Price.Text;
            myOrderDetails2.quantity = TextBoxItem2Quantity.Text;
            myOrderDetails2.comment = TextBoxItem2Comment.Text;
            myOrder.details = new orderDetail[] { myOrderDetails1, myOrderDetails2 };

            // Retrieve private datas
            privateData myPrivateData1 = new privateData();
            privateData myPrivateData2 = new privateData();
            privateData myPrivateData3 = new privateData();
            myPrivateData1.key = TextBoxPrivateDataKey1.Text;
            myPrivateData1.value = TextBoxPrivateDataValue1.Text;
            myPrivateData2.key = TextBoxPrivateDataKey2.Text;
            myPrivateData2.value = TextBoxPrivateDataValue2.Text;
            myPrivateData3.key = TextBoxPrivateDataKey2.Text;
            myPrivateData3.value = TextBoxPrivateDataValue3.Text;
            var myPrivateDataList = new privateData[] { myPrivateData1, myPrivateData2, myPrivateData3 };

            // Retrieve buyer informations
            buyer myBuyer = new buyer();
            myBuyer.email = TextBoxBuyerEmail.Text;
            myBuyer.accountCreateDate = TextBoxBuyerAccountDate.Text;
            myBuyer.accountAverageAmount = TextBoxBuyerAverageAmount.Text;
            myBuyer.accountOrderCount = TextBoxBuyerOrderCount.Text;

            //Returned datas
            transaction myTransaction = new transaction();
            authorization myAuthorization = new authorization();

            //Retrieve Web Service Version

            string transient = null;
            string linkedTransactionId = null;

            string contractNumber;

            string resultContainer;
            extendedCardType extendedCard;
            cardOut cardOut;
            recurring recurring = null;

            SDKPaylineDotNet.DirectPaymentAPI.result myResult = myDirectPaymentAPI.doAuthorization(ref transient, GlobalVariables.APIVersion, myPayment, myBankAccountData, myCard, myOrder, myBuyer, null, ref myPrivateDataList, null, null,
                               null, null, ref linkedTransactionId, recurring, out myTransaction, out myAuthorization, out cardOut, out extendedCard, out contractNumber, out resultContainer);
            if (myResult.code == "00000")
            {
                Output("OK");
                Output("Transaction id " + myTransaction.id);
            }
            else
            {
                Output("KO");
                Output(myResult.code);
                Output(myResult.longMessage);
                Output(myResult.shortMessage);
                return;
            }
```



### Mise à jour des wsdl :
* Mettre les nouveaux fichiers wsdl dans le répertoire wsdl
* Lancer tools/update_api_client_with_wsdl.bat
* Actualiser le projet
* Régénérer la solution




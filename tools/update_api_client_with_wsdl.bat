rem @echo OFF
set script_directory=%~dp0
del /f "%script_directory%..\Api_Client\*.cs"
 
%script_directory%wsdl.exe %script_directory%..\wsdl\DirectPaymentAPI.wsdl /n:SDKPaylineDotNet.DirectPaymentAPI /o:%script_directory%..\API_Client\DirectPaymentAPI.cs
%script_directory%wsdl.exe %script_directory%..\wsdl\WebPaymentAPI.wsdl /n:SDKPaylineDotNet.WebPaymentAPI /o:%script_directory%..\API_Client\WebPaymentAPI.cs
%script_directory%wsdl.exe %script_directory%..\wsdl\ExtendedAPI.wsdl /n:SDKPaylineDotNet.ExtendedAPI /o:%script_directory%..\API_Client\ExtendedAPI.cs
pause
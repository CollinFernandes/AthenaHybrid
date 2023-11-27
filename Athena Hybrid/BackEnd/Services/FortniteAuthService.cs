using Athena_Hybrid.Properties;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Services
{
    class FortniteAuthService
    {
        public string GetDeviceCode()
        {
            string token = "";
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("Authorization: Basic OThmN2U0MmMyZTNhNGY4NmE3NGViNDNmYmI0MWVkMzk6MGEyNDQ5YTItMDAxYS00NTFlLWFmZWMtM2U4MTI5MDFjNGQ3");
                client.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                string response = client.UploadString("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token", "grant_type=client_credentials");
                JObject jobject = JObject.Parse(response);
                token = jobject["access_token"].ToString();
                LogService.Write("[GetDeviceCode]: the device code was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("[GetDeviceCode]: there was an error while fetching the device code: " + ex.ToString(), LogLevel.Fatal);
            }
            return token;
        }
        public async Task<string> DeviceAuthorization(string token)
        {
            string tokenn = "";
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("Authorization: bearer " + token);
                client.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                string response = client.UploadString("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/deviceAuthorization", "promptType=login");
                JObject jobject = JObject.Parse(response);
                string deviceAuth = jobject["device_code"].ToString();
                string url = jobject["verification_uri_complete"].ToString();
                Process.Start(new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = "/C start " + url
                });
                bool bTrue = true;
                while (bTrue)
                {
                    WebClient client1 = new WebClient();
                    client1.Headers.Add("Authorization: basic OThmN2U0MmMyZTNhNGY4NmE3NGViNDNmYmI0MWVkMzk6MGEyNDQ5YTItMDAxYS00NTFlLWFmZWMtM2U4MTI5MDFjNGQ3");
                    client1.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                    try
                    {
                        string response1 = client1.UploadString("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token", "grant_type=device_code&device_code=" + deviceAuth);

                        if (!response1.Contains("errors"))
                        {
                            JObject o = JObject.Parse(response1);
                            tokenn = o["access_token"].ToString();
                            Settings.Default.epicId = o["account_id"].ToString();
                            Settings.Default.Save();
                            LogService.Write("[DeviceAuthorization]: the token was fetched successfully.");
                            bTrue = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogService.Write("[DeviceAuthorization]: fetching your token... ", LogLevel.Info);
                    }
                }
            }
            catch
            {

            }
            return tokenn;
        }
        public void GetDeviceAuths(string token)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("Authorization: bearer " + token);
                client.Headers.Add("Content-Type: application/json");
                string res = client.DownloadString("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/exchange");
                JObject jobject = JObject.Parse(res);
                string code = jobject["code"].ToString();
                WebClient client2 = new WebClient();
                client2.Headers.Add("Authorization: basic MzQ0NmNkNzI2OTRjNGE0NDg1ZDgxYjc3YWRiYjIxNDE6OTIwOWQ0YTVlMjVhNDU3ZmI5YjA3NDg5ZDMxM2I0MWE=");
                client2.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                string response = client2.UploadString("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token", "grant_type=exchange_code&exchange_code=" + code);
                JObject o = JObject.Parse(response);
                string tk = o["access_token"].ToString();
                WebClient client3 = new WebClient();
                client3.Headers.Add("Authorization: bearer " + tk);
                client3.Headers.Add("Content-Type: application/json");
                string r = client3.UploadString("https://account-public-service-prod.ol.epicgames.com/account/api/public/account/" + Settings.Default.epicId + "/deviceAuth", "{}");
                JObject j = JObject.Parse(r);
                Settings.Default.deviceid = j["deviceId"].ToString();
                Settings.Default.secret = j["secret"].ToString();
                Settings.Default.Save();
                LogService.Write("[GetDeviceAuths]: the deviceId and secret was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("[GetDeviceAuths]: there was an error while fetching the secret and deviceId: " + ex.ToString(), LogLevel.Fatal);
            }

        }
        public string GetToken()
        {
            string token = "";
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Authorization: Basic MzQ0NmNkNzI2OTRjNGE0NDg1ZDgxYjc3YWRiYjIxNDE6OTIwOWQ0YTVlMjVhNDU3ZmI5YjA3NDg5ZDMxM2I0MWE=");
                webClient.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                string response = webClient.UploadString("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token", "grant_type=device_auth&device_id=" + Settings.Default.deviceid + "&secret=" + Settings.Default.secret + "&account_id=" + Settings.Default.epicId);
                JObject jobject = JObject.Parse(response);
                token = jobject["access_token"].ToString();
                Settings.Default.FnUsername = jobject["displayName"].ToString();
                Settings.Default.Save();
                LogService.Write("[GetToken]: the token and displayName was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("[GetToken]: there was an error while fetching the token and displayName: " + ex.ToString(), LogLevel.Fatal);
            }
            return token;
        }
        public void AuthByCode(string authcode)
        {
            try
            {
                WebClient client2 = new WebClient();
                client2.Headers.Add("Authorization: basic MzQ0NmNkNzI2OTRjNGE0NDg1ZDgxYjc3YWRiYjIxNDE6OTIwOWQ0YTVlMjVhNDU3ZmI5YjA3NDg5ZDMxM2I0MWE=");
                client2.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                string response = client2.UploadString("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token", "grant_type=authorization_code&code=" + authcode);
                JObject jobject = JObject.Parse(response);
                string token = jobject["access_token"].ToString();
                WebClient client3 = new WebClient();
                client3.Headers.Add("Authorization: bearer " + token);
                client3.Headers.Add("Content-Type: application/json");
                string r = client3.UploadString("https://account-public-service-prod.ol.epicgames.com/account/api/public/account/" + Settings.Default.epicId + "/deviceAuth", "{}");
                JObject j = JObject.Parse(r);
                Settings.Default.deviceid = j["deviceId"].ToString();
                Settings.Default.secret = j["secret"].ToString();
                Settings.Default.Save();
                LogService.Write("[AuthByCode]: the deviceId and secret was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("[AuthByCode]: there was an error while fetching the deviceId and secret: " + ex.ToString(), LogLevel.Fatal);
            }

        }
        public async Task<string> GetExchange(string code)
        {
            string EXCHANGE = "";
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("Authorization: bearer " + code);
                client.Headers.Add("Content-Type: application/json");
                string res = client.DownloadString("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/exchange");
                JObject jobject = JObject.Parse(res);
                EXCHANGE = jobject["code"].ToString();
                LogService.Write("[GetExchange]: the exchange was fetched successfully.");
            }
            catch (Exception ex)
            {
                LogService.Write("[GetExchange]: there was an error while fetching the exchange: " + ex.ToString(), LogLevel.Fatal);
            }
            return EXCHANGE;
        }
        public static async Task<string> GenCaldera()
        {
            FortniteAuthService auth = new FortniteAuthService();
            RestClient calderaClient = new RestClient("https://caldera-service-prod.ecosec.on.epicgames.com");
            RestRequest calderaRequest = new RestRequest("/caldera/api/v1/launcher/racp");
            calderaRequest.AddJsonBody(new { account_id = Settings.Default.epicId, exchange_code = await auth.GetExchange(auth.GetToken()), test_mode = false, epic_app = "fortnite", nvidia = false, luna = false });

            var response = calderaClient.Post(calderaRequest);
            var content = response.Content;
            JObject jObject = JObject.Parse(content);

            return jObject["jwt"].ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace stockdata.utils
{
    public class HttpRestClient
    {
        public const string REST_METHOD_READ = "GET";
        public const string REST_METHOD_CREATE = "POST";
        public const string REST_METHOD_UPDATE = "PUT";
        public const string REST_METHOD_DELETE = "DELETE";

        public const string DATA_FORMAT_JSON = "application/json";
        public const string DATA_FORMAT_XML = "application/xml";
        public const string DATA_FORMAT_TEXT = "text/plain";
        public const string DATA_FORMAT_HTML = "text/html";
        public const string DATA_FORMAT_FORM = "application/x-www-form-urlencoded";

        public const string API_AUTH_VERSION = "API1-HMAC-SHA256";

        private HttpWebRequest request = null;

        // ---------------------------------------------------------------- //
        // 요청정보
        // ---------------------------------------------------------------- //

        /// <summary>
        /// 요청 메서드, HttpRestClient.REST_METHOD_(READ|CREATE|UPDATE|DELETE)
        /// </summary>
        public string Method { get; set; } = REST_METHOD_READ;

        /// <summary>
        /// 리소스 경로
        /// </summary>
        public string ResourceName { get; set; } = "";

        /// <summary>
        /// 리소스 경로 뒤 옵션 쿼리 스트링 배열
        /// </summary>
        public Dictionary<string, string> QueryString { get; set; } = new Dictionary<string, string>();

        public bool UserEncryptMode { get; set; } = Configure.httpEncrypt;

        /// <summary>
        /// 요청을 보내면서 사용할 데이터 포맷 (요청 Content-type)
        /// </summary>
        public string RequestDataFormat { get; set; } = DATA_FORMAT_FORM;

        /// <summary>
        /// 요청 내용 배열 (POST, PUT 요청 데이터)
        /// </summary>
        public byte[] RequestContent { get; set; } = new byte[0];

        /// <summary>
        /// 응답 데이터 포맷 Recommand (Accept 헤더)
        /// </summary>
        public string ResponseDataFormat { get; set; } = DATA_FORMAT_JSON;

        /// <summary>
        /// 타임아웃
        /// </summary>
        public int Timeout { get; set; } = 30;

        /// <summary>
        /// 요청을 실행했는지 여부
        /// </summary>
        public bool isWorked { get; private set; } = false;

        /// <summary>
        /// URL 생성
        /// </summary>
        public string RequestUri { get; set; } = "";

        // ---------------------------------------------------------------- //
        // 응답정보
        // ---------------------------------------------------------------- //

        /// <summary>
        /// 요청에 대한 응답코드 (-1:요청전, 100미만:WebExceptionStatus 100이상: HttpStatusCode)
        /// </summary>
        public int ResponseCode { get; private set; } = -1;

        /// <summary>
        /// 응답 메시지
        /// </summary>
        public string ResponseMessage { get; private set; } = "";

        /// <summary>
        /// Content-type 헤더에 대한 응답
        /// </summary>
        public string ContentType { get; private set; } = "";

        /// <summary>
        /// Charset (있을 경우)
        /// </summary>
        public string CharacterSet { get; private set; } = "";

        /// <summary>
        /// 응답 내용 배열
        /// </summary>
        public byte[] ResponseContent { get; private set; } = new byte[0];

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public HttpRestClient() { }

        /// <summary>
        /// 리소스 경로를 가지는 생성자
        /// </summary>
        /// <param name="resourceName">리소스 경로</param>
        public HttpRestClient(string resourceName) : this()
        {
            ResourceName = resourceName;
        }

        /// <summary>
        /// 요청 메서드와 리소스 경로를 가지는 생성자
        /// </summary>
        /// <param name="method">요청 메서드, HttpRestClient.REST_METHOD_(READ|CREATE|UPDATE|DELETE)</param>
        /// <param name="resourceName">리소스 경로</param>
        public HttpRestClient(string method, string resourceName) : this()
        {
            Method = method;
            ResourceName = resourceName;
        }

        /// <summary>
        /// 통신 다이얼로그를 생성하고 서버와 통신 처리한다.
        /// </summary>
        /// <returns></returns>
        public bool doWorkDialog()
        {
            new frmTransWaiting(this).ShowDialog();
            return isSuccess();
        }

        /// <summary>
        /// 서버와 통신
        /// </summary>
        public bool doWork()
        {
            if (isWorked)
                return isSuccess();

            isWorked = true;
            try
            {
                request = createWebRequest();
                // POST or PUT
                if (Method.Equals(REST_METHOD_CREATE) || Method.Equals(REST_METHOD_UPDATE))
                {
                    // 암호화처리
                    if (RequestContent.Length > 0 && UserEncryptMode)
                    {
                        byte[] aesenc = AESUtil.Encrypt(RequestContent);
                        RequestContent = Encoding.UTF8.GetBytes(Convert.ToBase64String(aesenc));
                    }

                    request.ContentType = RequestDataFormat;   //; charset=UTF-8
                    request.ContentLength = RequestContent.Length;

                    if (RequestContent.Length > 0)
                    {
                        using (Stream reqStream = request.GetRequestStream())
                        {
                            reqStream.Write(RequestContent, 0, RequestContent.Length);
                        }
                    }
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    ResponseCode = (int)WebExceptionStatus.Success;
                    if (response != null)
                    {
                        responseProc(response);
                    }
                    else
                    {
                        Console.WriteLine("No response.");
                    }
                }
            }
            catch (UriFormatException ufe)
            {
                Console.WriteLine("UriFormatException Message " + ufe.Message);
                Console.WriteLine("Uri : " + RequestUri);

                ResponseMessage = "UriFormatException: " + ufe.Message + " " + RequestUri;
            }
            catch (WebException we)
            {
                Console.WriteLine("WebException Message " + we.Message);

                if (we.Status == WebExceptionStatus.ProtocolError)
                {
                    using (HttpWebResponse response = (HttpWebResponse)we.Response)
                    {
                        if (response != null)
                        {
                            responseProc(response);

                            Exception basee = we.GetBaseException();
                            if (basee != null)
                                ResponseMessage += ": " + basee.Message;
                            else
                                ResponseMessage += ": " + we.Message;
                        }
                        else
                        {
                            Console.WriteLine("No response.");
                            ResponseMessage = we.Status.ToString() + ": " + we.Message;
                        }
                    }
                }
                else
                {
                    ResponseCode = (int)we.Status;
                    Exception basee = we.GetBaseException();
                    if (basee != null)
                        ResponseMessage = we.Status.ToString() + ": " + basee.Message;
                    else
                        ResponseMessage = we.Status.ToString() + ": " + we.Message;
                }

                Console.WriteLine("RespCode " + ResponseCode);
                Console.WriteLine("RespMesg " + ResponseMessage);
            }

            return isSuccess();
        }

        /// <summary>
        /// 요청처리 중지
        /// </summary>
        public void Abort()
        {
            if (request != null)
            {
                request.Abort();
            }
        }

        /// <summary>
        /// 요청 성공 여부 모니터링, 응답이 없더라도 요청이 성공했으면 true
        /// </summary>
        /// <returns></returns>
        public bool isSuccess()
        {
            if (ResponseCode == 0 || (ResponseCode >= 200 && ResponseCode < 300))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 요청 응답을 string 으로 가져온다.
        /// </summary>
        /// <returns></returns>
        public string getString()
        {
            if (!isWorked)
                doWork();

            if (ContentType.ToLower().IndexOf("utf-8") >= 0 || CharacterSet.ToLower().IndexOf("utf-8") >= 0)
                return Encoding.UTF8.GetString(ResponseContent);
            else
                return Encoding.Default.GetString(ResponseContent);
        }

        /// <summary>
        /// 요청 응답을 string 으로 가져온다.
        /// </summary>
        /// <returns></returns>
        public string getString(Encoding encoding)
        {
            if (!isWorked)
                doWork();

            return encoding.GetString(ResponseContent);
        }

        /// <summary>
        /// 요청 응답을 JObject (LINQ) 으로 가져온다.
        /// </summary>
        /// <returns>json 포맷이 아닐 경우 null</returns>
        public dynamic getJsonObject()
        {
            Console.WriteLine("Content-type: " + ContentType);
            //ContentType.indexOf(DATA_FORMAT_JSON) < 0
            try
            {
                return JObject.Parse(getString(Encoding.UTF8));
            }
            catch (JsonReaderException jre)
            {
                // Json parse error
                Console.WriteLine("getJsonObject Message " + jre.Message);
                return null;
            }
        }

        /// <summary>
        /// HttpWebRequest 객체를 생성하고 초기화한다.
        /// </summary>
        /// <returns></returns>
        private HttpWebRequest createWebRequest()
        {
            makeUriString();

            Console.WriteLine("HttpRestClient " + Method + " " + RequestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RequestUri);
            request.Method = Method;
            request.ReadWriteTimeout = Timeout * 1000;
            request.Timeout = Timeout * 1000;
            request.Accept = ResponseDataFormat;
            //request.Credentials = CredentialCache.DefaultCredentials;
            request.UserAgent = "StockItemData Client";
            //request.Referer = "";

            //request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            string authorize = getAuthorizationString();
            if (authorize != null && authorize.Length > 0)
            {
                // 인식하지 않음
                // request.Credentials 을 사용할 것을 권장하는데 개발하기 번거로우니, X- 헤더로 대체함
                //request.PreAuthenticate = true;
                //request.Headers.Add("Authorization", authorize);
                request.Headers.Add("X-Authorization", authorize);
            }

            if (UserEncryptMode)
            {
                // 암호화헤더 추가
                byte[] key = AESUtil.createRandomKeys(AESUtil.AES_BITS_256);
                AESUtil.Key = key;
                string rsaEncodedKey = "AES/256/CBC," + RSAEncrypt.Encrypt(key);
                Console.WriteLine("X-Encrypt-Key:" + rsaEncodedKey);
                request.Headers.Add("X-Encrypt-Key", rsaEncodedKey);
            }

            return request;
        }

        /// <summary>
        /// URI 생성
        /// </summary>
        private void makeUriString()
        {
            if (RequestUri != null && RequestUri.Length > 0)
                return;

            // uri base
            string url = Configure.server + "/" + Configure.apiVersion + "/" + ResourceName;

            // append query string
            string query = "";
            foreach (KeyValuePair<string, string> item in QueryString)
            {
                if (query.Length > 0)
                    query += "&";

                query += HttpUtility.UrlEncode(item.Key, Encoding.UTF8);
                query += "=";
                query += HttpUtility.UrlEncode(item.Value, Encoding.UTF8);
            }
            if (query.Length > 0)
                url += "?" + query;

            RequestUri = url;
        }

        /// <summary>
        /// 인증정보 헤더 추가
        /// </summary>
        /// <param name="request">request 객체</param>
        private string getAuthorizationString()
        {
            // API 키 정보가 없으면 생략
            if (Configure.apiKey == null || Configure.apiKey.Length == 0 ||
                Configure.apiSecret == null || Configure.apiSecret.Length == 0)
                return null;

            string credential = Configure.apiKey + "/" + DateTime.UtcNow.ToString("yyyyMMdd") + "/" + ResourceName;
            byte[] signature = null;
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(Configure.apiSecret)))
            {
                signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(credential));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(API_AUTH_VERSION);
            sb.Append(" ");
            sb.Append("Credential=");
            sb.Append(credential);
            sb.Append(", ");
            sb.Append("Signature=");
            for (int i = 0; i < signature.Length; i++)
            {
                sb.Append(signature[i].ToString("x2"));
            }

            Console.WriteLine("Authorization: " + sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// HttpWebResponse 처리
        /// </summary>
        /// <param name="response"></param>
        private void responseProc(HttpWebResponse response)
        {
            Console.WriteLine("HttpRestClient Status: " + response.StatusCode + " - " + response.StatusDescription);
            ResponseCode = (int)response.StatusCode;
            ResponseMessage = response.StatusDescription;
            ContentType = response.ContentType;
            CharacterSet = response.CharacterSet;

            //Console.WriteLine("ContentType: " + response.ContentType);
            //Console.WriteLine("Charset: " + response.CharacterSet);

            using (MemoryStream memStream = new MemoryStream())
            using (Stream respStream = response.GetResponseStream())
            {
                respStream.CopyTo(memStream);
                ResponseContent = memStream.ToArray();
            }

            // 복호화처리
            //X-Encrypted 헤더 찾기
            string encmode = response.GetResponseHeader("X-Encrypted");
            if (UserEncryptMode && encmode != null && encmode.Equals("enabled"))
            {
                Console.WriteLine("Data encrypted.");
                byte[] b64dec = Convert.FromBase64String(Encoding.UTF8.GetString(ResponseContent));
                ResponseContent = AESUtil.Decrypt(b64dec);
            }
        }
    }
}

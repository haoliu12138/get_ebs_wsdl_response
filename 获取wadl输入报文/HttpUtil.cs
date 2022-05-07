using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace 获取wadl输入报文
{

    public static class HttpUtil
    {
        /// <summary>
        /// 通过url获取响应报文
        /// </summary>
        /// <param name="url">传入要访问的url</param>
        /// <returns></returns>
        public static string GetResponseString(string url)
        {
            //返回字符串
            string result;
            if (url.StartsWith("https"))
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }
            HttpClient httpClient = new HttpClient();
            //设置请求头
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            //添加授权
            //httpClient.DefaultRequestHeaders.Add("Authorization", GlobalData.Authorization);
            //获取响应的消息
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;
            //响应码为ok才进行赋值
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                 result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            }
            else 
            {
                result = "响应数据失败，状态码为"+ httpResponseMessage.StatusCode;
            }
            return result;

        }
    }
}

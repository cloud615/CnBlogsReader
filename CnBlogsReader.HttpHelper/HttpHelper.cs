using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace CnBlogsReader.HttpHelper
{
    public sealed partial class RequestHelper
    {
        HttpClient httpClient;
        CancellationTokenSource cts;
        public RequestHelper()
        {
            var filter = new HttpBaseProtocolFilter();
            filter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            httpClient = new HttpClient(filter);

            cts = new CancellationTokenSource();
        }
        public async Task<string> HttpGet(string argURL)
        {
            Uri uri = new Uri(argURL);
            // 获取网络的返回的字符串数据    
            string result = await httpClient.GetStringAsync(uri);

            return result;
        }

        public async Task<string> HttpGet_ResponseBody(string argURL)
        {
            Uri uri = new Uri(argURL);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<byte[]> HttpGet_Stream(string argURL)
        {
            Uri uri = new Uri(argURL);
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
            {
                int read = 0;
                byte[] responseBytes = new byte[1000];
                do
                {
                    // 如果read等于0，表示stream的数据已经读取完毕
                    read = await responseStream.ReadAsync(responseBytes, read, responseBytes.Length);
                } while (read != 0);

                return responseBytes;
            }
        }

        public async Task<string> HttpPost_ResponseBody(string argURL, string argPostContent)
        {
            Uri uri = new Uri(argURL);
            HttpStringContent httpStringContent = new HttpStringContent(argPostContent);
            HttpResponseMessage response = await httpClient.PostAsync(uri, httpStringContent).AsTask(cts.Token);
            string responseBody = await response.Content.ReadAsStringAsync().AsTask(cts.Token);

            return responseBody;
        }

        public async Task<string> HttpPost_Stream(string argURL, Stream stream)
        {
            Uri uri = new Uri(argURL);
            HttpStreamContent streamContent = new HttpStreamContent(stream.AsInputStream());
            HttpResponseMessage response = await httpClient.PostAsync(uri, streamContent).AsTask(cts.Token);
            string responseBody = await response.Content.ReadAsStringAsync().AsTask(cts.Token);

            return responseBody;
        }

        public async Task<string> HttpSendRequest(string argURL, Stream stream)
        {
            Uri uri = new Uri(argURL);
            HttpStreamContent streamContent = new HttpStreamContent(stream.AsInputStream());
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = streamContent;
            // 发送数据
            HttpResponseMessage response = await httpClient.SendRequestAsync(request).AsTask(cts.Token);
            string responseBody = await response.Content.ReadAsStringAsync().AsTask(cts.Token);

            return responseBody;
        }


        public async Task CancelHttpRequest(string resourceAddress)
        {
            var responseBody = "";
            try
            {
                // 使用CancellationTokenSource对象来控制异步任务的取消操作
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(resourceAddress)).AsTask(cts.Token);
                responseBody = await response.Content.ReadAsStringAsync().AsTask(cts.Token);
                cts.Token.ThrowIfCancellationRequested();
            }
            catch (TaskCanceledException)
            {
                responseBody = "请求被取消";
                // 调用cancel方法，取消网络请求
                if (cts.Token.CanBeCanceled)
                {
                    cts.Cancel();
                }

            }
        }

        /*
         * 12.2.3 设置和获取Cookie
            Cookie是指某些网站为了辨别用户身份、进行回话跟踪而储存在用户本地终端上的数据（通常经过加密）。
         * 那么当我们在使用HTTP请求的时候，如果服务器返回的数据待用Cookie数据，我们也是可以获取出来，
         * 存储在本地，下次发起HTTP请求的时候就会带上这些Cookie的数据。
            在HttpClient类的网络请求中我们可以通过HttpBaseProtocolFilter类来获取网站的Cookie信息，
         * HttpBaseProtocolFilter类表示是HttpClient的HTTP请求的基础协议的过滤器。
         * 获取Cookie的代码示例如下所示：
            // 创建一个HttpBaseProtocolFilter对象    
         * HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();    
         * // 通过HttpBaseProtocolFilter对象获取使用HttpClient进行过网络请求的地址的Cookie信息    
         * HttpCookieCollection cookieCollection = filter.CookieManager.GetCookies(new Uri(resourceAddress));    
         * // 遍历整个Cookie集合的Cookie信息    
         * foreach (HttpCookie cookie in cookieCollection)    {    }
 
            当然我们在发送HTTP请求的时候也一样可以带上Cookie信息，
         * 如果服务器可以识别到Cookie信息那么就会通过Cookie信息来进行一些操作，
         * 比如Cookie信息信息带有用户名和密码的加密信息，那么就可以免去登陆的步骤。
         * 在HttpClient的网路请求里面HttpCookie类表示是一个Cookie对象，
         * 创建好Cookie对象之后通过HttpBaseProtocolFilter对象的CookieManager属性来设置Cookie，
         * 然后发送网络请求，这时候的网络请求就会把Cookie信息给带上。
         * 设置Cookie的代码示例如下所示：
            // 创建一个HttpCookie对象，"id"表示是Cookie的名称，"localhost"是主机名，"/"是表示服务器的虚拟路径    
         * HttpCookie cookie = new HttpCookie("id", "yourwebsite.com", "/");    
         * // 设置Cookie的值    
         * cookie.Value = "123456";    
         * // 设置Cookie存活的时间，如果设置为null表示只是在一个会话里面生效    
         * cookie.Expires = new DateTimeOffset(DateTime.Now, new TimeSpan(0, 1, 8));    
         * // 在过滤器里面设置Cookie    
         * HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();    
         * bool replaced = filter.CookieManager.SetCookie(cookie, false);
            ……接下来可以向"yourwebsite.com"远程主机发起请求
    12.2.4 网络请求的进度监控
            HttpClient的网络请求是支持进度监控，通过异步任务的IProgress<T>对象可以直接监控到HttpClient的网络请求返回的进度信息，
         * 返回的进度对象是HttpProgress类对象。
         * 在进度对象HttpProgress里面包含了下面的一些信息：Stage（当前的状态）、BytesSent（已发送的数据大小）、
         * BytesReceived（已接收的数据大小）、Retries（重试的次数）、TotalBytesToSend（总共需要发送的数据大小）
         * 和TotalBytesToReceive（总共需要接收的数据大小）。
         * 网络请求进度监控的代码示例如下所示：
            // 创建IProgress<HttpProgress>对象    
         * IProgress<HttpProgress> progress = new Progress<HttpProgress>(ProgressHandler);    
         * // 在异步任务中加入进度监控    
         * HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress), streamContent).AsTask(cts.Token, progress);    
         * // 进度监控的回调方法    
         * private void ProgressHandler(HttpProgress progress)    {        // 在这里可以通过progress参数获取到进度的相关信息    }
         */



    }
}

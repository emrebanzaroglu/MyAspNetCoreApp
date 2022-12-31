using System.Net;

namespace MiddlewareExample.Web.Middlewares
{
    public class WhitetIPAddressControlMiddleware
    {
        // bir sınıfın middleware olabilmesi için ctorunda RequestDelegate olmalı ve InvokeAsync adında metodu olması gerekir.

        private readonly RequestDelegate _requestDelegate;
        private const string WhiteIpAddress = "::1";  //eğer bunu seçersek doğru çalışır çünkü aktif ip adres budur
        //private const string WhiteIpAddress = "192.01.01.02";  // eğer bunu seçersek hep forbidden yazılı bir sayfa gelir ekrana çünkü yanlış ip adresidir.
        public WhitetIPAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context) //parametre olarak HttpContext geçiyoruz çünkü uygulamanın kalbidir. Tüm request ve response'a HttpContext üzerinden erişicez.
        {
            var reqIdAddress = context.Connection.RemoteIpAddress;
            bool AnyWhiteIpAddress = IPAddress.Parse(WhiteIpAddress).Equals(reqIdAddress); //reqIdAddress'den gelen ip adres ile WhiteIpAddress'i karşılaştır demek.
            if (AnyWhiteIpAddress==true) //eşleşiyorsa
            {
                await _requestDelegate(context);  // eşleşiyorsa requeste context'i vererek yoluna devam et dedik.
            }
            else
            {
                context.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();  // 403 durum kodunu çekiyoruz buradan. Sağ taraftan int değer geliyor
                await context.Response.WriteAsync("Forbidden");
            }
        }
    }
}

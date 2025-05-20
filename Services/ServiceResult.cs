using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public List<string>? ErrorMessage { get; set; }// hata mesajı için
        public bool IsSuccess() => ErrorMessage == null || ErrorMessage.Count == 0; // hata mesajı yoksa true döner.

        public bool IsFail() => !IsSuccess(); // hata mesajı varsa true döner.

        public HttpStatusCode Status { get; set; }  // default olarak 200 döner.  




        //static factory methodlar newlemeyi kontrol altına aldık
        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = status,
            };
        }
        public static ServiceResult<T> Fail(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = errorMessage,
                Status = status,
            };
        }
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = new List<string>() { errorMessage },
                Status = status,
            };
        }
    }


    //artıkdatayı dolurmuyorum başarılımı başarısızmı olduğunu kontrol ediyorum.
    //udapte ve delete için gerekli burası
    public class ServiceResult
    {
       

        public List<string>? ErrorMessage { get; set; }// hata mesajı için
        public bool IsSuccess() => ErrorMessage == null || ErrorMessage.Count == 0; // hata mesajı yoksa true döner.

        public bool IsFail() => !IsSuccess(); // hata mesajı varsa true döner.

        public HttpStatusCode Status { get; set; }  // default olarak 200 döner.  




        //static factory methodlar newlemeyi kontrol altına aldık
        public static ServiceResult Success( HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
              
                Status = status,
            };
        }
        public static ServiceResult Fail(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = errorMessage,
                Status = status,
            };
        }
        public static ServiceResult Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = new List<string>() { errorMessage },
                Status = status,
            };
        }
    }
}

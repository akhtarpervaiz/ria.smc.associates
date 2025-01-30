using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using static ria.smc.associates.UI.CustomException;

namespace ria.smc.associates.UI
{
    public class CustomExceptionHandler:IExceptionFilter
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public CustomExceptionHandler(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            var errorFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "ErrorLogs");

            if (!System.IO.Directory.Exists(errorFolder))
            {
                System.IO.Directory.CreateDirectory(errorFolder);
            }

            string timestamp = DateTime.Now.ToString("d-MMMM-yyyy", CultureInfo.InvariantCulture);
            var newFileName = $"Log_{timestamp}.txt";
            var filepath = Path.Combine(_hostingEnvironment.ContentRootPath, "ErrorLogs") + $@"\{newFileName}";

            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : getErrorCode(context.Exception.GetType());

            StringBuilder expectionStringBuilder = new StringBuilder();
            expectionStringBuilder.AppendLine("Message ---\n{0}" + context.Exception.Message);
            expectionStringBuilder.AppendLine("statusCode ---\n{0}" + statusCode);
            expectionStringBuilder.AppendLine("Source ---\n{0}" + context.Exception.Source);
            expectionStringBuilder.AppendLine("StackTrace ---\n{0}" + context.Exception.StackTrace);
            expectionStringBuilder.AppendLine("TargetSite ---\n{0}" + context.Exception.TargetSite);

            if (!File.Exists(filepath))
            {
                using (var writer = File.CreateText(filepath))
                {
                    var controllerName = context.RouteData.Values["controller"];
                    var actionName = context.RouteData.Values["action"];
                    writer.WriteLineAsync($"ControllerName :-{controllerName}");
                    writer.WriteLineAsync($"ActionName :- {actionName}");
                    writer.WriteLineAsync("Exception");
                    writer.WriteLineAsync(expectionStringBuilder.ToString());
                }
            }
            else
            {
                using (var writer = File.AppendText(filepath))
                {
                    var controllerName = context.RouteData.Values["controller"];
                    var actionName = context.RouteData.Values["action"];
                    writer.WriteLineAsync($"ControllerName :-{controllerName}");
                    writer.WriteLineAsync($"ActionName :- {actionName}");
                    writer.WriteLineAsync("Exception");
                    writer.WriteLineAsync(expectionStringBuilder.ToString());
                }
            }

            ////throw new NotImplementedException();
            //HttpStatusCode statusCode = (context.Exception as WebException != null &&
            //            ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
            //             ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
            //             : getErrorCode(context.Exception.GetType());
            //string errorMessage = context.Exception.Message;
            ////string customErrorMessage = Constant.ERRORMSG;
            //string customErrorMessage = context.Exception.Source;
            //string stackTrace = context.Exception.StackTrace;

            //HttpResponse response = context.HttpContext.Response;
            //response.StatusCode = (int)statusCode;
            //response.ContentType = "application/json";
            //var result = JsonConvert.SerializeObject(
            //    new
            //    {
            //        message = customErrorMessage,
            //        isError = true,
            //        errorMessage = errorMessage,
            //        errorCode = statusCode,
            //        model = string.Empty
            //    });
            //#region Logging  
            //ILoggerFactory loggerFactory = null;
            //var path = Directory.GetCurrentDirectory();
            //loggerFactory.AddFile($"{path}\\Logs\\Log.txt");




            //#endregion Logging  
            //response.ContentLength = result.Length;
            //response.WriteAsync(result);
        }
        private HttpStatusCode getErrorCode(Type exceptionType)
        {
            Exceptions tryParseResult;
            if (Enum.TryParse<Exceptions>(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case Exceptions.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case Exceptions.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case Exceptions.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Exceptions.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case Exceptions.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case Exceptions.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case Exceptions.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case Exceptions.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case Exceptions.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case Exceptions.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case Exceptions.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case Exceptions.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case Exceptions.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Exceptions.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case Exceptions.IOException:
                        return HttpStatusCode.NotFound;

                    case Exceptions.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}

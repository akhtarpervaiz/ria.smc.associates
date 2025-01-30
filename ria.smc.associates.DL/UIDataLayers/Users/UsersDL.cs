using ApiCaller.ServiceCaller;
using ria.smc.associates.UI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DL.UIDataLayers.Users
{
    public static class UsersDL
    {
        public static LoginResponse Login(LoginRequest loginRequest)
        {
            string endPoint = $"User/GetUserInformation";
            return HttpCaller.Post<LoginResponse>(endPoint, loginRequest);
        }
    }
}

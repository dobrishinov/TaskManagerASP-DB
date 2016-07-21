namespace WebTaskManager.Models
{
    using DataAccess.Entity;
    using DataAccess.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class AuthenticationManager
    {
        public static UserEntity LoggedUser
        {
            get
            {
                Auth auth = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                    HttpContext.Current.Session["LoggedUser"] = new Auth();

                auth = (Auth)HttpContext.Current.Session["LoggedUser"];
                return auth.LoggedUser;
            }
        }

        public static void Authenticate(string username, string password)
        {
            Auth authenticationService = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                HttpContext.Current.Session["LoggedUser"] = new Auth();

            authenticationService = (Auth)HttpContext.Current.Session["LoggedUser"];
            authenticationService.AuthenticateUser(username, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}
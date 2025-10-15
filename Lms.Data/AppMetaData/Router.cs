using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public const string singleRoute = "/{Id}";

        public static class StudentRouting
        {
            public const string prefix = Rule + "Student";
            public const string List = prefix + "/List";
            public const string Paginated = prefix + "/Paginated";
            public const string GetById = prefix + singleRoute;
            public const string Create = prefix + "/Create";
            public const string Edit = prefix + "/Edit";
            public const string Delete = prefix + singleRoute;


        }
        public static class ApplicationUserRouting
        {
            public const string prefix = Rule + "Auth";
            public const string Create = prefix + "/Create";
            public const string Paginated = prefix + "/Paginated";
            public const string GetById = prefix + "/Id";
            public const string Edit = prefix + "/Edit";
            public const string ChangePassword = prefix + "/Change-Password";
            public const string Delete = prefix + singleRoute;

        }
        public static class DepartmentRouting
        {
            public const string prefix = Rule + "Department";
            public const string List = prefix + "/List";
            public const string Paginated = prefix + "/Paginated";
            public const string GetById = prefix + "/Id";
            public const string Create = prefix + "/Create";
            public const string Edit = prefix + "/Edit";
            public const string Delete = prefix + singleRoute;


        }
        public static class Authentication
        {
            public const string prefix = Rule + "Authentication";
            public const string SignIn = prefix + "/SingIn";



        }

    }
}

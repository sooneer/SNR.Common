namespace SNR.Common;

public struct Strings
{
    public static string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public struct General
    {
        public struct App
        {
            public const string Name = "SNR";
        }

        public struct Token
        {
            public const int Lenght = 30;
        }
    }

    public struct Configuration
    {
        public struct ConnectionStrings
        {
            public const string SqlConnection = "SqlConnection";
        }

        public struct Parameter
        {
            public const string UploadPath = "UploadPath";
        }
    }

    public struct DB
    {
        public struct StoredProcedure
        {
        }
    }

    public struct API
    {
        public struct Header
        {
            public const string Token = "Token";
            public const string Locale = "Locale";
            public const string CompanyCode = "CompanyCode";
        }
    }

    public struct Log
    {
        public struct EventId
        {
            public const int Login = 1001;
            public const int General = 2001;
        }
    }
}
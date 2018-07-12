using System.Configuration;

namespace LMS.Util
{
    public static class ConfigurationData
    {
        public static string GithubBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["GithubBaseUrl"];
            }
        }
        public static string TwitterBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterBaseUrl"];
            }
        }

        public static string TwitterApiVersion
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterApiVersion"];
            }
        }

        public static string TwitterConsumerKey
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterConsumerKey"];
            }
        }

        public static string AccessToken {
            get
            {
                return ConfigurationManager.AppSettings["AccessToken"];
            }
        }

        public static string TwitterConsumerSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterConsumerSecret"];
            }
        }
        public static string AccessTokenSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["AccessTokenSecret"];
            }
        }

        public static string StackOverflowBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["StackOverflowBaseUrl"];
            }
        }

        public static string StackOverflowApiVersion
        {
            get
            {
                return ConfigurationManager.AppSettings["StackOverflowApiVersion"];
            }
        }
    }
}
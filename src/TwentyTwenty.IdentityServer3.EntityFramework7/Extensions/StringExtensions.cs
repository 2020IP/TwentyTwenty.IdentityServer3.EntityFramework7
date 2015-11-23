﻿namespace TwentyTwenty.IdentityServer3.EntityFramework7.Extensions
{
    internal static class StringExtensions
    {
        public static string GetOrigin(this string url)
        {
            if (url != null && (url.StartsWith("http://") || url.StartsWith("https://")))
            {
                var idx = url.IndexOf("//");
                if (idx > 0)
                {
                    idx = url.IndexOf("/", idx + 2);
                    if (idx >= 0)
                    {
                        url = url.Substring(0, idx);
                    }
                    return url;
                }
            }

            return null;
        }
    }
}
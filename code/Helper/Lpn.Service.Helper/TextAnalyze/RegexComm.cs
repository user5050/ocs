using System;
using System.Text;
using System.Text.RegularExpressions;

namespace OneCoin.Service.Helper.TextAnalyze
{
    public class RegexComm
    {
        public const string HttpUrl = @"https?\:\/\/[A-Za-z0-9\.\?\&\/_\%\-\=\:]+";

        public static string GetRegexReplacedValue(string source, string findpattern, string replaceValue, RegexOptions regexOptions)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            var reg = new Regex(findpattern, regexOptions);

            return  reg.Replace(source, replaceValue);
        }


        public static string GetRegexReplacedValue(string source, string findpattern, string replaceValue, int groupIndex, RegexOptions regexOptions)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            var matches = GetMatches(source, findpattern, regexOptions);
            var newString = new StringBuilder();
            var prvIndex = 0;
            foreach (Match item in matches)
            {
                if (groupIndex < item.Groups.Count)
                {
                    if (prvIndex < item.Groups[groupIndex].Index)
                    {
                        newString.Append(source.Substring(prvIndex, (item.Groups[groupIndex].Index - prvIndex)));
                    }

                    newString.Append(replaceValue);
                    prvIndex = item.Groups[groupIndex].Index + item.Groups[groupIndex].Length;
                }
            }

            if (prvIndex < source.Length)
            {
                newString.Append(source.Substring(prvIndex, source.Length - prvIndex));
            }

            return newString.ToString();
        }


        /// <summary>
        /// 正则表达式 获取匹配值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pattern"></param>
        /// <param name="regexOptions"></param>
        /// <returns></returns>
        public static string GetRegexValue(string source, string pattern, RegexOptions regexOptions)
        {
            return GetRegexValue(source, pattern, regexOptions, 1);
        }


        public static string GetRegexValue(string source, string pattern, RegexOptions regexOptions, int groupIndex)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            var reg = new Regex(pattern, regexOptions);

            if (reg.IsMatch(source))
            {
                var curMatch = reg.Match(source);

                if (curMatch.Groups.Count <= groupIndex)
                    throw new IndexOutOfRangeException("groupIndex 超出范围");

                return curMatch.Groups[groupIndex].Value;
            }

            return string.Empty;
        }

        /// <summary>
        /// 正则表达式 是否匹配
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pattern"></param>
        /// <param name="regexOptions"></param>
        /// <returns></returns>
        public static bool IsRegexMatch(string source, string pattern, RegexOptions regexOptions)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            var reg = new Regex(pattern, regexOptions,TimeSpan.FromSeconds(5));
            return reg.IsMatch(source);
        }


        public static MatchCollection GetMatches(string source, string pattern, RegexOptions regexOptions)
        {
            if (string.IsNullOrEmpty(source))
                source = "";

            var reg = new Regex(pattern, regexOptions,TimeSpan.FromSeconds(5));
            return reg.Matches(source);
        }

        /// <summary>
        /// 替换正则表达式关键字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ReplaceRegexKeyWord(string source)
        {
            return source.Replace("\\", "\\\\").Replace("(", "((").Replace(")", "))").Replace(".", "\\.");
        }

        
        public static string GetTagContent(string source, string startRegex, string tag, RegexOptions regexOptions)
        {
            var regex = new Regex(startRegex, regexOptions, TimeSpan.FromSeconds(5));
            var closeRegex = new Regex("</"+tag+"\\s*>", regexOptions, TimeSpan.FromSeconds(5));
            var preRegex = new Regex("<" + tag + "[^>]*>", regexOptions, TimeSpan.FromSeconds(5));

            var matches = regex.Matches(source);

            var index = 0;
            var beignTagLen = 0;

            foreach (Match item in matches)
            {
                index= item.Index;
                beignTagLen = item.Length;
                break;
            }

            if (index > 0)
            {
                var useContent = source.Substring(index, source.Length - index);

                MatchCollection closeTags = closeRegex.Matches(useContent);
                MatchCollection preTags = preRegex.Matches(useContent);

                var closeCount = 0;
                foreach (Match item in closeTags)
                {
                    closeCount++;
                    var cIndex = item.Index;
                    var pCnt = 0;
                    foreach (Match pre in preTags)
                    {
                        if (pre.Index < cIndex)
                        {
                            pCnt++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (pCnt == closeCount)
                    {
                        return useContent.Substring(beignTagLen, cIndex - beignTagLen);
                    }
                }
            }

            return string.Empty;
        } 
    }
}

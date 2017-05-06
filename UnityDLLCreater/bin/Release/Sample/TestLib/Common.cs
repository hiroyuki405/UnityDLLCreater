using System;

namespace TestLib
{
    /// <summary>
    /// 文字列操作クラス
    /// </summary>
    public class StringOpes
    {
        /// <summary>
        /// 文字列に現在時刻を挿入する。
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>現在時刻が挿入された文字列</returns>
        static public string ConvertDateStrings(string str)
        {
            string result;
            DateTime tm = DateTime.Now;
            result = tm + ":" + str;
            return result;
        }
    }
}

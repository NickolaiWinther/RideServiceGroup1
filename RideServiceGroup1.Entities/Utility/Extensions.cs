using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup1.Entities.Utility
{
    public static class Extensions
    {
        public static string Translate(this Status status)
        {
            return status == Status.Undefined
                ? "Ikke defineret"
                : status == Status.Working
                    ? "Virker"
                    : status == Status.Broken
                        ? "Ødelagt"
                        : status == Status.BeingRepaired
                            ? "Reparers"
                            : throw new ArgumentException("Not a defined status", "Translate");
        }

        //public static string ShortText(this string text, int maxWords)
        //{
        //    if (text == null || text.Length < maxWords || text.IndexOf(" ", maxWords) == -1)
        //        return text;

        //    return text.Substring(0, text.IndexOf(" ", maxWords));
        //}

        /// <summary>
        /// Shortens text, used for short descriptions
        /// </summary>
        /// <param name="text">Text to shorten</param>
        /// <param name="maxChars">The max amount of chars</param>
        /// <returns></returns>

        public static string ToShortText(this string text, int maxChars)
        {
            return text.Length <= maxChars ? text : text.Substring(0, maxChars) + "...";
        }
    }
}

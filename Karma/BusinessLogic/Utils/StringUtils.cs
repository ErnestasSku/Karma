﻿using System;

namespace Backend.Utils
{
    public static class StringUtils
    {
        /// <summary>
        /// Extends string. Calculates Levenshtein distance between strings.
        /// </summary>
        /// <param name="originalString"></param>
        /// <param name="comprarableString"></param>
        /// <returns>Levenshtein distance between strings.</returns>
        public static int LevenshteinDistance(this string originalString, string comprarableString)
        {
            int n = originalString.Length;
            int m = comprarableString.Length;

            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
                return m;
            if (m == 0)
                return n;

            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (comprarableString[j - 1] == originalString[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(

                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
    }
}

public static class LevenshteinDistance
{
    /// <summary>
    /// Modification of the Levenshtein distance for comparing the target string with all substrings.
    /// Returns the distance between the nearest substring of <paramref name="str"/> and <paramref name="subStr"/>.
    /// </summary>
    /// <param name="str">The string in which to search.</param>
    /// <param name="subStr">Substring to search</param>
    public static int CalculateForAllSubstrings(string str, string subStr)
    {
        var strLength = str.Length;
        var subStrLength = subStr.Length;

        var matrix = new int[subStrLength + 1, strLength + 1];

        if (strLength == 0)
        {
            return subStrLength;
        }

        if (subStrLength == 0)
        {
            return strLength;
        }

        for (var i = 0; i <= subStrLength; i++)
        {
            matrix[i, 0] = i;
        }

        for (var j = 0; j <= strLength; j++)
        {
            matrix[0, j] = 0;
        }

        for (var i = 1; i <= subStrLength; i++)
        {
            for (var j = 1; j <= strLength; j++)
            {
                var cost = subStr[i - 1] == str[j - 1] ? 0 : 1;

                matrix[i, j] = Math.Min(
                    Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                    matrix[i - 1, j - 1] + cost);
            }
        }

        var minDistance = matrix[subStrLength, 0];

        for (var i = 0; i < strLength; ++i)
        {
            minDistance = Math.Min(matrix[subStrLength, i], minDistance);
        }

        return minDistance;
    }

    /// <summary>
    /// Classic Levenshtein distance
    /// </summary>
    public static int Calculate(string str, string pattern)
    {
        var strLength = str.Length;
        var subStrLength = pattern.Length;

        var matrix = new int[subStrLength + 1, strLength + 1];

        if (strLength == 0)
        {
            return subStrLength;
        }

        if (subStrLength == 0)
        {
            return strLength;
        }

        for (var i = 0; i <= subStrLength; i++)
        {
            matrix[i, 0] = i;
        }

        for (var j = 0; j <= strLength; j++)
        {
            matrix[0, j] = j;
        }

        for (var i = 1; i <= subStrLength; i++)
        {
            for (var j = 1; j <= strLength; j++)
            {
                var cost = pattern[i - 1] == str[j - 1] ? 0 : 1;

                matrix[i, j] = Math.Min(
                    Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                    matrix[i - 1, j - 1] + cost);
            }
        }

        return matrix[subStrLength, strLength];
    }
}

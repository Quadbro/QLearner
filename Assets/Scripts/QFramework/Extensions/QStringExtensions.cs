using UnityEngine;
using System.Collections;

public static class QStringExtensions  {

    public static string TrimAndNormalize(this string input) {
        return System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " ");
    }
}

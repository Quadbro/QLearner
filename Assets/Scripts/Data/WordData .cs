﻿using System;
using System.Collections.Generic;

[Serializable]
public class WordData {

    public string word;
    public List<string> translations;

    public WordData(string word) {
        this.word = word;
        translations = new List<string>();
    }

    public WordData(string word, string translation) {
        this.word = word;
        translations = new List<string>{ translation };
    }

    public WordData(string word, List<string> translations) {
        this.word = word;
        this.translations = translations;
    }

    public string GetPrettyTranslations() {
        var res = string.Empty;
        for (var i = 0; i < translations.Count; i++) {
            var translation = translations[i];
            if (i == 0) {
                res += FirstLetterToUpper(translation);
            }
            else {
                res += ", " + translation.ToLower();
            }
        }
        return res;
    }

    public string FirstLetterToUpper(string str) {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }
}

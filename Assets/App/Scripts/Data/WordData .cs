using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class WordData {

    public string word;
    public float progress;
    public List<string> translations;

    public bool IsLearned {
        get { return progress >= 1f; }
    }

    public WordData(string word) {
        this.word = word;
        translations = new List<string>();
        progress = 0f;
    }

    public WordData(string word, string translation) {
        this.word = word;
        translations = new List<string>{ translation };
        progress = 0f;
    }

    public WordData(string word, List<string> translations) {
        this.word = word;
        this.translations = translations;
        progress = 0f;
    }

	public void AddTranslationsRaw(List<string> translationsRaw) {
		this.translations = this.translations.Union (translationsRaw, StringComparer.CurrentCultureIgnoreCase).ToList();
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

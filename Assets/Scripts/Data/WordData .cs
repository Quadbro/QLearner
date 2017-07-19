using System;
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
}

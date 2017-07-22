using System;
using System.Collections.Generic;

[Serializable]
public class DictionaryData {

    public string name;

    public List<WordData> words;

    public DictionaryData(string name) {
        this.name = name;
        words = new List<WordData>();
    }

	public void AddWord(string word, string translation) {
		words.Add(new WordData(word, translation));
	}

	public void AddWord(string word, List<string> translations) {
		words.Add(new WordData(word, translations));
	}
}

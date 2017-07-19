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
}

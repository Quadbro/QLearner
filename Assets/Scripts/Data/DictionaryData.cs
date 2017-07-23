using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DictionaryData {

    public string name;

    [SerializeField]
    private List<WordData> _words;

    // Constructors
    public DictionaryData(string name) {
        this.name = name;
        _words = new List<WordData>();
    }

    public List<WordData> Words {
        get { return _words; }
    }


    // Adders
	public void AddWord(string word, string translation) {
		_words.Add(new WordData(word, translation));
	}

	public void AddWord(string word, List<string> translations) {
		_words.Add(new WordData(word, translations));
	}

    public void AddWord(WordData word) {
        _words.Add(word);
    }

    // Getters
    public List<WordData> GetLearnedWords() {
       return _words.Where(w => w.IsLearned).ToList();
    }

    // Counters
    public int GetLearnedWordsCount() {
        return _words.Sum(w => w.IsLearned ? 1 : 0);
    }

    public int GetWordsCount() {
        return _words.Count;
    }

    // Removers
    public void RemoveWord(WordData word) {
        _words.Remove(word);
    }

    public void RemoveWords(List<WordData> words) {
        foreach (var word in words) {
            _words.Remove(word);
        }
    }

    // Extra logic
    public WordData CheckWord (WordData word) {
		foreach (var w in _words) {
			if (string.Equals(word.word, w.word, StringComparison.OrdinalIgnoreCase)) {
				return w;
			}
		}

		return null;
	}

    public void MergeWord(WordData wordToAdd) {
        var checkWord = CheckWord(wordToAdd);

        if (checkWord != null) {
            checkWord.AddTranslationsRaw(wordToAdd.translations);
        } else {
            AddWord(wordToAdd);
        }
    }

    public void MergeWords(List<WordData> wordsToTransfer) {
        foreach (var wordData in wordsToTransfer) {
            MergeWord(wordData);
        }
    }
}

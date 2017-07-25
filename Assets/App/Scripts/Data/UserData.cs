using System;
using System.Collections.Generic;

[Serializable]
public class UserData {

    public string username;
    public string password;

    public string accountName;

    public List<DictionaryData> dictionaries;

    public SettingsData settings;

    public UserData(string username, string password) {
        this.username = username;
        this.password = password;

        settings = new SettingsData();
    }


    public void CreateDictionary(string name) {
        dictionaries.Add(new DictionaryData(name));
    }

    public void RemoveDictionary(DictionaryData dict) {
        dictionaries.Remove(dict);
    }
}


public static class UserDataExtensions {
    
}

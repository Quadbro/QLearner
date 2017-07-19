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
}


public static class UserDataExtensions {
    
}

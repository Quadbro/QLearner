using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QManager_Localization : QManager<QManager_Localization> {

    private Dictionary<string, string> _localizedText;
    private const string _missingTextString = "Localized text not found";

    public Language Language {
        get {
            return _language;
        }
        set {
            if (value != _language) {
                _language = value;
                LoadLanguage();
                UpdateAllText();
            }
        }
    }

    private Language _language = Language.en;

    public void LoadLanguage() {
        _localizedText = new Dictionary<string, string>();
        var filePath = Path.Combine(Application.streamingAssetsPath + "/Localization/", _language + ".json");

        if (File.Exists(filePath)) {
            var dataAsJson = File.ReadAllText(filePath);
            var loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++) {
                _localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log(string.Format("Data loaded, dictionary [{0}] contains: {1} entries", _language, _localizedText.Count));
        } else {
            Debug.LogError("Cannot find file!");
        }
    }

    public string GetLocalizedValue(string key) {
        if (_localizedText != null && _localizedText.ContainsKey(key)) {
            return _localizedText[key];
        }
        return _missingTextString;
    }

    public void UpdateAllText() {
        foreach (var text in QLocalizedText.instances) {
            if (text) {
                text.UpdateText();
            }
        }
    }


    protected override void OnAwake() {
        LoadLanguage();
    }

    protected override void OnStart() {
        throw new System.NotImplementedException();
    }

    protected override void OnUpdate() {
        throw new System.NotImplementedException();
    }
}
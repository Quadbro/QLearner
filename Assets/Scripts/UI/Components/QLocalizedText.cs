using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class QLocalizedText : Text {
    private string _key;

    public string Key {
        get {
            return _key;
        }
        set {
            _key = value;
            UpdateText();
        }
    }

    public static  List<QLocalizedText> instances = new List<QLocalizedText>();

    protected override void Awake() {
        base.Awake();
        instances.Add(this);
    }

    public void UpdateText() {
        if (!string.IsNullOrEmpty(_key)) {
            text = QManager_Localization.Instance.GetLocalizedValue(_key);
        }
    }
}

public enum Language {
    ru,
    en
}

[System.Serializable]
public class LocalizationData {
    public LocalizationItem[] items;
}

[System.Serializable]
public class LocalizationItem {
    public string key;
    public string value;
}
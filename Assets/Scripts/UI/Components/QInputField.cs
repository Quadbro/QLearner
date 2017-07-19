using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class QInputField : InputField {

    private string _keyPlaceholder;

    public string KeyPlaceholder {
        get {
            return _keyPlaceholder;
        }
        set {
            _keyPlaceholder = value;
            UpdateText();
        }
    }

    public static  List<QInputField> instances = new List<QInputField>();

    protected override void Awake() {
        base.Awake();
        instances.Add(this);
    }

    public void UpdateText() {
        if (_keyPlaceholder != null) {

            ((Text) placeholder).text = QManager_Localization.Instance.GetLocalizedValue(_keyPlaceholder);
        }
    }
}

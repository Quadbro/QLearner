using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class QInputFieldButton : QInputField {

    public QButtonImage Btn {
        get { return _btn; }
    }

    private QButtonImage _btn; 


    protected override void Awake() {
        base.Awake();
        _btn = gameObject.GetRequiredComponentInChildren<QButtonImage>();
    }
}

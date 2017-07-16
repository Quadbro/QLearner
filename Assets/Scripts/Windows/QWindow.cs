﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class QWindowData {
    public string languageHeaderKey;
    public bool hasButton;

    public QWindowData(string languageHeaderKey) {
        this.languageHeaderKey = languageHeaderKey;
    }
}

public abstract class QWindow : QMonoBehaviour {

    public event Action OnActivateEvent;
    public event Action OnDeactivateEvent;

    /*public List<QWindow> Windows {
        get { return _windows; }
    }*/

    public QWindowGroup WindowGroup {
        get { return _windowGroup; }
        set { _windowGroup = value; }
    }

    public QWindowData data;
    public GameObject container;

    //private List<QWindow> _windows = new List<QWindow>();



    protected RectTransform _rectTransform;
    protected QWindowGroup _windowGroup;

    protected override void OnAwake() {
        _rectTransform = gameObject.GetRequiredComponent<RectTransform>();

        _rectTransform.offsetMin = new Vector2(0, 0);
        _rectTransform.offsetMax = new Vector2(0, 0);
    }

    public void Activate() {
        _windowGroup.Activate(this);

        OnActivate();

        if (OnActivateEvent != null) {
            OnActivateEvent();
        }
    }

    public void Deactivate() {
        gameObject.SetActive(false);

        OnDeactivate();

        if (OnDeactivateEvent != null) {
            OnDeactivateEvent();
        }
    }

    protected abstract void OnActivate();
    protected abstract void OnDeactivate();

}
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class QWindow : QMonoBehaviour {

    public static List<QWindow> Instances {
        get { return _instances; }
    }

    private static List<QWindow> _instances = new List<QWindow>();

    public event Action OnActivateEvent;
    public event Action OnDeactivateEvent;

    protected RectTransform _rectTransform;

    public GameObject container;

    protected override void OnAwake() {
        _instances.Add(this);

        _rectTransform = gameObject.GetRequiredComponent<RectTransform>();

        _rectTransform.offsetMin = new Vector2(0, 0);
        _rectTransform.offsetMax = new Vector2(0, 0);
    }

    public void Activate() {
        foreach (var window in _instances) {
            window.Deactivate();
        }

        gameObject.SetActive(true);

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

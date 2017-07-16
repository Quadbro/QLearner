using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public abstract class QExerciseOld : QMonoBehaviour{
    public static List<QExerciseOld> Instances {
        get { return _instances; }
    }


    public RectTransform RectTransform {
        get { return _rectTransform; }
    }

    private static List<QExerciseOld> _instances = new List<QExerciseOld>();

    public event Action OnActivateEvent;
    public event Action OnDeactivateEvent;

    protected RectTransform _rectTransform;

    public GameObject container;
    public string key;

    protected override void OnAwake() {
        _instances.Add(this);

        _rectTransform = gameObject.GetRequiredComponent<RectTransform>();

        _rectTransform.offsetMin = new Vector2(0, 0);
        _rectTransform.offsetMax = new Vector2(0, 0);
    }

    public void Activate() {
        foreach (var ex in _instances) {
            ex.Deactivate();
        }

        QManager_Window.Instance.appHeader.Key = key;
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

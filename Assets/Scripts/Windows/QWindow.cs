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


    protected override void OnAwake() {
        _instances.Add(this);
    }

    public void Activate() {

        OnActivate();

        if (OnActivateEvent != null) {
            OnActivateEvent();
        }
    }

    public void Deactivate() {

        OnDeactivate();

        if (OnDeactivateEvent != null) {
            OnDeactivateEvent();
        }
    }

    protected abstract void OnActivate();
    protected abstract void OnDeactivate();

}

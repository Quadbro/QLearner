using System;
using System.Collections;
using UnityEngine;

public abstract class QMonoBehaviour : MonoBehaviour {

    public event Action OnAwakeEvent;
    public event Action OnStartEvent;
    public event Action OnUpdateEvent;

    protected abstract void OnAwake();
    protected abstract void OnStart();
    protected abstract void OnUpdate();

    public void AwakeCycle() {
        OnAwake();

        if (OnAwakeEvent != null) {
            OnAwakeEvent();
        }
    }

    public void StartCycle() {
        OnStart();

        if (OnStartEvent != null) {
            OnStartEvent();
        }
    }

    public void UpdateCycle() {
        OnUpdate();

        if (OnUpdateEvent != null) {
            OnUpdateEvent();
        }
    }


    public static T Create<T>(GameObject prefab) where T : QMonoBehaviour {
        var go = Instantiate(prefab);
        return go.GetRequiredComponent<T>();
    }

    public static T Create<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : QMonoBehaviour {
        var go = Instantiate(prefab, position, rotation);
        return go.GetRequiredComponent<T>();
    }
}

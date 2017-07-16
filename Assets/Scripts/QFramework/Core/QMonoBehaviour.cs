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

    // ------------------------------------------------------------------------------------------------------------------------
    public static T Create<T>(GameObject prefab, Transform parent = null) where T : MonoBehaviour {
        var go = Instantiate(prefab);
        if (parent != null) {
            go.transform.parent = parent;
        }
        return go.GetRequiredComponent<T>();
    }

    public static T Create<T>(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null) where T : MonoBehaviour {
        var go = Instantiate(prefab, position, rotation);
        if (parent != null) {
            go.transform.parent = parent;
        }
        return go.GetRequiredComponent<T>();
    }
}

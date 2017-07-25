using UnityEngine;
using System.Collections;

public abstract class QManager<T> : QMonoBehaviour where T : QMonoBehaviour {
    protected static T instance;

    public static T Instance {
        get {
            if (instance != null) return instance;
            instance = (T)FindObjectOfType(typeof(T));

            if (instance == null) {
                Debug.LogError("An instance of " + typeof(T) +
                               " is needed in the scene, but there is none.");
            }

            return instance;
        }
    }
}

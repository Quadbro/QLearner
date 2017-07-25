using UnityEngine;

public abstract  class QSingleton<T> : QMonoBehaviour where T : MonoBehaviour {

    protected static T instance;

    public static T Instance {
        get {
            if (instance != null) return instance;
            instance = (T) FindObjectOfType(typeof(T));

            if (instance == null) {
                Debug.LogError("An instance of " + typeof(T) +
                               " is needed in the scene, but there is none.");
            }

            return instance;
        }
    }
}

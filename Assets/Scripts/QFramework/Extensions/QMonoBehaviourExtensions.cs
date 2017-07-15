
using System;
using System.Collections;
using UnityEngine;

public static class QMonoBehaviourExtensions  {

    public static Coroutine Invoke(this QMonoBehaviour monoBehaviour, Action action, float time) {
        return monoBehaviour.StartCoroutine(InvokeImpl(action, time));
    }

 


    public static void ClearAllChildren<T>(this T monoBehaviour) where T : QMonoBehaviour {
        foreach (Transform child in monoBehaviour.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }


    public static T GetRequiredComponent<T>(this GameObject obj) where T : QMonoBehaviour {
        var component = obj.GetComponent<T>();

        if (component == null) {
            Debug.LogError("Expected to find component of type "
               + typeof(T) + " but found none", obj);
        }

        return component;
    }

    public static T GetRequiredComponentInChildren<T>(this GameObject obj) where T : QMonoBehaviour {
        var component = obj.GetComponentInChildren<T>();

        if (component == null) {
            Debug.LogError("Expected to find component of type "
               + typeof(T) + " but found none", obj);
        }

        return component;
    }



    private static IEnumerator InvokeImpl(Action action, float time) {
        yield return new WaitForSeconds(time);

        action();
    }
}

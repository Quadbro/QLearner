using UnityEngine;

public static class TransformExtensions {

    public static Transform FindDeep(this Transform _parent, string _name) {
        var result = _parent.Find(_name);
        if (result != null) {
            return result;
        }
        foreach (Transform child in _parent) {
            result = child.FindDeep(_name);
            if (result != null) {
                return result;
            }
        }
        return null;
    }
}

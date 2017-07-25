using UnityEngine;
using System.Collections;

public class QDialog : MonoBehaviour {

	protected void Hide() {
		Destroy (gameObject);
	}

	protected void Show() {
		ResetOffsets ();
		gameObject.SetActive (true);
	}

	protected void ResetOffsets() {
		var rt = GetComponent<RectTransform> ();
		rt.offsetMin = new Vector2(0, 0);
		rt.offsetMax = new Vector2(0, 0);
	}
}


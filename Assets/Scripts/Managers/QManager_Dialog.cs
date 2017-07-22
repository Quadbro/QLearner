using UnityEngine;
using System.Collections;
using System;

public class QManager_Dialog : QManager<QManager_Dialog> {

	public GameObject prefab_DialogConfirm;
	public GameObject prefab_DialogInfo;
	public GameObject prefab_DialogWordAdd;

	public Transform dialogContainer;

	public void ShowInfo(string keyContent, Action action = null) {
		var dialog = Create<QDialog_Info> (prefab_DialogInfo, dialogContainer);
		dialog.Initialize (keyContent, action);
	}

	public void ShowConfirm (string keyHeader, string keyContent, Action actionYes = null, Action actionNo = null) {
		var dialog = Create<QDialog_Confirm> (prefab_DialogConfirm, dialogContainer);
		dialog.Initialize (keyHeader, keyContent, actionYes, actionNo);
	}

	public void ShowWordAdd (DictionaryData dict, Action actionAdd = null) {
		var dialog = Create<QDialog_WordAdd> (prefab_DialogWordAdd, dialogContainer);
		dialog.Initialize (dict, actionAdd);
	}

	protected override void OnAwake() {
		dialogContainer.ClearAllChildren ();
	}

	protected override void OnStart() {
	}

	protected override void OnUpdate() {
	}
}


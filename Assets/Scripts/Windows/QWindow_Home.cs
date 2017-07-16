﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QWindow_Home : QWindow {

    private List<QButton> _buttons;

    public List<QButton> Buttons {
        get { return _buttons; }
    }

    protected override void OnAwake() {
        base.OnAwake();

        _buttons = new List<QButton>();

        container.ClearAllChildren();
    }

    protected override void OnStart() {
    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
    }

    protected override void OnDeactivate() {
    }

    public void SetButtons(List<QButtonData> buttons) {
        foreach (var b in buttons) {
            AddButton(b);
        }
    }

    public void AddButton(QButtonData b) {
        var btn = Create<QButton>(QManager_Prefab.Instance.prefab_Button_HomeItem, container.transform);
        btn.Initialize(b);
        _buttons.Add(btn);
    }
}

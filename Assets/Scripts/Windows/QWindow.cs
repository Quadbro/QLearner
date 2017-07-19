using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class QWindowData {
    public string languageHeaderKey;

    public QWindowData(string languageHeaderKey) {
        this.languageHeaderKey = languageHeaderKey;
    }
}

public abstract class QWindow : QMonoBehaviour {

    [Header("Necesary Data")]
    public Transform containerContent;
    public Transform containerWindows;

    [Header("List of all child windows")]
    public List<GameObject> subWindows;

    [Header("Tweakable Data")]
    public QWindowData data;

    // Getters
    public QWindowGroup WindowGroup {
        get { return _windowGroup; }
        set { _windowGroup = value; }
    }

    public QWindowData Data {
        get { return data; }
        set { data = value; }
    }

    public QWindow ParentWindow {
        get { return _parentWindow; }
        set { _parentWindow = value; }
    }

    public CanvasGroup CanvasGroup {
        get { return _canvasGroup; }
    }

    // Protected stuff
    protected RectTransform _rectTransform;
    protected QWindowGroup _windowGroup;
    protected QWindow _parentWindow;
    protected QManager_Window _managerWindow;
    protected CanvasGroup _canvasGroup;

    // Events
    public event Action OnActivateEvent;
    public event Action OnDeactivateEvent;

    protected virtual void OnHomeAction() {
        Deactivate();
        _managerWindow.MainWindow.Activate();
    }

    protected virtual void OnUserAction() {
        Deactivate();
        _managerWindow.UserWindow.Activate();
    }

    protected abstract void OnActivate();
    protected abstract void OnDeactivate();

    protected override void OnAwake() {
        _rectTransform = gameObject.GetRequiredComponent<RectTransform>();
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();

        _windowGroup = new QWindowGroup();

        _managerWindow = QManager_Window.Instance;


        if (containerContent) {
            containerContent.ClearAllChildren();
        }

        if (containerWindows) {
            containerWindows.ClearAllChildren();
        }


        ResetOffsets();
    }

    protected override void OnStart() {
 
    }

    public void Activate() {
        if (_parentWindow) {
            _parentWindow.WindowGroup.Activate(this);
            _parentWindow.CanvasGroup.alpha = 0;
        } else {
            _windowGroup.Activate(this);
        }

        CanvasGroup.alpha = 1;

        _managerWindow.HomeButtonAction = OnHomeAction;
        _managerWindow.UserButtonAction = OnUserAction;

        OnActivate();

        if (OnActivateEvent != null) {
            OnActivateEvent();
        }
    }

    public void Deactivate() {
        gameObject.SetActive(false);

        OnDeactivate();

        if (OnDeactivateEvent != null) {
            OnDeactivateEvent();
        }
    }

    public QWindow SpawnWindow(GameObject prefab) {
        var w = Create<QWindow>(prefab, containerWindows.transform);
        w.ParentWindow = this;
        _windowGroup.Link(w);
        return w;
    }

    // ----------------------------------------------- Private

    private void ResetOffsets() {
        _rectTransform.offsetMin = new Vector2(0, 0);
        _rectTransform.offsetMax = new Vector2(0, 0);
    }
}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class QWindowGroup {
    public List<QWindow> windows = new List<QWindow>();

    public void Link(QWindow window) {
        if (!windows.Contains(window)) {
            windows.Add(window);
            window.WindowGroup = this;
        }
    }

    public void Unlink(QWindow window) {
        windows.Remove(window);
        window.WindowGroup = null;
    }

    public void Activate(QWindow w) {
        foreach (var window in windows) {
            if (w != window) {
                window.Deactivate();
            }
        }
       


        if (w.data.isTranslatable) {
            QManager_Window.Instance.SetHeaderLocalizedText(w.Data.languageHeaderKey);
        }
        else {
            QManager_Window.Instance.SetHeaderText(w.Data.languageHeaderKey);
        }
        w.gameObject.SetActive(true);
    }
}

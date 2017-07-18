using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum QColorPalette {
    Default,
    Pink,
    Blue,
    Green
}

[System.Serializable]
public class QColorScheme {
    public QColorPalette paletteRef;

    public Color normal = Color.white;
    public Color highlight = Color.grey;
    public Color pressed = Color.red;
    public Color disabled = Color.gray;
}

public class QManager_Theme : QManager<QManager_Theme> {

    public QColorPalette colorPalette;

    public List<QColorScheme> colorSchemes = new List<QColorScheme>();


    public QColorScheme CurrentScheme {
        get { return GetScheme(colorPalette); }
    }

    public QColorScheme GetScheme(QColorPalette palette) {
        foreach (var scheme in colorSchemes) {
            if (scheme.paletteRef == palette) {
                return scheme;
            }
        }

        return new QColorScheme();
    }


    protected override void OnAwake() {
    }

    protected override void OnStart() {
    }

    protected override void OnUpdate() {
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum QColorPalette {
    Default_Light = 0,
    Default_Dark = 1,

    Pink_Light = 2,
    Pink_Dark = 3,

    Blue_Light = 4,
    Blue_Dark = 5,

    Green_Light = 6,
    Green_Dark = 7,
}

[System.Serializable]
public class QColorScheme {
    public QColorPalette paletteRef;

    public Color normal = Color.white;
    public Color highlight = Color.grey;
    public Color pressed = Color.red;
    public Color disabled = Color.gray;

    public Color background = Color.black;
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

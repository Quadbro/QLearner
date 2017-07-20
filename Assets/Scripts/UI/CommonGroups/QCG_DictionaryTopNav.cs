using UnityEngine;
using System.Collections;

public class QCG_DictionaryTopNav : MonoBehaviour {

    public GameObject ref_Addbutton;
    public GameObject ref_InputField;


    public QInputField InputField {
        get { return _inputField; }
    }

    public QButtonImage AddButton {
        get { return _addButton; }
    }

    private QInputField _inputField;
    private QButtonImage _addButton;

    public void Initialize() {
        _inputField = ref_InputField.GetRequiredComponent<QInputField>();
        _addButton = ref_Addbutton.GetRequiredComponent<QButtonImage>();
    }
}

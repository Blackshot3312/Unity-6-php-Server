using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class TabB : MonoBehaviour
{
    public TMP_InputField nextField;
    TMP_InputField myField;

    private void Start()
    {
        myField = GetComponent<TMP_InputField>();

        if (myField == null)
        {
            Destroy(this);
            return;
        }
    }

    private void Update()
    {
        if (myField.isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            nextField.ActivateInputField();
        }
    }
}


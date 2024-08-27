using UnityEngine;
using UnityEngine.UI;

public class button_set : MonoBehaviour
{
    public GameObject targetObject; // �Ώۂ�GameObject
    private bool isActive = false; // ���݂̃A�N�e�B�u��Ԃ�ǐ�
    public Button button;

    void Start()
    {

        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(SwichObj);
    }

    void SwichObj()
    {
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
        targetObject.SetActive(isActive);
    }
}
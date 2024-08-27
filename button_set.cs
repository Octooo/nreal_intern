using UnityEngine;
using UnityEngine.UI;

public class button_set : MonoBehaviour
{
    public GameObject targetObject; // 対象のGameObject
    private bool isActive = false; // 現在のアクティブ状態を追跡
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
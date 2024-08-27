using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class task_clicked : MonoBehaviour
{
    public Button button;
    public GameObject detail_object;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            flag = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            Debug.Log("Pressed");
            detail_object.SetActive(true);
            flag = false;
            Invoke("DelayMethod", 3.5f);
        }
    }

    void DelayMethod()
    {
        detail_object.SetActive(false);
    }
}

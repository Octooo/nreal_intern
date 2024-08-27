using UnityEngine;
using UnityEngine.UI;

public class roulette_num : MonoBehaviour
{
    public GameObject roulette_button;
    public int roulette_chanum;
    public Button button;
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
            roulette_button.GetComponent<roulette>().max_num += roulette_chanum;
            flag = false;
        }

    }
}

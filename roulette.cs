using UnityEngine;
using TMPro;
using System.Collections;
using System.IO;

public class roulette : MonoBehaviour
{
    public int max_num = 4;
    public TextMeshProUGUI targetText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetText.text = "1 - "+ max_num.ToString();
    }
}

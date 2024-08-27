using System;
using TMPro;
using UnityEngine;

public class dis_time : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    private DateTime TodayNow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TodayNow = DateTime.Now;
        this.targetText.text = TodayNow.Hour.ToString("D2") + ":" + TodayNow.Minute.ToString("D2") + ":" + TodayNow.Second.ToString("D2");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dis_date : MonoBehaviour
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
        this.targetText.text = TodayNow.Year.ToString() + "/" + TodayNow.Month.ToString() + "/" + TodayNow.Day.ToString();
    }
}

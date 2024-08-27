using UnityEngine;
using System.IO;
using System;
using Unity.VisualScripting;
using TMPro;
using System.Threading.Tasks;
using System.Text;

public class dis_calender : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    private bool flag = false;
    public TextAsset textAsset;
    public string data;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("calender");
        data = textAsset.text;
    }

    // Update is called once per frame
    void Update()
    {
        string[] arr = data.Split("\n");
        for (int i = 0; i < arr.Length; i++)
        {
            string[] a = arr[i].Split(" ");
            string[] b = a[0].Split("-");
            TimeSpan s_time = new TimeSpan(int.Parse(b[0].Split(":")[0]), int.Parse(b[0].Split(":")[1]),0);
            TimeSpan e_time = new TimeSpan(int.Parse(b[1].Split(":")[0]), int.Parse(b[1].Split(":")[1]), 0);
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            if (currentTime >= s_time && currentTime <= e_time)
            {
                targetText.text = arr[i];
                flag = true;
                break;
            }
        }
        if(flag == false)
        {
            targetText.text = "No schedule";
        }
    }
}

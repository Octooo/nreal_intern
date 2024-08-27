using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class roulette_clicked : MonoBehaviour
{
    public bool meal_start = false;
    public GameObject meal_button_object;
    private Button meal_button;
    public TextAsset textAsset;
    public string data;

    public bool start = false;
    public GameObject roulette_size;
    private int max;
    public GameObject button_object;
    private Button button;

    public bool janken_start = false;
    public GameObject janken_button_object;
    private Button janken_button;

    public TextMeshProUGUI targetText;
    private int count;
    string[] janken = new string[] { "グー", "チョキ", "パー" };
    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("meal");
        data = textAsset.text;
        button = button_object.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            start = true;
        });
        janken_button = janken_button_object.GetComponent<Button>();
        janken_button.onClick.AddListener(() =>
        {
            janken_start = true;
        });
        meal_button = meal_button_object.GetComponent<Button>();
        meal_button.onClick.AddListener(() =>
        {
            meal_start = true;
        });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            max = roulette_size.GetComponent<roulette>().max_num;
            targetText.text = Random.Range(1, max+1).ToString();
            count++;
        }
        if (janken_start)
        {
            targetText.text = janken[Random.Range(0, janken.Length)];
            count++;
        }
        if (meal_start) 
        {
            string[] arr = data.Split("\n");
            targetText.text = arr[Random.Range(0, arr.Length)];
            count++;
        }
        if (count > 30)
        {
            meal_start = false;
            start = false;
            janken_start = false;
            count = 0;
        }
    }
}

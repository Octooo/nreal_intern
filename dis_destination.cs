using UnityEngine;
using System.IO;
using TMPro;


public class dis_destination : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public TextAsset textAsset;
    public float lat;
    public float lon;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("destination");
    }

    // Update is called once per frame
    void Update()
    {
        string data = textAsset.text;
        string[] arr = data.Split("\n");
        lat = float.Parse(arr[0]);
        lon = float.Parse(arr[1]);
        targetText.text = "目的地\n緯度 : " + arr[0] + "\n経度 : " + arr[1];
    }
}

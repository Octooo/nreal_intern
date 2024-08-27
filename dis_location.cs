using UnityEngine;
using TMPro;

public class dis_location : MonoBehaviour
{
    public GameObject GameObject;
    public TextMeshProUGUI targetText;
    public float latitude;
    public float longitude;
    public float attitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        latitude = GameObject.GetComponent<get_location>().latitude;
        longitude = GameObject.GetComponent<get_location>().longitude;
        attitude = GameObject.GetComponent<get_location>().altitude;
        targetText.text = "���ݒn\n�o�x : "  + latitude.ToString() + "\n�ܓx : " + longitude.ToString();
    }
}

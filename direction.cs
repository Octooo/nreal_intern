using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour
{
    public RectTransform compassNeedle;
    public GameObject destination;
    public GameObject current;
    public float lat1;
    public float lat2;
    public float lon1;
    public float lon2;
    public float heading;
    void Start()
    {
        // �R���p�X�̎g�p���J�n
        Input.compass.enabled = true;
    }

    void Update()
    {
        lat2 = destination.GetComponent<dis_destination>().lat;
        lon2 = destination.GetComponent<dis_destination>().lon;
        lat1 = current.GetComponent<get_location>().latitude;
        lon1 = current.GetComponent<get_location>().longitude;
        // �R���p�X���L�����ǂ������m�F
        if (Input.compass.enabled)
        {
            // ���p���擾
            float heading = Input.compass.trueHeading;
            Debug.Log("���p: " + heading);
        }
        else
        {
            Debug.Log("�R���p�X���L���ɂȂ��Ă��܂���B");
        }
        float bearing = CalculateBearing(lat1, lon1, lat2, lon2);
        compassNeedle.localRotation = Quaternion.Euler(heading - bearing-90, 90, 90);
    }

    float CalculateBearing(float lat1, float lon1, float lat2, float lon2)
    {
        lat1 = Mathf.Deg2Rad * lat1;
        lon1 = Mathf.Deg2Rad * lon1;
        lat2 = Mathf.Deg2Rad * lat2;
        lon2 = Mathf.Deg2Rad * lon2;

        float y = Mathf.Sin(lon2 - lon1) * Mathf.Cos(lat2);
        float x = Mathf.Cos(lat1) * Mathf.Sin(lat2) - Mathf.Sin(lat1) * Mathf.Cos(lat2) * Mathf.Cos(lon2 - lon1);
        float bearing = Mathf.Atan2(y, x);
        return (Mathf.Rad2Deg * bearing + 360) % 360;
    }
}

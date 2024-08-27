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
        // コンパスの使用を開始
        Input.compass.enabled = true;
    }

    void Update()
    {
        lat2 = destination.GetComponent<dis_destination>().lat;
        lon2 = destination.GetComponent<dis_destination>().lon;
        lat1 = current.GetComponent<get_location>().latitude;
        lon1 = current.GetComponent<get_location>().longitude;
        // コンパスが有効かどうかを確認
        if (Input.compass.enabled)
        {
            // 方角を取得
            float heading = Input.compass.trueHeading;
            Debug.Log("方角: " + heading);
        }
        else
        {
            Debug.Log("コンパスが有効になっていません。");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate1 : MonoBehaviour
{
    // 回転速度を指定します
    public float rotationSpeed = 50f;

    // 回転軸が変化するまでの時間を指定します
    public float changeInterval = 2f;

    // ランダムな回転軸を保持する変数
    private Vector3 randomAxis;

    // 次の回転軸が変更される時間
    private float nextChangeTime;

    void Start()
    {
        // 初期のランダムな回転軸を生成します
        randomAxis = Random.onUnitSphere;
        // 最初の軸変更時間を設定します
        nextChangeTime = Time.time + changeInterval;
    }

    void Update()
    {
        // ランダムな軸を中心に回転させます
        transform.Rotate(randomAxis * rotationSpeed * Time.deltaTime);

        // 時間が経過したら新しい回転軸を生成します
        if (Time.time >= nextChangeTime)
        {
            randomAxis = Random.onUnitSphere;
            nextChangeTime = Time.time + changeInterval;
        }
    }
}

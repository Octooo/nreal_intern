using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate1 : MonoBehaviour
{
    // ‰ñ“]‘¬“x‚ðŽw’è‚µ‚Ü‚·
    public float rotationSpeed = 50f;

    // ‰ñ“]Ž²‚ª•Ï‰»‚·‚é‚Ü‚Å‚ÌŽžŠÔ‚ðŽw’è‚µ‚Ü‚·
    public float changeInterval = 2f;

    // ƒ‰ƒ“ƒ_ƒ€‚È‰ñ“]Ž²‚ð•ÛŽ‚·‚é•Ï”
    private Vector3 randomAxis;

    // ŽŸ‚Ì‰ñ“]Ž²‚ª•ÏX‚³‚ê‚éŽžŠÔ
    private float nextChangeTime;

    void Start()
    {
        // ‰Šú‚Ìƒ‰ƒ“ƒ_ƒ€‚È‰ñ“]Ž²‚ð¶¬‚µ‚Ü‚·
        randomAxis = Random.onUnitSphere;
        // Å‰‚ÌŽ²•ÏXŽžŠÔ‚ðÝ’è‚µ‚Ü‚·
        nextChangeTime = Time.time + changeInterval;
    }

    void Update()
    {
        // ƒ‰ƒ“ƒ_ƒ€‚ÈŽ²‚ð’†S‚É‰ñ“]‚³‚¹‚Ü‚·
        transform.Rotate(randomAxis * rotationSpeed * Time.deltaTime);

        // ŽžŠÔ‚ªŒo‰ß‚µ‚½‚çV‚µ‚¢‰ñ“]Ž²‚ð¶¬‚µ‚Ü‚·
        if (Time.time >= nextChangeTime)
        {
            randomAxis = Random.onUnitSphere;
            nextChangeTime = Time.time + changeInterval;
        }
    }
}

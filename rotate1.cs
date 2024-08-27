using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate1 : MonoBehaviour
{
    // ��]���x���w�肵�܂�
    public float rotationSpeed = 50f;

    // ��]�����ω�����܂ł̎��Ԃ��w�肵�܂�
    public float changeInterval = 2f;

    // �����_���ȉ�]����ێ�����ϐ�
    private Vector3 randomAxis;

    // ���̉�]�����ύX����鎞��
    private float nextChangeTime;

    void Start()
    {
        // �����̃����_���ȉ�]���𐶐����܂�
        randomAxis = Random.onUnitSphere;
        // �ŏ��̎��ύX���Ԃ�ݒ肵�܂�
        nextChangeTime = Time.time + changeInterval;
    }

    void Update()
    {
        // �����_���Ȏ��𒆐S�ɉ�]�����܂�
        transform.Rotate(randomAxis * rotationSpeed * Time.deltaTime);

        // ���Ԃ��o�߂�����V������]���𐶐����܂�
        if (Time.time >= nextChangeTime)
        {
            randomAxis = Random.onUnitSphere;
            nextChangeTime = Time.time + changeInterval;
        }
    }
}

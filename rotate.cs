using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rotate : MonoBehaviour
{
    // ��]�p�x
    [SerializeField] private float angle = 90f;
    // ��]���� Vector3.left��-x����]
    [SerializeField] private Vector3 axis = Vector3.left;
    // ��]���x
    [SerializeField] private float speed = 3f;
    private Quaternion targetRotation;
    private void Start()
    {
        targetRotation = this.transform.rotation;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // �p�x��ݒ肷��
        targetRotation = Quaternion.AngleAxis(angle, axis) * transform.rotation;
    }
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }
}

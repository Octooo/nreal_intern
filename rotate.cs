using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rotate : MonoBehaviour
{
    // ‰ñ“]Šp“x
    [SerializeField] private float angle = 90f;
    // ‰ñ“]•ûŒü Vector3.left‚Í-x²‰ñ“]
    [SerializeField] private Vector3 axis = Vector3.left;
    // ‰ñ“]‘¬“x
    [SerializeField] private float speed = 3f;
    private Quaternion targetRotation;
    private void Start()
    {
        targetRotation = this.transform.rotation;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // Šp“x‚ğİ’è‚·‚é
        targetRotation = Quaternion.AngleAxis(angle, axis) * transform.rotation;
    }
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }
}

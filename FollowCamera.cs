using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _distance = 1f;

    private void Update()
    {
        // カメラの前方ベクトルをそのまま使用
        Vector3 direction = _cameraTransform.forward.normalized;

        // targetPositionのY軸もカメラに追従させる
        Vector3 targetPosition = _cameraTransform.position + (direction * _distance);

        // targetRotationはカメラの方向に向ける
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        float t = Time.deltaTime * _speed;
        Vector3 position = Vector3.Lerp(transform.position, targetPosition, t);
        Quaternion rotation = Quaternion.Lerp(transform.rotation, targetRotation, t);
        transform.SetPositionAndRotation(position, rotation);
    }
}
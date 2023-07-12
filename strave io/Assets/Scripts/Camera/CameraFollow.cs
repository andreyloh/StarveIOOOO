using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _smoothTime = .25f;

    private Vector3 _offset = new Vector3(0f, 0f, -10f);
    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        Vector3 _targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity,
            _smoothTime);
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float _moveSpeed;

    private readonly float _offset = 90f;

    [SerializeField] private Camera _camera;
    private Rigidbody2D _rigidBody;

    private Vector2 _movement;
    private Vector2 _mousePosition;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _moveSpeed * Time.fixedDeltaTime * _movement);

        Vector2 _lookingDirection = _mousePosition - _rigidBody.position;
        float _angle = Mathf.Atan2(_lookingDirection.y, _lookingDirection.x) * Mathf.Rad2Deg - _offset;
        _rigidBody.rotation = _angle;
    }
}

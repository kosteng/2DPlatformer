using UnityEngine;

public class PlayerCharacterView : MonoBehaviour
{
    private bool _isJumped;
    private bool _isDoubleJumped;
    private Vector2 _direction;
    [SerializeField] private LayerMask _isGround;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public float jumpForce;
    public float moveSpeed;
    public GameObject ShootPlace;
    public GameObject BulletPrefab;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.IsTouchingLayers(_isGround))
        {
            _isJumped = false;
            _isDoubleJumped = false;
        }
    }

    public void Move()
    {
        _direction.x = Input.GetAxis("Horizontal") * moveSpeed;
        if (_direction.x > 0)
        {
            MoveToRight();
        }

        if (_direction.x < 0)
        {
            MoveToLeft();
        }
    }

    public void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            if (!_isJumped)
            {
                JumpFirstOrDouble();
            }
            else if (_isJumped && !_isDoubleJumped)
            {
                JumpFirstOrDouble();
            }
        }
    }

    private void JumpFirstOrDouble()
    {
        if (_isJumped && !_isDoubleJumped)
        {
            _isDoubleJumped = true;
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            _isJumped = true;
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void MoveToRight()
    {
        transform.Translate(Time.deltaTime * _direction.x * moveSpeed, 0, 0);
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    private void MoveToLeft()
    {
        transform.Translate(Time.deltaTime * -_direction.x * moveSpeed, 0, 0);
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Instantiate(BulletPrefab, ShootPlace.transform.position, Quaternion.identity);
    }
}

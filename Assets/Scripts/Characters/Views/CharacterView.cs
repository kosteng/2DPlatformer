using Characters;
using UnityEngine;
using UnityEngine.AI;


namespace Units.Views
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private LayerMask _isGround;
        public bool IsJumped;
        public bool IsDoubleJumped;

        public LayerMask IsGround => _isGround;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Animator Animator => _animator;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.otherCollider.IsTouchingLayers(_isGround))
            {
                IsJumped = false;
                IsDoubleJumped = false;
            }
        }
    }
}
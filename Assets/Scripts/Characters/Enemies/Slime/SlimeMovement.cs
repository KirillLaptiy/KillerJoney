using UnityEngine;

namespace Characters.Enemies.Slime
{
    public class SlimeMovement : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private float speed;
        
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            _rb.linearVelocity = direction * speed;
        }
    }
}

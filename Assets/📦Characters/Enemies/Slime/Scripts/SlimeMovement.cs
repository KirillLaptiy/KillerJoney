using __Characters.Players._Scripts;
using Core;
using UnityEngine;

namespace __Characters.Enemies.Slime.Scripts
{
    public class SlimeMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        
        private GameObject _target;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _target = FindFirstObjectByType<Player>().gameObject;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            TickMovement();
        }

        private void TickMovement()
        {
            Vector2 direction = (_target.transform.position - transform.position).normalized;
            _rigidbody.linearVelocity = direction * TileUnit.ToWorld(speed);
        }
    }
}
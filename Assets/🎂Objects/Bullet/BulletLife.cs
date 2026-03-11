using System.Collections.Generic;
using __Characters.Interfaces;
using Core;
using UnityEngine;

namespace __Objects.Bullet
{
    public class BulletLife : MonoBehaviour
    {
        [SerializeField] private float lifetime = 1.5f;
        [SerializeField] private int maxTargets = 1;
        [SerializeField] private int damage = 1;

        private List<GameObject> _hittedTargets;

        private void Start()
        {
            _hittedTargets = new List<GameObject>();
            Destroy(gameObject, lifetime);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.Enemy)) return;
            if (_hittedTargets.Contains(other.gameObject)) return;

            _hittedTargets.Add(other.gameObject);

            if (_hittedTargets.Count <= maxTargets) 
                Hit(other.gameObject);
        
            if (_hittedTargets.Count == maxTargets)
                EndBulletLife();
        }

        private void EndBulletLife()
        {
            Destroy(gameObject);
        }

        private void Hit(GameObject obj)
        {
            obj.GetComponent<ICharacterHealth>().TakeDamage(damage);
        }
    }
}
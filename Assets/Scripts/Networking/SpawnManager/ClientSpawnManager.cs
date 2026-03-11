using __Characters.Players._Scripts;
using UnityEngine;

public class ClientSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private bool spawnSlimes;
    
    [SerializeField] private float spawnRate = 1f;
    private float _nextFireTime;
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!FindFirstObjectByType<PlayerMovement>()) return;
        if (Time.time < _nextFireTime) return;
        if (!spawnSlimes) return;
        
        _nextFireTime = Time.time + spawnRate;
        
        Instantiate(slimePrefab);
    }
}

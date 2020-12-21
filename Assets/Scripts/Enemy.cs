using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _hitPrefab;
    [SerializeField] GameObject _ExplosionPrefab;
    [SerializeField] int _health = 5;

    int _currentHealth;
    private void OnEnable()
    {
        _currentHealth = _health;
    }
    void Update()
    {
        var player = FindObjectOfType<Player>();
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position); //Enemy runs towards player
    }

    public void TakeDamage(Vector3 impactPoint)
    {
        _currentHealth--;
        Instantiate(_hitPrefab, impactPoint, transform.rotation);//play the hit prefab at the position of the enemy
        if (_currentHealth <= 0)
        {
            Instantiate(_ExplosionPrefab, impactPoint, transform.rotation); //plays the explosion prefab at enemy pos
            gameObject.SetActive(false);
        }

        
    }
}


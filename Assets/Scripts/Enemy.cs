using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _hitPrefab;
    [SerializeField] GameObject _ExplosionPrefab;
    [SerializeField] int _health = 5;
    [SerializeField] int _pointValue = 100;

    private AudioSource _audioSource;
    int _currentHealth;
    

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource?.Play();
        Instantiate(_hitPrefab, impactPoint, transform.rotation);//play the hit prefab at the position of the enemy

        if (_currentHealth <= 0)
        {
            
            Instantiate(_ExplosionPrefab, impactPoint, transform.rotation); //plays the explosion prefab at enemy pos
            gameObject.SetActive(false);

            //FindObjectOfType<ScoreSystem>().Add(); //In a more detailsed game this won't be as efficient. A singleton method will be better. 
            ScoreSystem.Add(_pointValue);
        }        
    }
    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponents<Player>();
        if (player != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}


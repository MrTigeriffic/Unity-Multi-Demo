using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _direction;
    
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizonal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizonal, 0f, vertical);
        transform.Translate (movement * Time.deltaTime * _speed, _direction);

        _animator.SetBool("Run", movement.magnitude > 0);
    }

}

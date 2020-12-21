using System;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _bulletSpeed = 5f;
    [SerializeField] float _delay = 0.2f;

    Vector3 _direction;
    float _nextShootTime;
    Queue<Bullet> _pool = new Queue<Bullet>();

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var raycastHit, Mathf.Infinity))
        {
            _direction = raycastHit.point - _shootPoint.position;
            _direction.Normalize();
            _direction = new Vector3(_direction.x, 0, _direction.z); //makes sure the bullets spawned are at the same rate. Mouse position won't effect the direction
            transform.forward = _direction;
        }
        
        if (CanShoot())
            Shoot();
    }

    void Shoot()
    {
        _nextShootTime = Time.time + _delay; //limits the time between each bullet. Rather than a bullet created every frame
        var bullet = GetBullet();
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;
        bullet.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed; //rigid body is the same as the direction and bullet speed
    }

    Bullet GetBullet()
    {
        if (_pool.Count > 0)
        {
            var bullet = _pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.SetGun(this);
            return bullet;
        }    
        
    }

    bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }

    public void AddToPool(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }
}

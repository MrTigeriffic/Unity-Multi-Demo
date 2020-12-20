using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _direction;

    void Update()
    {
        float horizonal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizonal, 0f, vertical);
        transform.Translate (movement * Time.deltaTime * _speed, _direction);
    }

}

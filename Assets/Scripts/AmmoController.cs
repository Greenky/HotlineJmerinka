using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public int bulletsNum;
    public GameObject bullet;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
//        if (_rb.velocity.magnitude < 0.5f)
//        {
//            _rb.velocity = Vector2.zero;
//            _rb.angularVelocity = 0;
//            GetComponent<BoxCollider2D>().isTrigger = true;
//        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _delta;

    private void Start()
    {
        _delta = transform.position - _player.position;
    }

    void Update()
    {
        transform.position = _delta + _player.position;
    }
}

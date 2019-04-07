using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomApearence : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _head;
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private Sprite[] _bodys;
    [SerializeField] private Sprite[] _heads;
    
    
    void Start()
    {
        _head.sprite = _heads[Random.Range(0, _heads.Length)];
        _body.sprite = _bodys[Random.Range(0, _bodys.Length)];
    }
}

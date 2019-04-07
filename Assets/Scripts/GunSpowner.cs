using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpowner : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;

    private void Start()
    {
        GameObject w = Instantiate(weapons[Random.Range(0, weapons.Length)], transform);
        w.transform.localPosition = Vector2.zero;
        w.transform.parent = null;
    }
}

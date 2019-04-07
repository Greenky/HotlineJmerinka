using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _weaponInHand;
    [SerializeField] private Sprite[] _weapons;
    [SerializeField] private GameObject[] _bullets;
    private GameObject _bullet;
    
    void Start()
    {
        int rand = Random.Range(0, _weapons.Length);
        _weaponInHand.sprite = _weapons[rand];
        _bullet = _bullets[rand];
    }

    public void Shoot(Vector2 EnemyPos)
    {
        GameObject bull = Instantiate(_bullet, transform);
        bull.layer = 11;
        bull.transform.localPosition = Vector2.zero;
        bull.transform.parent = null;
        bull.transform.position += (new Vector3(EnemyPos.x, EnemyPos.y, 0) - bull.transform.position).normalized * 0.5f;
        bull.transform.eulerAngles = 
            new Vector3(0, 0, (Mathf.Atan2(EnemyPos.y - transform.position.y, EnemyPos.x - transform.position.x) 
                               * Mathf.Rad2Deg));
        if (_weaponInHand.sprite.name != "5" && _weaponInHand.sprite.name != "12")
        {
            Vector2 vel = new Vector3(EnemyPos.x, EnemyPos.y, 0) - transform.position;
            bull.GetComponent<Rigidbody2D>().velocity = vel.normalized * 30;
        }
    }
}

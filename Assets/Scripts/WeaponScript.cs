using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private GameObject _bullet;
    [SerializeField] private int _bulletsNum;
    private GameObject _weaponUnderFeet;
    [SerializeField] private SpriteRenderer _weaponInHand;
    [SerializeField] private Sprite[] _weapons;
    [SerializeField] private GameObject[] _bigWeapons;
    
    void Start()
    {
        _weaponInHand.sprite = null;
        _weaponUnderFeet = null;
        _bullet = null;
        _bulletsNum = 0;
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E) && _weaponUnderFeet != null && _weaponInHand.sprite == null)
        {
            GetWeaponInHand();
        }

        if (Input.GetMouseButtonDown(0) && _bulletsNum > 0)
        {
            GameObject bull = Instantiate(_bullet, transform);
            bull.transform.localPosition = Vector2.zero;
            bull.transform.parent = null;
            bull.transform.eulerAngles = 
            new Vector3(0, 0, (Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) 
             * Mathf.Rad2Deg));
            Vector2 vel = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
            bull.GetComponent<Rigidbody2D>().velocity = vel.normalized * 30;
            _bulletsNum--;
        }

        if (Input.GetMouseButtonDown(1) && _weaponInHand.sprite != null)
        {
            GameObject weap = null;
            foreach (var bigW in _bigWeapons)
            {
                if (bigW.name.Split('-')[0] == _weaponInHand.sprite.name)
                {
                    weap = Instantiate(bigW, transform);
                    weap.transform.localPosition = Vector2.zero;
                    weap.transform.parent = null;
                    Vector2 vel = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
                    weap.GetComponent<AmmoController>().bulletsNum = _bulletsNum;
                    weap.GetComponent<Rigidbody2D>().velocity = vel.normalized * 10;
                    weap.GetComponent<Rigidbody2D>().angularVelocity = 1000;
                    weap.GetComponent<BoxCollider2D>().isTrigger = false;
                    _weaponInHand.sprite = null;
                    _bullet = null;
                    _bulletsNum = 0;
                    break ;
                }
            }
        }    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
            _weaponUnderFeet = other.gameObject;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Weapon")
            _weaponUnderFeet = null;
    }

    public void GetWeaponInHand()
    {
        string[] str = _weaponUnderFeet.name.Split('-');
        _bullet = _weaponUnderFeet.GetComponent<AmmoController>().bullet;
        _bulletsNum = _weaponUnderFeet.GetComponent<AmmoController>().bulletsNum;
        Destroy(_weaponUnderFeet);
        foreach (var weapon in _weapons)
        {
            if (weapon.name == str[0])
            {
                _weaponInHand.sprite = weapon;
                break;
            }
        }
    }
}

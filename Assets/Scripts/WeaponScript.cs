using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

using System;


public class WeaponScript : MonoBehaviour
{
    private GameObject _bullet;
    [SerializeField] public int _bulletsNum;
    [SerializeField] public int _maxBullets;
    public GameObject _weaponUnderFeet;
    [SerializeField] public SpriteRenderer _weaponInHand;
    [SerializeField] private Sprite[] _weapons;
    [SerializeField] private GameObject[] _bigWeapons;

	[System.Serializable]
	public  class  V2Event: UnityEvent<Vector2>{ }
	public V2Event ShootEvent;
    public AudioClip[] _sounds;
    public AudioSource _shoot;
    
    void Start()

    {
        _maxBullets = 0;
        _weaponInHand.sprite = null;
        _weaponUnderFeet = null;
        _bullet = null;
        _bulletsNum = 0;
		if (ShootEvent == null)
			ShootEvent = new V2Event();
    }

    private void Update()
    {
        if (GetComponent<MovementScript>().isAlive == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.E) && _weaponUnderFeet != null && _weaponInHand.sprite == null)
            {
                GetWeaponInHand();
            }
    
            if (Input.GetMouseButtonDown(0) && _bulletsNum != 0 && _weaponInHand.sprite != null)
            {
                GameObject bull = Instantiate(_bullet, transform);
                bull.transform.localPosition = Vector2.zero;
                bull.transform.parent = null;
                bull.transform.position += (new Vector3(mousePos.x, mousePos.y, 0) - bull.transform.position).normalized * 0.5f;
                bull.transform.eulerAngles = 
                new Vector3(0, 0, (Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) 
                 * Mathf.Rad2Deg));
                if (_weaponInHand.sprite.name != "5" && _weaponInHand.sprite.name != "12")
                {
                    Vector2 vel = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
                    bull.GetComponent<Rigidbody2D>().velocity = vel.normalized * 30;
                    _bulletsNum--;
                }
                _shoot.clip = _sounds[Int32.Parse(_weaponInHand.sprite.name) - 1];
                _shoot.Play();
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
        _maxBullets = _bulletsNum;
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

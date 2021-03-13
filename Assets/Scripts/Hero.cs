using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, IDamageable
{

    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] protected float attackSpeed = 0.1f;

    protected float cooldown;

    [SerializeField] protected GameObject arrowPrefab;


    private void Start()
    {
        BaseUnit.OnGetDamage += GetDamage;
        Projectile.OnGetDamage += GetDamage;
    }

    void GetDamage(float damage) 
    {
        Debug.Log("GetDamage");
        health -= damage;
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0)) 
        {
            if (cooldown <= 0)
            {
                var _arrow = Instantiate(arrowPrefab) as GameObject;
                var mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                _arrow.transform.position = transform.position;
                var angle = Vector2.Angle(Vector2.right, mousePosition - _arrow.transform.position);
                _arrow.transform.eulerAngles = new Vector3(0f, 0f, _arrow.transform.position.y < mousePosition.y ? angle : -angle);
                _arrow.GetComponent<Projectile>().SetDamage(damage,"Enemy", mousePosition);
                cooldown = attackSpeed;
            }
        }
    }

    void IDamageable.GetDamage(float damage)
    {
        Debug.Log("Еблыыыыыысь");
        health -= damage;
    }
}

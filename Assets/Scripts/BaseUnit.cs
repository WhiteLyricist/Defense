using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour, IDamageable
{

    public static Action<float> OnGetDamage = delegate { };

    public static Action OnDie = delegate { };

    [SerializeField] protected GameObject arrowPrefab;

    [SerializeField] protected GameObject bangPrefab;

    [SerializeField] protected HPBar _hpBar;

    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected float health;
    [SerializeField] protected float range;
    [SerializeField] protected float attackSpeed=1f;

    protected float maxHealth;
    protected float cooldown;


    public virtual void SetParameters() 
    {
        damage = UnitParameters.EnemyDamage;
        maxHealth = UnitParameters.EnemyHealth;
        health = maxHealth;
    }

    public virtual void Move() 
    {
        cooldown -= Time.deltaTime;

        var distance = Vector3.Distance(transform.position,Vector2.zero);

        var angle = Vector2.Angle(Vector2.right, Vector3.zero - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < 0f ? angle : -angle);

        if (distance >= range)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, Vector2.zero);
        }
        else
        {
            if (cooldown <= 0)
            {
                Attack();
                cooldown = attackSpeed;
            }
        }
    }

    public virtual void Attack() 
    {
        
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SetParameters();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        _hpBar.UpdateHPBar(health, maxHealth);
        if (health <= 0) 
        {
            var _bang = Instantiate(bangPrefab) as GameObject;
            _bang.transform.position = transform.position;
            Destroy(gameObject);
            OnDie();  
        }
    }
}

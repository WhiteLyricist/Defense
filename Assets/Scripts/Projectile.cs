using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageable
{
    [SerializeField] private float speed;
    private float damage;
    private string target;
    private Vector2 direction;

    public static Action<float> OnGetDamage = delegate { };

    public void SetDamage(float d, string targetTag, Vector2 direct) 
    {
        damage = d;
        target = targetTag;
        direction = direct;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag==target) 
        {
            collision.gameObject.GetComponent<IDamageable>().GetDamage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction*10f, speed * Time.deltaTime);
    }

    private IEnumerator Die() 
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {
        Destroy(gameObject);
    }
}

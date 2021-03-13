using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUnit : BaseUnit
{

    public override void Attack()
    {
        var _arrow = Instantiate(arrowPrefab) as GameObject;
        var angle = Vector2.Angle(Vector2.right, Vector3.zero - transform.position);
        _arrow.transform.position = transform.position;
        _arrow.transform.eulerAngles = new Vector3(0f, 0f, _arrow.transform.position.y < 0f ? angle : -angle);
        _arrow.GetComponent<Projectile>().SetDamage(damage,"Hero",Vector2.zero);
    }


    public override void Move()
    {
        base.Move();
    }

    void Start() 
    {
        range = Vector3.Distance(transform.position, Vector2.zero) / 2;
    }

}

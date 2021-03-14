using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUnit : BaseUnit
{

    public override void SetParameters()
    {
        base.SetParameters();
        speed *= 2;
        health /= 2;
        damage *= 2;
    }

    public override void Move()
    {
        base.Move();
    }

    public override void Attack()
    {
        OnGetDamage(damage);
        var _bang = Instantiate(bangPrefab) as GameObject;
        _bang.transform.position = transform.position;
        Destroy(gameObject);
    }

}

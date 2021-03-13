using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : BaseUnit
{

    public override void SetParameters(float s, float d, float h)
    {
        base.SetParameters(s, d, h);
        speed /= 2;
        health *= 2;
    }

    public override void Move()
    {
        base.Move();
    }

    public override void Attack()
    {
        OnGetDamage(damage);
    }

}

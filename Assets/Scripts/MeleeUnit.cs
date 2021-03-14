using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : BaseUnit
{

    public override void SetParameters()
    {
        base.SetParameters();
        speed /= 2;
        health *= 2;
        _hpBar.UpdateHPBar(health, maxHealth);
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

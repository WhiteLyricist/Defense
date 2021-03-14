using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private float startScale;

    // Start is called before the first frame update
    void Awake()
    {
        startScale = transform.localScale.x;
    }

    public void UpdateHPBar(float hp, float maxhp)
    {
        if (hp > 0)
        {
            var percent = hp / maxhp;
            transform.localScale = new Vector2(startScale * percent, transform.localScale.y); ;
        }
        else transform.localScale = Vector2.zero;
    }
}

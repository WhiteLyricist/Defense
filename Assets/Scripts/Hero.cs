using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour, IDamageable
{

    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] protected float attackSpeed = 0.1f;

    [SerializeField] private Text endGame;

    [SerializeField] private HPBar _hpBar;

    private float maxHealth;

    Animator _anim;

    protected float cooldown;

    [SerializeField] protected GameObject arrowPrefab;


    public virtual void SetParameters()
    {
        damage = UnitParameters.HeroDamage;
        maxHealth = UnitParameters.HeroHealth;
        health = maxHealth;
    }

    private void Start()
    {
        BaseUnit.OnGetDamage += GetDamage;
        _anim = gameObject.GetComponent<Animator>();
        SetParameters();
    }

    public void GetDamage(float damage) 
    {
        health -= damage;
        _hpBar.UpdateHPBar(health, maxHealth);
        if (health <= 0) 
        {
            endGame.text = "К сожалению вы проиграли!";
            StartCoroutine(EndGame());
            SceneManager.LoadScene("Menu");
            Destroy(gameObject);
        }
    }
    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0)) 
        {
            _anim.SetInteger("Defender", 1);
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
        else _anim.SetInteger("Defender", 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Enemy setting")]
    [SerializeField] private TMP_InputField enemyDamage;
    [SerializeField] private TMP_InputField enemyHealth;
    [SerializeField] private TMP_InputField enemyDelay;

    [Space]
    [Header("Hero setting")]
    [SerializeField] private TMP_InputField heroDamage;
    [SerializeField] private TMP_InputField heroHealth;

    private void OnEnable()
    {
        enemyDamage.text = UnitParameters.EnemyDamage.ToString();
        enemyHealth.text = UnitParameters.EnemyHealth.ToString();
        enemyDelay.text = UnitParameters.EnemyDelay.ToString();

        heroDamage.text = UnitParameters.HeroDamage.ToString();
        heroHealth.text = UnitParameters.HeroHealth.ToString();
    }

    public void SetParameters()
    {
        UnitParameters.SetUnitParameters(float.Parse(enemyDamage.text), float.Parse(enemyHealth.text), float.Parse(enemyDelay.text), float.Parse(heroDamage.text), float.Parse(heroHealth.text));
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }

}

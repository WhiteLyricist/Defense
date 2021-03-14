using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitParameters 
{
     private static float enemyDamage=2;
     public static float EnemyDamage
     { get => enemyDamage; }

     private static float enemyHealth=5;
     public static float EnemyHealth
     { get => enemyHealth; }

     private static float enemyDelay=4;
     public static float EnemyDelay
     { get => enemyDelay; }

    private static float heroDamage=2;
    public static float HeroDamage
    { get => heroDamage; }

    private static float heroHealth=50;
    public static float HeroHealth
    { get => heroHealth; }

    public static void SetUnitParameters(float eDamage, float eHealth, float eDelay, float hDamage, float hHealth) 
    {
        enemyDamage = eDamage;
        enemyHealth = eHealth;
        enemyDelay = eDelay;

        heroDamage = hDamage;
        heroHealth = hHealth;
    }
}

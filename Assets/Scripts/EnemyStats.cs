using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyStats", menuName = "ScriptableObject/Characters/EnemyStats")]
public class EnemyStats : ScriptableObject{
    //For Health
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private float sinkSpeed = 2.5f;
    [SerializeField] private int scoreValue = 10;

    //For Attacks
    [SerializeField] public float timeBetweenAttacks = 0.5f;
    [SerializeField] public int attackDamage = 10;


    public int GetStartingHealth(){
        return startingHealth;
    }
    public float GetSinkSpeed(){
        return sinkSpeed;
    }
    public int GetScoreValue(){
        return scoreValue;
    }
    public float GetTimeBetweenAttacks(){
        return timeBetweenAttacks;
    }
    public int GetAttackDamage(){
        return attackDamage;
    }
}

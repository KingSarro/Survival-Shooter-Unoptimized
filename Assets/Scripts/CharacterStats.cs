using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CharacterStats", menuName = "ScriptableObject/Characters/Stats")]
public class CharacterStats : ScriptableObject{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public void ReduceHealth(int damage){
        currentHealth -= damage;

        if(currentHealth < 0){
            currentHealth = 0;
        }
    }
    public void SetCurrentHealth(int health){
        currentHealth = health;
    }
    public int GetCurrentHealth(){
        return currentHealth;
    }
    public int GetMaxHealth(){
        return maxHealth;
    }
}

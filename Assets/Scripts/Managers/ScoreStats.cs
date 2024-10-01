using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ScoreStats", menuName = "ScriptableObject/UI/Score")]
public class ScoreStats : ScriptableObject{
    [SerializeField] private int currentScore;


    public void IncreaseScore(int points){
        currentScore += points;
    }
    public void SetCurrentScore(int score){
        currentScore = score;
    }
    public int GetCurrentScore(){
        return currentScore;
    }

}

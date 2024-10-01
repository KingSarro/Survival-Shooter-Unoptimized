using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour{
    ////public static int score;
    [SerializeField] ScoreStats score;


    [SerializeField] Text text;


    void Awake ()
    {
        score.SetCurrentScore(0);
    }


    void Update ()
    {
        text.text = "Score: " + score.GetCurrentScore();
    }
}

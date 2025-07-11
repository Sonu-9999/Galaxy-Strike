using UnityEngine;
using TMPro;
// This script manages the scoreboard, allowing score increases and displaying the score in the console.
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoretext;
    int score = 0;
    public void IncreaseScore(int points)
    {
        score += points;
        scoretext.text = score.ToString();
        //scoretext is a component and .text is a property which is a string which is displayed in the UI
    }
}

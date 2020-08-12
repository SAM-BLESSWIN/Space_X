using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour
{
    int score;
    Text scoretext;

    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
    }

    public void scorepoints(int points)
    {
        score = score + points;
        scoretext.text = score.ToString();
    }
}

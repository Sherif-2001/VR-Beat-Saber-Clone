using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Beats : 0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addPoint()
    {
        score++;
        scoreText.text = "Beats : " + score;
    }
}

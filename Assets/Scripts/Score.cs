using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text TMPText;
    [SerializeField] private int _scoreMultiplier;

    private float _score;

    public const string HighScoreKey = "HighScore";

    // Update is called once per frame
    void Update()
    {
        _score += _scoreMultiplier * Time.deltaTime;

        TMPText.text = Mathf.FloorToInt(_score).ToString();
    }

    private void OnDestroy()
    {
        int currentHigh = PlayerPrefs.GetInt(HighScoreKey, 0);
        if(_score > currentHigh)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(_score));
        }
    }
}

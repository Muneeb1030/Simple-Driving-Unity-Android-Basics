using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text TMPtext;
    [SerializeField] private TMP_Text EnergyTxt;
    [SerializeField] private  Notification notificationHandler;
    [SerializeField] private Button btnPlay;

    [SerializeField] private int maxEnergy;
    [SerializeField] private int rechargeDuration;

    private const string energyKey = "Energy", enerygyready = "EnergyReady";
    private int energy;

    private void Start()
    {
        OnApplicationFocus(true);
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus)
        {
            return;
        }
        CancelInvoke();
        int High = PlayerPrefs.GetInt(Score.HighScoreKey, 0);
        TMPtext.text = $"High Score: {High}";

        energy = PlayerPrefs.GetInt(energyKey, maxEnergy);

        if(energy == 0)
        {
            string EnergyReady = PlayerPrefs.GetString(enerygyready, string.Empty);
            if(EnergyReady == string.Empty)
            {
                return;
            }
            DateTime Readytime = DateTime.Parse(EnergyReady);
            if(DateTime.Now > Readytime)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(energyKey, energy);
            }
            else
            {
                btnPlay.interactable = false;
                Invoke(nameof(EnergyCharged), (Readytime - DateTime.Now).Seconds);

            }
        }
        EnergyTxt.text = $"Play ({energy})";
    }
    private void EnergyCharged()
    {
        btnPlay.interactable = true;
        energy = maxEnergy;
        PlayerPrefs.SetInt(energyKey, energy);
        EnergyTxt.text = $"Play ({energy})";
    }
    public void Play()
    {
        if(energy<1)
        {
            return;
        }
        energy--;
        PlayerPrefs.SetInt(energyKey, energy);

        if(energy == 0)
        {
            DateTime Readytime = DateTime.Now.AddMinutes(rechargeDuration);
            PlayerPrefs.SetString(enerygyready, Readytime.ToString());
            notificationHandler.ScheduleNotification(Readytime);
        }
        SceneManager.LoadScene(1);
    }

}

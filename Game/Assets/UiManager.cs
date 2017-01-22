using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public GameObject shieldManager;

    public Image healthManager;

    int _score;
    public int score
    {
        get { return _score; }
        set { _score = value; ChangeScore(); }
    }


    public Text scoreText;

    Text healthText;

    Image[] shieldLevels;

    public static UiManager instance;

   

    private void Awake()
    {
        instance = this;
        healthText = healthManager.GetComponentInChildren<Text>();
        shieldLevels = shieldManager.GetComponentsInChildren<Image>();

        score = 0;
    }

    void ChangeScore()
    {
        scoreText.text = "Score : "+score;
    }

    public void SetShieldColor(Color color)
    {
        foreach (var level in shieldLevels)
        {
            level.color = color;
        }
    }

    public void SetHealthLevel(float value)
    {
        healthManager.fillAmount = value;
        healthText.text = Mathf.RoundToInt(value * 100).ToString();
    }

    public void SetShieldLevel(float value)
    {
        shieldLevels[0].gameObject.SetActive(value > .33f);
        shieldLevels[1].gameObject.SetActive(value > .66f);
        shieldLevels[2].gameObject.SetActive(value >= 1f);
    }
}

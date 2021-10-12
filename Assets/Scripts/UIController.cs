using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private TextMeshProUGUI coinsText;

    private int coinsCount;
    private bool pause = false;

    public Action OnGamePaused;
    public static UIController instance;

    private void Start()
    {
        instance = this;
    }

    public void FinishPanel()
    {
        coinsText.gameObject.SetActive(!coinsText.gameObject.activeSelf);
        finishPanel.SetActive(!finishPanel.activeSelf);
        finishText.text = $"Coins: {coinsCount}";
    }
    public void RestartLevel(int index) => SceneManager.LoadScene(index);
    private void UpdateCoinsView() => coinsText.text = $"Coins: {coinsCount}";

    public int CoinsCount
    {
        get { return coinsCount; }
        set 
        { 
            coinsCount = value;
            UpdateCoinsView();
        }
    }

    public bool Pause
    {
        get { return pause; }
        set 
        {
            pause = value;
            OnGamePaused();  
        }
    }
}

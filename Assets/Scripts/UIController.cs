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
    private bool finished = false;

    public Action OnGameFinished;
    public static UIController instance;

    private void Awake()
    {
        instance = this;
        OnGameFinished += FinishPanel;
    }

    public void RestartLevel(int index) => SceneManager.LoadScene(index);

    private void UpdateCoinsView() => coinsText.text = $"Coins: {coinsCount}";

    private void FinishPanel()
    {
        finished = true;
        coinsText.gameObject.SetActive(!coinsText.gameObject.activeSelf);
        finishPanel.SetActive(!finishPanel.activeSelf);
        finishText.text = $"Coins: {coinsCount}";
    }

    public int CoinsCount
    {
        get { return coinsCount; }
        set 
        { 
            coinsCount = value;
            UpdateCoinsView();
        }
    }

    public bool Finished
    {
        get { return finished; }
    }
}

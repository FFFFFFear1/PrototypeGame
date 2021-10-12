using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private int coinsCount;

    public Action OnCoinsChanged;

    public static UIController instance;

    void Start()
    {
        instance = this;
        OnCoinsChanged += UpdateCoinsView;
    }

    private void UpdateCoinsView()
    {
        coinsText.text = $"Coins: {coinsCount}";
    }

    public int CoinsCount
    {
        get { return coinsCount; }
        set 
        { 
            coinsCount += value;
            OnCoinsChanged();
        }
    }
}

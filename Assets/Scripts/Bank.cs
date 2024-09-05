using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI score;
    public int CurrentBalance {get {return currentBalance;}}

    void Awake()
    {
        currentBalance = startingBalance;
    }

    void Update()
    {
        UpdateScore();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateScore();
    }

    public void WithDrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (score != null)
        {
            score.text = currentBalance.ToString();
        }

        if (currentBalance <= 0)
        {
            ReloadScene(0);
        }
    }

    private void ReloadScene(int currentScene)
    {
        SceneManager.LoadScene(currentScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Bank bank;
    [SerializeField] int reward = 25;
    [SerializeField] int penalty = 25;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardProcess()
    {
        if(bank != null)
        {
            bank.Deposit(reward);
        }
    }

    public void PenaltyProcess()
    {
        if(bank != null)
        {
            bank.WithDrawal(penalty);
        }
    }
}

 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WayPath : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] bool isPlaceable;
    int cost = 75;
    public bool Isplaceable {get {return isPlaceable;}};
    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    void OnMouseDown()
    {
        if(isPlaceable && bank.CurrentBalance >= cost)
        {
           Instantiate(tower, transform.position, Quaternion.identity);
           isPlaceable = false;
           bank.WithDrawal(cost);
        }
    }
}

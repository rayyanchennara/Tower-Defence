using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 3;
    [SerializeField] int addHitPoints = 2;
    public int currentHitPoints = 0;
    Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject gameObject)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints++;
        if (currentHitPoints == maxHitPoints)
        {
            gameObject.SetActive(false);
            currentHitPoints = 0;
            maxHitPoints += addHitPoints;
            if(enemy != null)
            {
                enemy.RewardProcess();
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField] Transform tower;
    [SerializeField] ParticleSystem bullet;
    // Transform target;
    Transform closestEnemy;
    float closestDistance;
    // Start is called before the first frame update
    void Start()
    {
        // target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyLocator();
        FindClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        closestDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance<closestDistance)
            {
                closestEnemy = enemy.transform;
                closestDistance = distance;
            }
        }
    }

    private void EnemyLocator()
    {
        tower.LookAt(closestEnemy);
        if(closestDistance <=20)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = bullet.emission;
        emissionModule.enabled = isActive;
    }
}

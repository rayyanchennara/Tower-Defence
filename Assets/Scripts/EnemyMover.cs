using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPath> path = new List<WayPath>();
    [SerializeField] [Range(1f,5f)] float speed = 1f;
    Enemy enemy;
    EnemyHealth enemyHealth;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    void OnEnable()
    {
        FindPath();
        ResetToStart();
        StartCoroutine(FollowPath());
    }
    
    private void FindPath()
    {
    path.Clear();
    GameObject parentObject = GameObject.FindGameObjectWithTag("path");
    if (parentObject != null)
    {
        WayPath[] wayPaths = parentObject.GetComponentsInChildren<WayPath>();
        foreach (WayPath wayPath in wayPaths)
        {
            // Add the WayPath to your path list:
            path.Add(wayPath);
        }
    }
}

    // Update is called once per frame
    IEnumerator FollowPath()
    {
        foreach (WayPath wayPath in path)
        {
            Vector3 startingPosition = transform.position;
            Vector3 endPosition = wayPath.transform.position;
            float travePercent = 0f;
            transform.LookAt(endPosition);
            while(travePercent < 1f)
            {
                travePercent += speed * Time.deltaTime;
                transform.position = Vector3.Lerp(startingPosition, endPosition, travePercent);
                yield return new WaitForEndOfFrame();
            }
        }
        gameObject.SetActive(false);
        if(enemyHealth != null)
        {
            enemyHealth.currentHitPoints = 0;
        }
        if(enemy != null)
        {
            enemy.PenaltyProcess();
        }
    }

    private void ResetToStart()
    {
        transform.position = path[0].transform.position;
    }
}


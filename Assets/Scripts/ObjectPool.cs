using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeToWait = 3f;
    [SerializeField] int poolsize = 3;
    GameObject[] pool;
    // Start is called before the first frame update
    void Awake()
    {
        populatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnManeger());
    }

    IEnumerator SpawnManeger()
    {
        while(true)
        {
          EnableObjectInPool();
          yield return new WaitForSeconds(timeToWait);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i<pool.Length; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    void populatePool()
    {
        pool = new GameObject[poolsize];
        for(int i = 0 ; i<pool.Length ; i++)
        {
            pool[i] = Instantiate(enemyPrefab , transform);
            pool[i].SetActive(false);
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Tower : MonoBehaviour
// {
//     int cost = 75;

//     public bool CreateTower(Tower tower , Vector3 position)
//     {
//         Bank bank = FindObjectOfType<Bank>();
//         if(bank !=null)
//         {
//             if(bank.CurrentBalance >= cost)
//             {
//                 Instantiate(tower.gameObject, position, Quaternion.identity);
//                 bank.WithDrawal(cost);
//                 return true;
//             }

//             return false;
//         }
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

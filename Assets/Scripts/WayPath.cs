using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WayPath : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] bool isPlaceable;
     public bool Isplaceable => isPlaceable;
    void OnMouseDown()
    {
        if(isPlaceable)
        {
           Instantiate(tower, transform.position, Quaternion.identity);
           isPlaceable = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    // CASH
    TextMeshPro textMeshPro;
    Vector2Int coordinates = new Vector2Int();
    [SerializeField] WayPath wayPath;

    // Colors
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.gray;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.enabled = true;
        DisplayCoordinate();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {if(!Application.isPlaying)
        {
           DisplayCoordinate();
           UpdateCoordinate();
        }

        ToggleCordinates();
        ColorCordinates();
    }

    private void ColorCordinates()
    {
            if(wayPath.Isplaceable)
        {
            textMeshPro.color = defaultColor;
        }
        else
        {
            textMeshPro.color = blockColor;
        }
    }

    private void ToggleCordinates()
    {
        if(Input.GetKey(KeyCode.C))
        {
            textMeshPro.enabled = !textMeshPro.IsActive();
        }
    }

    private void UpdateCoordinate()
    {
        transform.parent.name = coordinates.ToString();
    }

    private void DisplayCoordinate()
    {
        int gridSize = 10;
        if(textMeshPro != null)
        {
            coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridSize);
            coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridSize);
            textMeshPro.text = coordinates.x + "," + coordinates.y;
        }
    }
}

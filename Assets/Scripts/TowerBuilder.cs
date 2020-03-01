using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] bool isPlaceble = false;
    [SerializeField] Tower towerPrefab = null;

    Transform towersParent;

    private void Start() 
    {
        if (GameObject.Find("Towers").transform)
        {
            towersParent = GameObject.Find("Towers").transform;
        }
        else
        {
            print("There is no GameObject with name Towers in scene to put spawned towers in");
        }
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleTowerBuilding();
        }
    }

    private void HandleTowerBuilding()
    {
        if (isPlaceble)
        {
            BuildTower();
        }
        else
        {
            print("Can`t place shit here!");
        }
    }

    private void BuildTower()
    {
        if (GameObject.Find("Towers").transform)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity, towersParent);
        }
        else 
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
        }
            
        isPlaceble = false;
    }
}

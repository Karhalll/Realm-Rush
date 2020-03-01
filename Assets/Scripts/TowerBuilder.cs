using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] public bool isPlaceble = false;

    TowerFactory towerFactory;

    private void Start() 
    {
        towerFactory = FindObjectOfType<TowerFactory>();        
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
        towerFactory.AddTower(this);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] static int towerLimit = 3;
    [SerializeField] Tower towerPrefab = null;

    Transform towers = null;

    Queue<BuildedTower> buildedTowers = new Queue<BuildedTower>(towerLimit);
   
    class BuildedTower
    {
        public Tower tower;
        public TowerBuilder towerBuilder;
    }

    private void Start() 
    {
        towers = GameObject.Find("Towers").transform;
    }
    
    public void AddTower(TowerBuilder baseWaypoint)
    {
        if(buildedTowers.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(TowerBuilder baseWaypoint)
    {
        BuildedTower removedTower = buildedTowers.Dequeue();

        SwitchBaseWaypoints(baseWaypoint, removedTower);
        MoveTower(baseWaypoint, removedTower);

        buildedTowers.Enqueue(removedTower);
    }

    private void MoveTower(TowerBuilder block, BuildedTower tower)
    {
        tower.tower.transform.position = block.transform.position;
    }

    private static void SwitchBaseWaypoints(TowerBuilder baseWaypoint, BuildedTower removedTower)
    {
        removedTower.towerBuilder.isPlaceble = true;
        removedTower.towerBuilder = baseWaypoint;
        removedTower.towerBuilder.isPlaceble = false;
    }

    private void InstantiateNewTower(TowerBuilder baseWaypoint)
    {
        Tower tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towers);

        baseWaypoint.isPlaceble = false;
        AddTowerToQueue(baseWaypoint, tower);
    }

    private void AddTowerToQueue(TowerBuilder baseWaypoint, Tower tower)
    {
        BuildedTower buildedTower = new BuildedTower();
        buildedTower.tower = tower;
        buildedTower.towerBuilder = baseWaypoint;
        buildedTowers.Enqueue(buildedTower);
    }
}

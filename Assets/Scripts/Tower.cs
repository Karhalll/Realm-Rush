using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    [SerializeField] Transform targetEnemy = null;

    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    private void OnMouseOver()
    {
        print(transform.position.x + ", " + transform.position.z);
    }
}

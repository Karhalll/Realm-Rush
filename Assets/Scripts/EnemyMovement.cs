using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] ParticleSystem reachGoalVFXPrefab = null;

    private void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(moveSpeed);
        }

        HandleRechedGoal();
    }

    private void HandleRechedGoal()
    {
        ParticleSystem reachGoalVFX = Instantiate(reachGoalVFXPrefab, transform.position, Quaternion.identity); 
        float destroyDelay = reachGoalVFX.main.duration;
        Destroy(reachGoalVFX.gameObject,destroyDelay);
        Destroy(gameObject);
    }
}

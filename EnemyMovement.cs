using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject world;
    public List<Waypoint> pathToFollow;

    void Start()
    {
        world = GameObject.Find("World");
        pathToFollow = world.GetComponent<FollowThisPath>().pathToGoal;
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in pathToFollow)
        {
            transform.position = waypoint.transform.position;
            transform.rotation = Quaternion.Euler( 0f,  90f, 0f);
            //Debug.Log("Visiting: " + waypoint);
            yield return new WaitForSeconds(1.5f);
        }
    }
}

using UnityEngine;
using System.Collections;

public class WaypointScript : MonoBehaviour {

    private static GameObject start;

    public GameObject next;
    public bool isStart = false;

    void Awake()
    {
        if (!next)
        {
            print("This waypoint is not connected; fix the problem" + this);
        }
        if (isStart)
        {
            start = gameObject;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

       if (next)
       {
           Gizmos.color = new Color(0, 1, 0, 0.3f);
           Gizmos.DrawLine(transform.position, next.transform.position);
       }
    }

    Vector3 CalculateTargetPosition (Vector3 position)
    {
        if (Vector3.Distance(transform.position, position) < 50)
        {
            return next.transform.position;
        }
        else
        {
            return transform.position;
        }
    }
}

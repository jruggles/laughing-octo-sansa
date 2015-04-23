using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Transform[] waypoints;
    private int currentWaypoint = 0;

    public GameObject waypointContainer;
    public float speed = 10.0f;
    private float rotationSpeed = 4.0f;
    private Quaternion lookRotation;

    CharacterController charControl;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }
	// Use this for initialization
    void Start()
    {
        // Get the waypoint transforms.
        Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();

        waypoints = new Transform[potentialWaypoints.Length - 1];

        print("PlayerScript:  " + potentialWaypoints.Length);

        for (int i = 0, j = 0; i < potentialWaypoints.Length; i++)
        {
            if (potentialWaypoints[i] != waypointContainer.transform)
            {
                // This is not the container; add the waypoint to the array.
                waypoints[j++] = potentialWaypoints[i];
            }
        }

    }

    void FixedUpdate()
    {

        Vector3 movement = NavigateTowardWaypoint();

        lookRotation = Quaternion.LookRotation(movement);

        float thingy = (Time.deltaTime * 5);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, thingy);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 40;
        charControl.SimpleMove(forward);

    }

    Vector3 NavigateTowardWaypoint()
    {
        Vector3 relativeWaypointPosition =
            waypoints[currentWaypoint].position - transform.position;

        if (relativeWaypointPosition.magnitude < 10)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            print("Current waypoint: " + currentWaypoint);
        }

        return relativeWaypointPosition;
    }
	
	
	// Update is called once per frame
	void Update () {
	
	}
}

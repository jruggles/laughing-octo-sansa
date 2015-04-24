using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    private Transform[] waypoints;
    private int currentWaypoint = 0;
    public GameObject waypointContainer;
    public float speed;
    private float rotationSpeed = 4.0f;
    private Quaternion lookRotation;
	private Vector3 relativeWaypointPosition;

    CharacterController charControl;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    void Start()
    {
        Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();

        waypoints = new Transform[potentialWaypoints.Length - 1];

        print("PlayerScript:  " + potentialWaypoints.Length);

        for (int i = 0, j = 0; i < potentialWaypoints.Length; i++)
        {
            if (potentialWaypoints[i] != waypointContainer.transform)
            {
                waypoints[j++] = potentialWaypoints[i];
            }
        }

    }

    void Update()
    {
        rotateAndMoveKart();
    }

    void rotateAndMoveKart()
    {
        Vector3 rayStartFront = transform.position + (transform.forward * 1f) - transform.up * .5f;
        Vector3 rayStartBack = transform.position - (transform.forward * .7f) - transform.up * .5f;
        RaycastHit frontHitObj;
        RaycastHit backHitObj;
        Ray ray1 = new Ray(rayStartFront, -(transform.up));
        Ray ray2 = new Ray(rayStartBack, -(transform.up));
        Debug.DrawRay(rayStartFront, -Vector3.up * -1.5f, Color.magenta);
        Debug.DrawRay(rayStartBack, -Vector3.up * -1.5f, Color.cyan);
        if (Physics.Raycast(ray1, out frontHitObj, 2.0f) && Physics.Raycast(ray2, out backHitObj, 2.0f))
        {
            Debug.Log(frontHitObj.collider.gameObject + " " + backHitObj.collider.gameObject);
            if (backHitObj.collider.gameObject == frontHitObj.collider.gameObject)
            {
                Quaternion rotation = Quaternion.FromToRotation(transform.up, frontHitObj.normal);
                transform.rotation = rotation * transform.rotation;
            }
        }

        Vector3 movement = NavigateTowardWaypoint();
        lookRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * speed;
        charControl.SimpleMove(forward);
    }

    Vector3 NavigateTowardWaypoint()
    {
        relativeWaypointPosition =
            waypoints[currentWaypoint].position - transform.position;

		if (relativeWaypointPosition.magnitude < 30) {
			determineMovementSpeed (0);
		} else  {
			determineMovementSpeed(1);
		}
        if (relativeWaypointPosition.magnitude < 10)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            print("Current waypoint: " + currentWaypoint);
        }

        return relativeWaypointPosition;
    }

	public void determineMovementSpeed(float vAxis)
	{
		//If there in input on the vertical axis
		if (vAxis != 0)
		{
			//And if movement speed is between the min speed (-20) and the max speed (40)
			if (speed <= 50 && speed >= -20)
			{
				//If the player is trying to move forward (posititve vertical axis)
				if (vAxis > 0)
				{
					//If you are currently moving backwards and trying to move forward
                    if (speed < 0)
                    {
                        speed += Time.deltaTime * 75; //Brake hard
                    }
                    else //Else accelerate forward normally
                    {
                        speed += Time.deltaTime * 20;
                    }
				} 
				//If the player is trying to move backwards (negative vertical axis)
				else if (vAxis < 0)
				{
					//If the player is currently moving forward and trying to move backwards
					if (speed > 0)
					{
						speed -= Time.deltaTime * 75; //Brake hard
					} else //Else accelerate backwards normally (half the speed as accelerating forward normally)
					{
						speed -= Time.deltaTime * 10;
					}     
				}	
			}
		}
		//Else - If there is no input start to deaccelerate
		else 
		{
			//If the player is moving forward
			if (speed > 0)
			{
				speed -= Time.deltaTime * 25; //Then casually brake
				//If the movement speed is <1 then set it to 0 (so you won't flip-flop between negative and positive)
				if (speed < 1)
				{
					speed = 0;
				}
			} 
			//Else if the player is moving backwards
			else if (speed < 0) 
			{
				speed += Time.deltaTime * 35; //Then mediumly (new word) brake - Sligtly faster braking if backing up
				//If the movement speed is >-1 then set it to 0 (so you won't flip-flop between negative and positive)
				if (speed > -1)
				{
					speed = 0;
				}
			}
		}
	}
}

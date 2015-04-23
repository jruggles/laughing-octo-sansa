using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Transform[] waypoints;
    private int currentWaypoint = 0;
	private firstPersonController fpc;
    public GameObject waypointContainer;
    public float speed;
    private float rotationSpeed = 4.0f;
    private Quaternion lookRotation;
	private Vector3 relativeWaypointPosition;

    CharacterController charControl;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
		fpc = GetComponent<firstPersonController> ();
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

    void Update()
    {

        Vector3 movement = NavigateTowardWaypoint();

        lookRotation = Quaternion.LookRotation(movement);

        float thingy = (Time.deltaTime * 5);

		//speed = fpc.determineMovementSpeed (1);
	
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, thingy);
        Vector3 forward = transform.TransformDirection(Vector3.forward)  * speed;
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
        if (relativeWaypointPosition.magnitude < 15)
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

using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    public float maxSpeed = 0;
    public float minSpeed = 0;
    public float movementSpeed = 0;
    public float rotatingSpeed = 0;
    private Transform[] waypoints;
    private int currentWaypoint = 0;
    private GameObject waypointContainer;
    private float rotationSpeed = 4.0f;
    private Quaternion lookRotation;
	private Vector3 relativeWaypointPosition;
    private bool onFinish = false;
    private GameObject finishLine;

    public int lap = 0;
    public float lapTime = 0;

    CharacterController charControl;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        finishLine = GameObject.Find("StartFinish");
        waypointContainer = GameObject.Find("WaypointContainer");

    }

    void Start()
    {
        Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();

        waypoints = new Transform[potentialWaypoints.Length - 1];

        for (int i = 0, j = 0; i < potentialWaypoints.Length; i++)
        {
            if (potentialWaypoints[i] != waypointContainer.transform)
            {
                waypoints[j++] = potentialWaypoints[i];
            }
        }

    }

    void FixedUpdate()
    {
        rotateAndMoveKart();
        NavigateTowardWaypoint();
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
            if (backHitObj.collider.gameObject == frontHitObj.collider.gameObject)
            {
                if (backHitObj.collider.gameObject == finishLine && onFinish == false)
                {
                    onFinish = true;
                    OnCollisionEnter();

                }
                else if (backHitObj.collider.gameObject != finishLine)
                {
                    onFinish = false;
                }

                Quaternion rotation = Quaternion.FromToRotation(transform.up, frontHitObj.normal);
                transform.rotation = rotation * transform.rotation;
            }
        }  
    
    }

    Vector3 NavigateTowardWaypoint()
    {
        relativeWaypointPosition =
            waypoints[currentWaypoint].position - transform.position;

		if (relativeWaypointPosition.magnitude < 20) {
			determineMovementSpeed (0);
		} else  {
			determineMovementSpeed(1);
		}
        if (relativeWaypointPosition.magnitude < 15)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        float angle = AngleSigned(relativeWaypointPosition, transform.forward, transform.up);
        if (angle > 5 && movementSpeed != 0)
        {
            //Vector3.Slerp()
            transform.Rotate(new Vector3(0, -1f * rotatingSpeed * Time.deltaTime * ((movementSpeed / maxSpeed) + 0.25f), 0));
           
        
        }
        else if (angle < -5 && movementSpeed != 0)
        {
            transform.Rotate(new Vector3(0, 1f * rotatingSpeed * Time.deltaTime * ((movementSpeed / 50) + 0.25f), 0)); 
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * movementSpeed;
        charControl.SimpleMove(forward);

        return relativeWaypointPosition;


    }

	public void determineMovementSpeed(float vAxis)
	{
		//If there in input on the vertical axis
		if (vAxis != 0)
		{
			//And if movement speed is between the min speed (-20) and the max speed (40)
            if (movementSpeed <= maxSpeed && movementSpeed >= minSpeed)
			{
				//If the player is trying to move forward (posititve vertical axis)
				if (vAxis > 0)
				{
					//If you are currently moving backwards and trying to move forward
                    if (movementSpeed < 0)
                    {
                        movementSpeed += Time.deltaTime * 75; //Brake hard
                    }
                    else //Else accelerate forward normally
                    {
                        movementSpeed += Time.deltaTime * 20;
                    }
				} 
				//If the player is trying to move backwards (negative vertical axis)
				else if (vAxis < 0)
				{
					//If the player is currently moving forward and trying to move backwards
                    if (movementSpeed > 0)
					{
                        movementSpeed -= Time.deltaTime * 75; //Brake hard
					} else //Else accelerate backwards normally (half the speed as accelerating forward normally)
					{
                        movementSpeed -= Time.deltaTime * 10;
					}     
				}	
			}
		}
		//Else - If there is no input start to deaccelerate
		else 
		{
			//If the player is moving forward
            if (movementSpeed > 0)
			{
                movementSpeed -= Time.deltaTime * 25; //Then casually brake
				//If the movement speed is <1 then set it to 0 (so you won't flip-flop between negative and positive)
                if (movementSpeed < 1)
				{
                    movementSpeed = 0;
				}
			} 
			//Else if the player is moving backwards
            else if (movementSpeed < 0) 
			{
                movementSpeed += Time.deltaTime * 35; //Then mediumly (new word) brake - Sligtly faster braking if backing up
				//If the movement speed is >-1 then set it to 0 (so you won't flip-flop between negative and positive)
                if (movementSpeed > -1)
				{
                    movementSpeed = 0;
				}
			}
		}
	}

    public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
    {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

    public void OnCollisionEnter()
    {
        lap++;

        if (lap == 4)
        {
            lapTime = Time.time;
        }
    }
}

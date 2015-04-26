﻿using UnityEngine;
using System.Collections;

public class firstPersonController : MonoBehaviour {

    public float maxSpeed = 0;
    public float minSpeed = 0;
    public float movementSpeed = 0;
    public float rotatingSpeed = 0;
    public float vAxis = 0;	

    CharacterController charControl;

    void Awake() {
        charControl = GetComponent<CharacterController>();
    }

	// Update is called once per frame
	void Update ()
    {

        vAxis = Input.GetAxis("Vertical");
		//Debug.Log (vAxis);
        rotateKart();

        determineMovementSpeed(vAxis);

        SimpleMove(); 

	}

    public float determineMovementSpeed(float vAxis)
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
		return movementSpeed;
    }

    void rotateKart()
    {
        Vector3 rayStartFront = transform.position + (transform.forward * 1f) - transform.up * .5f;
        Vector3 rayStartBack = transform.position - (transform.forward * .7f) - transform.up * .5f;
        RaycastHit frontHitObj;
        RaycastHit backHitObj;
        Ray ray1 = new Ray(rayStartFront,  -(transform.up ));
        Ray ray2 = new Ray(rayStartBack, -(transform.up ));
        Debug.DrawRay(rayStartFront, -Vector3.up * -1.5f, Color.magenta);
        Debug.DrawRay(rayStartBack, -Vector3.up * -1.5f, Color.cyan);
        if (Physics.Raycast(ray1, out frontHitObj, 2.0f) && Physics.Raycast(ray2, out backHitObj, 2.0f))
        { 
            //Debug.Log(frontHitObj.collider.gameObject + " " + backHitObj.collider.gameObject);
            if (backHitObj.collider.gameObject == frontHitObj.collider.gameObject)
            {

              Quaternion rotation = Quaternion.FromToRotation(transform.up, frontHitObj.normal);
             transform.rotation = rotation * transform.rotation;

            }
        
        }

    }

    void SimpleMove() {

        //Move forward or backward depending on the movement speed.
        Vector3 forward = transform.TransformDirection(Vector3.forward) * movementSpeed;

        rotateKart();

        //If you are moving
        if (movementSpeed != 0)
        {
            //Rotate if the horizontal axis is moved
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotatingSpeed * Time.deltaTime * ((movementSpeed / maxSpeed) + 0.25f), 0)); 
            //NOTE: I added (movementSpeed/maxSpeed) + 0.2 so where the faster you move the harder you can turn.
        }
     
        charControl.SimpleMove(forward);

    }
}


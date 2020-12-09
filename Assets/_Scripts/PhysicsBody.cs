﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsBody : MonoBehaviour
{
    // Start is called before the first frame update
    public float mass;
    public float friction; // use for slowing down, implement soon
    public Vector3 velocity;
    public Vector3 acceleration;
    public float restitution; // bounciness

    public float speed; // speed of velocity
    public float gravity;
    public Vector3 forward;

    // Debug Text
    Text debugText;

    void OnEnable()
    {
        velocity = forward * speed;
        acceleration = new Vector3(0.0f, gravity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        
        //Debug.Log(acceleration);
        //if (gameObject.GetComponent<CubeBehaviour>() != null)
        //{
        //    if (gameObject.GetComponent<CubeBehaviour>().isColliding)
        //    {
        //        // this foreach loop is handling cube on cubes, do another foreach check for the number of spheres
        //        foreach (CubeBehaviour cubes in gameObject.GetComponent<CubeBehaviour>().contacts)
        //        {
        //            //Debug.Log(velocity);
        //            if (cubes.tag == "Box")
        //            {
        //                //Debug.Log(acceleration);
        //                CollisionResponseCubeCube(cubes);
        //            }
        //        }
        //        //foreach (SphereProperties spheres in gameObject.GetComponent<CubeBehaviour>().sphereContacts)
        //        //{
        //        //    CollisionResponseSphere(spheres);
        //        //}
        //    }
        //}
        //if (velocity.y != 0.0f)
        //{
            //Debug.Break();
           
        //}
       
    }

    // creating a separate class for cube cube collision response for now
    public void CollisionResponseCubeCube(CubeBehaviour cube)
    {
        Debug.Log("In Response of Cube Cube");
        velocity.y *= 0.0f;
        acceleration.y *= 0.0f;
    }


    // responding to the collision by changing the relative velocity of objects
    public void CollisionResponseCube(CubeBehaviour cube)
    {
        //PhysicsBody pb = GetComponent<PhysicsBody>();
        PhysicsBody cubePB = cube.GetComponent<PhysicsBody>();

        Vector3 finalVelocity;
        transform.position -= velocity * Time.deltaTime; // reposition
        if (cube.tag == "Floor")
        {
            velocity.y *= -1f * restitution;
            
            // Gave a min threshold value for velocity
            // so when it goes lower to that, v = 0, and ball will stop moving
            if (velocity.y <= 0.15)
            {
                //Debug.Break();
                //Debug.Log("Landed and less than 1.0f");
                velocity.y = 0.0f;
                
                // Experimenting with acceleration a bit. 
                acceleration.y = 0.0f;
            }
        }
        else if (cube.tag == "WallZ")
        {
            // check which direction of z and x axis and then perform the rebound
            velocity.z *= -1 * restitution;
            //if (velocity.z < 0)
            //{
            //    sphere.transform.position.z -= sphere.getRadius();
            //}
            
              
        }
        else if (cube.tag == "WallX")
        {
            velocity.x *= -1 * restitution;
        }
        else
        {
           // Debug.Break();
            finalVelocity =
                ((mass - cubePB.mass) / (mass + cubePB.mass)) * velocity
                + ((2 * cubePB.mass) / (mass + cubePB.mass)) * cubePB.velocity;
            velocity = finalVelocity * restitution;
        }
    }

    // using the impulse formula
    public void CollisionResponseCube(CubeBehaviour cube, Vector3 normal)
    {
        //PhysicsBody pb = GetComponent<PhysicsBody>();
        PhysicsBody cubePB = cube.GetComponent<PhysicsBody>();

        Vector3 finalVelocity;
        transform.position -= velocity * Time.deltaTime; // reposition
        if (cube.tag == "Floor")
        {
            velocity.y *= -1f * restitution;

            // Gave a min threshold value for velocity
            // so when it goes lower to that, v = 0, and ball will stop moving
            if (velocity.y <= 0.15)
            {
                //Debug.Break();
                //Debug.Log("Landed and less than 1.0f");
                velocity.y = 0.0f;

                // Experimenting with acceleration a bit. 
                acceleration.y = 0.0f;
            }
        }
        else if (cube.tag == "WallZ")
        {
            // check which direction of z and x axis and then perform the rebound
            velocity.z *= -1 * restitution;
            //if (velocity.z < 0)
            //{
            //    sphere.transform.position.z -= sphere.getRadius();
            //}
        }
        else if (cube.tag == "WallX")
        {
            velocity.x *= -1 * restitution;
        }
        else
        {

        }
    }

    public void CollisionResponseSphere(SphereProperties sphere)
    {
        PhysicsBody spheresPB = sphere.GetComponent<PhysicsBody>();

        Vector3 finalVelocity;
        finalVelocity =
              ((mass - spheresPB.mass) / (mass + spheresPB.mass)) * velocity
              + ((2 * spheresPB.mass) / (mass + spheresPB.mass)) * spheresPB.velocity;
        velocity = finalVelocity * restitution;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Control the speed of the Asteroid")]
    public float maxSpeed;
    public float minSpeed;

    [Header("Control the rotational speed")]
    public float rotationalMaxSpeed;
    public float rotationalMinSpeed;

    private float rotationalSpeed;
    private float xAngle, yAngle, zAngle;

    public Vector3 movementDirection;

    private float asteroidSpeed;

    void Start()
    {
        //get a random speed
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        //get a random rotation
        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.Rotate(xAngle, yAngle, zAngle);

        rotationalSpeed = Random.Range(rotationalMinSpeed, rotationalMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * asteroidSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up * rotationalSpeed * Time.deltaTime);
    }
}

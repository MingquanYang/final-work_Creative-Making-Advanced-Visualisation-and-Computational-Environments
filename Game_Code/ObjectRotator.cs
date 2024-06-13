using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 50f, 0f); // rotation angle per second

    void Update()
    {
        //rotate the object
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class CarEngine : MonoBehaviour
{
    public Transform path1;
    public Transform path2;
    private List<Transform> nodes;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public Vector3 centerOfMass;

    private int currentNode=0;
    public float maxSteerAngle=30f;
    private float maxMotorTorque = 1500f;
    public float maxBrakeTorque = 50f;
    public float currentSpeed=0;
    public float maxSpeed=100f;
    public bool isBraking ;


    // Start is called before the first frame update
    void Start()
    {
        Transform returnedPath = DecidingPath(path1, path2);
        Debug.Log(returnedPath);
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        Transform[] pathTransforms = returnedPath.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != returnedPath.transform)
            {
               // Debug.Log(pathTransforms[i].name);
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWayPointDistance();
        Braking();
    }
    void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
       // Debug.Log(relativeVector);
        
       float maxSteer = (relativeVector.x /relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle=maxSteer;
        wheelFR.steerAngle = maxSteer;


    }
    void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 100;
        if (currentSpeed < maxSpeed && !isBraking)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
    }
    void CheckWayPointDistance()
    {
        //Debug.Log(Vector3.Distance(transform.position, nodes[currentNode].position));
        if(Vector3.Distance(transform.position, nodes[currentNode].position) <3f)
        {
            
            if(currentNode==nodes.Count-1)
            {
                //Debug.Log("Reached the end of the path. Current node: " + nodes[currentNode].name);
                currentNode = 0;
            }
            else
            { 
                currentNode++;
                //Debug.Log("Moved to the next node. Current node: " + nodes[currentNode].name);
            }
        }
        
    }
    void Braking()
    {
        if (isBraking)
        {
            wheelRL.brakeTorque = maxBrakeTorque;
            wheelRR.brakeTorque = maxBrakeTorque;
        }
        else {
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }
    }
    Transform DecidingPath(Transform path1, Transform path2)
    {
        int random = Random.Range(0, 2); 
        Debug.Log(random);
        if(random == 0)
        {
            return path1;
        }
            return path2; 
        
        
    }
    
}

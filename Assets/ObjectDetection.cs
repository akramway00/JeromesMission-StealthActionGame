using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    public GameObject target;
    public float detectionDistance = 5f;
    public float detectionAngle = 40f;
    private Animator animation;


    void Start()
    {
        animation = GetComponent<Animator>();

    }

    void Update()
    {
        DetectTarget();
    }

    void DetectTarget()
    {
        Vector3 directionToTarget = target.transform.position - transform.position; 
        float distanceToTarget = directionToTarget.magnitude; 

        if (distanceToTarget <= detectionDistance) 
        {
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget.normalized);

            if (angleToTarget <= detectionAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToTarget, out hit, detectionDistance))
                {
                    if (hit.transform.gameObject == target)
                    {
                        animation.SetBool("faint", true);
                    }

                    else
                    {
                        animation.SetBool("faint", false);
                    }
                }
            }
        }
    }
}

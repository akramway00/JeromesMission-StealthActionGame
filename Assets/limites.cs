using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limites : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}

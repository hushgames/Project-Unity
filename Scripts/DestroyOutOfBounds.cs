using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 21.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound) {
            Destroy(gameObject);
        }
        else if (transform.position.z < -topBound) {
            Destroy(gameObject);
        }
    }
}

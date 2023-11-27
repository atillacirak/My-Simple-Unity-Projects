using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private float lowerBound = -10.0f;
    private float topBound = 30.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound){
            Destroy(gameObject);
        }
        if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeRequired = 2.0f;
    private float timeNow;

    // Update is called once per frame
    void Update()
    {
        timeNow -= Time.deltaTime;
        // On spacebar press, send dog
        if (timeNow <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeNow = timeRequired;
        }
    }
}

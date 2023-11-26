using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float horizontal_input;
    private float boundry = 10.0f;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        horizontal_input = Input.GetAxis("Horizontal"); 
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontal_input);

        if (transform.position.x < -boundry){
            transform.position = new Vector3(-boundry, transform.position.y, transform.position.z);
        }
        if (transform.position.x > boundry){
            transform.position = new Vector3(boundry, transform.position.y, transform.position.z);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
    }
}

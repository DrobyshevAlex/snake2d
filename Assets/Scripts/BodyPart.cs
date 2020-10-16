using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public GameObject parentObject;
    public SnakeController snakeController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        parentObject.transform.LookAt(parentObject.transform);
        transform.position = Vector3.Lerp(transform.position, parentObject.transform.position, Time.deltaTime * snakeController.speed * 3.0f);
    }
}

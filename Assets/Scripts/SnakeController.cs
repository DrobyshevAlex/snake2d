using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    List<GameObject> parts = new List<GameObject>();
    float currentRotation = 0.0f;
    FoodManager foodManager;

    public GameObject bodyPart;

    public float speed = .1f;
    public float speedRotation = 3.0f;
    public float offsetPart = .1f;

    // Start is called before the first frame update
    void Start()
    {
        parts.Add(gameObject);
        foodManager = GameObject.Find("FoodManager").GetComponent<FoodManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation -= Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime;
        UpdateMove();
    }

    private void FixedUpdate()
    {
        //UpdateMove();
    }

    private void UpdateMove()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        int size = parts.Count - 1;
        for (int i = size; i > size / 2; --i)
        {
            Destroy(parts[i]);
            parts.RemoveAt(i);
        }
        currentRotation = 0.0f;
        transform.position = new Vector3(0, -4, 0);
        speed = 0.8f + 0.1f * parts.Count;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("FoodItem"))
        {
            Destroy(collision.gameObject);
            GameObject parent = parts[parts.Count - 1];
            Vector3 pos = parent.transform.position;

            pos.z -= offsetPart;
            GameObject bodyPartObj = GameObject.Instantiate(bodyPart, pos, Quaternion.identity) as GameObject;
            BodyPart bodyPartScript = bodyPartObj.GetComponent<BodyPart>();
            bodyPartScript.parentObject = parent;
            bodyPartScript.snakeController = GetComponent<SnakeController>();

            this.parts.Add(bodyPartObj);
            speed += 0.1f;
            foodManager.Add();
        }
    }
}

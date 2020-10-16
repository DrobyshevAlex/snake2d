using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject foodItem;
    private float width = 8.0f;
    private float height = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; ++i)
        {
            Add();
        }
    }

    public void Add()
    {
        Vector3 pos = new Vector3(Random.Range(width * -1, width), Random.Range(height * -1, height), 0);
        GameObject.Instantiate(foodItem, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

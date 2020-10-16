using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/fruits");
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

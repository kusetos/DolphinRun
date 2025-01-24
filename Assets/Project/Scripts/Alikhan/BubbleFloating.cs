using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFloating : MonoBehaviour
{
    public float DestroyTime = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        float DestroyRandom = Random.Range(DestroyTime - 5, DestroyTime + 5);

        Destroy(gameObject, DestroyRandom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

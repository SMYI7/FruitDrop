using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.1f ,0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

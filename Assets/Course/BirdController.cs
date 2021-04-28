using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed;

    private Rigidbody _body;
    
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            print("left mouse is clicked");
        }
    }

    private void FixedUpdate()
    {
        var velocity = _body.velocity;
        velocity.x = speed;
        _body.velocity = velocity;
    }
}

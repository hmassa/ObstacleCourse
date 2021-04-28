using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _body;
    public float speed;
    public float acceleration = 25;
    public float jumpVelocity = 7;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var velocity = _body.velocity;
            if(_body.position.y < 3.5) {
               velocity.y = jumpVelocity;
            }
            _body.velocity = velocity;
        }
    }

    private void FixedUpdate()
    {
        var targetVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            targetVelocity.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            targetVelocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            targetVelocity.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetVelocity.x += 1;
        }

        targetVelocity = targetVelocity.normalized;
        targetVelocity *= speed;
        targetVelocity = new Vector3(targetVelocity.x, _body.velocity.y, targetVelocity.z);
        _body.velocity = Vector3.MoveTowards(_body.velocity, targetVelocity, (acceleration * Time.deltaTime));
    }
}

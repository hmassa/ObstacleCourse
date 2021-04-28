using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var flatVelocity = body.velocity;
        flatVelocity.y = 0;

        var flatSpeed = flatVelocity.magnitude;
        var bodyHeight = body.position.y;
        bool isRunning = flatSpeed > 0.001f;

        bool isFalling = bodyHeight < .05f;
        _animator.SetBool("isFalling", isFalling);


        _animator.SetBool("isRunning", isRunning);

        if (isRunning)
        {
            var direction = Quaternion.LookRotation(flatVelocity);
            body.MoveRotation(direction);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (body.position.y < 5)
            {
                _animator.SetTrigger("jump");

            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _animator.SetTrigger("slide");

        }
    }
}

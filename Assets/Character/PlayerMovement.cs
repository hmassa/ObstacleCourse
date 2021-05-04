using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _body;
    public float speed;
    public float acceleration = 25;
    public float jumpVelocity = 7;
    public Transform capsuleTransform;
    public Text countdowntext;


    IEnumerator Roll()
    {

        var temp = new Vector3(capsuleTransform.localScale.x, 0.4f, capsuleTransform.localScale.z);
        var normal = new Vector3(capsuleTransform.localScale.x, 0.9f, capsuleTransform.localScale.z);

        capsuleTransform.localScale = temp;

        yield return new WaitForSeconds(2f);

        capsuleTransform.localScale = normal;

    }
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
        bool isCountingDown = countdowntext.text == "GO";


        if (Input.GetKey(KeyCode.W) && isCountingDown)
        {
            targetVelocity.z += 1;
        }
        if (Input.GetKey(KeyCode.A) && isCountingDown)
        {
            targetVelocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.S) && isCountingDown)
        {
            targetVelocity.z -= 1;
        }
        if (Input.GetKey(KeyCode.D) && isCountingDown)
        {
            targetVelocity.x += 1;
        }
        if (Input.GetKey(KeyCode.Return) && isCountingDown)
        {
            StartCoroutine(Roll());

        }

        targetVelocity = targetVelocity.normalized;
        targetVelocity *= speed;
        targetVelocity = new Vector3(targetVelocity.x, _body.velocity.y, targetVelocity.z);
        _body.velocity = Vector3.MoveTowards(_body.velocity, targetVelocity, (acceleration * Time.deltaTime));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    public Rigidbody body;
    public Text deathcounter;
    public Text levelCounter;
    public ScoreScript score;

    IEnumerator DeathScene()
    {

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        score = new ScoreScript();
        levelCounter.text = "Level: " + score.get().ToString();
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
        bool nextLevel = bodyHeight < -20f;
        bool isDead = deathcounter.text == "00";

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
        if(nextLevel)
        {
            score.increment();
            SceneManager.LoadScene("SampleScene");
        }
        if (isDead)
        {
            score.reset();
            _animator.SetTrigger("death");

            StartCoroutine(DeathScene());

        }
    }
}

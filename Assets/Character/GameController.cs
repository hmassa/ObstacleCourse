using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int countdownTime;
    public Text countdownDisplay;

    public int deathTime;
    public Text deathDisplay;

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        countdownDisplay.text = "GO";

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);

        StartCoroutine(DeathToStart());

    }
    IEnumerator DeathToStart()
    {
        while (deathTime > 0)
        {
            deathDisplay.text = deathTime.ToString();

            yield return new WaitForSeconds(1f);

            deathTime--;
        }

        deathDisplay.text = "00";

        yield return new WaitForSeconds(.01f);

        deathDisplay.text = "YOU LOSE";

        yield return new WaitForSeconds(1f);


        deathDisplay.gameObject.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

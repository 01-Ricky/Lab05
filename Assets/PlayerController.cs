using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public GameObject coineffect;
    public Text cointext;
    public float coinscore;

    public Text Timertext;
    private float TimerValue;
    public float timeleft;

    public int timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        coinscore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeleft % 60);
        Timertext.text = "Timer: " + timeRemaining.ToString();
        cointext.text = "Coin: " + coinscore;


        if (coinscore == 70)
        {          
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
                SceneManager.LoadScene("GameWinScene");     

        }
       if (timeleft <= 0)
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
            SceneManager.LoadScene("GameLoseScene");

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinscore += 10;
            Destroy(other.gameObject);
            Destroy(Instantiate(coineffect, other.transform.position, Quaternion.identity), 4);
        }
        if (other.gameObject.tag == "Water")
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
            SceneManager.LoadScene("GameLoseScene");

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{

    public Text cointext;
    public float coinscore;

    // Start is called before the first frame update
    void Start()
    {
        coinscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = "Coin: " + coinscore;

        if (coinscore>=70)
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
            SceneManager.LoadScene("GameWinScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinscore += 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Water")
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
            SceneManager.LoadScene("GameLoseScene");

        }
    }
}

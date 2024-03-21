using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerandSound2 : MonoBehaviour
{
    public TextMeshPro timerText;
    public float remainingTime;
    private float initialCountdown = 0f;
    private bool countdownFinished = false;
    public AudioClip audioClip;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; 
    }

    public void StartTimer()
    {
        remainingTime = 15f;
        countdownFinished = false;
        audioSource.Play();
        StartCoroutine(InitialCountdown());
    }

    IEnumerator InitialCountdown()
        {
            while (initialCountdown > 0)
            {
                timerText.text = initialCountdown.ToString();
                initialCountdown -= 1;
                yield return new WaitForSeconds(1);
            }

            countdownFinished = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (countdownFinished)
            {
                remainingTime -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(remainingTime / 60f);
                int seconds = Mathf.FloorToInt(remainingTime % 60f);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                if (remainingTime <= 0)
                {
                    timerText.fontSize = 6;
                    timerText.text = "Time's up!";

                    audioSource.Stop();
                }
            }
        }
}

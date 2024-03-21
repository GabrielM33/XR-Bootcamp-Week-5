using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public Animation anim;
    public TextMeshPro score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            anim.Play();
            score.text = (Int32.Parse(score.text) + 1).ToString();
                
        }
    }
}

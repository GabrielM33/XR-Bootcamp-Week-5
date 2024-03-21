using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBulletEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBulletEvent(ActivateEventArgs args)
    {
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.up * fireSpeed;
        Destroy(spawnedBullet, 5);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    CoinHUD coinDisplay;
    public AudioClip coinSFX;
    AudioSource sourceSFX;

    private void Awake()
    {
        coinDisplay = GameObject.Find("CoinDisplay").GetComponent<CoinHUD>();
    }

    // Start is called before the first frame update
    void Start()
    {
        coinSFX = Resources.Load<AudioClip>("coinPickup");
        sourceSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        transform.Rotate(0,0,1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sourceSFX.PlayOneShot(coinSFX);
            coinDisplay.CoinCollected();
            transform.position = new Vector3(0, -10000, 0);
            Destroy(gameObject, 0.5f);
        }
    }
}

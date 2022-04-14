using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormove : MonoBehaviour
{
    public bool right=false;
    private AudioSource audioSource;
    public AudioClip doorOpeningClip;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the audio source for later
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (right == true)
        {
            transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }
        if (transform.position.x >5)
        {
            pc.keycounter = 1;
            pc.keytext.text = "" + pc.keycounter;
            Destroy(gameObject);

        }
    }
    public void DoorMove()
    {
        right = true;
        audioSource.clip = doorOpeningClip;
        audioSource.Play();

    }
   
}

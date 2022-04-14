using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void Start()
    {
		// Set up the audio source for later
	}


    void Update () {
		// Animate the coin rotating
		transform.Rotate(0.0f, 1.0f, 0.0f);
	}

}

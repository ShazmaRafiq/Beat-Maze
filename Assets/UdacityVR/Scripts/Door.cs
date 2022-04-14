using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour {

	public GameObject leftDoor;
	public GameObject rightDoor;

	// For playing sounds at the door
	private AudioSource audioSource;

	// The actual sould clips
	public AudioClip doorOpeningClip;
	public AudioClip doorLockedClip;

	// Door state
	private bool locked = true;
	private bool opening = false;

	// For animating the door
	private Quaternion leftDoorStartRotation;
	private Quaternion leftDoorEndRotation;
	private Quaternion rightDoorStartRotation;
	private Quaternion rightDoorEndRotation;

	// Time elapsed and duration of the door anmimation
	private float timer = 0.0f;
	private float rotationTime = 5.0f;

	void Start () {
		// Set up the audio source for later
		audioSource = GetComponent<AudioSource>();

		// Set up rotations
		leftDoorStartRotation = leftDoor.transform.rotation;
		leftDoorEndRotation = leftDoorStartRotation * Quaternion.Euler (0.0f, 0.0f, 70.0f);
		rightDoorStartRotation = rightDoor.transform.rotation;
		rightDoorEndRotation = rightDoorStartRotation * Quaternion.Euler (0.0f, 0.0f, -70.0f);
	}

	void Update () {
		if (opening) {
			timer += Time.deltaTime;
			leftDoor.transform.rotation = Quaternion.Slerp (leftDoorStartRotation, leftDoorEndRotation, timer / rotationTime);
			rightDoor.transform.rotation = Quaternion.Slerp (rightDoorStartRotation, rightDoorEndRotation, timer / rotationTime);
		}
	}

	public void OnDoorClicked () {
		// Prints to the console when the method is called
		Debug.Log ("'Door.OnDoorClicked()' was called");

		if (!locked) {
			opening = true;

			audioSource.clip = doorOpeningClip;
			audioSource.Play ();

			EventTrigger eventTrigger = GetComponent<EventTrigger> ();
			eventTrigger.enabled = false;
		} else {
			audioSource.clip = doorLockedClip;
			audioSource.Play ();
		}
	}

	public void Unlock () {
		// Prints to the console when the method is called
		Debug.Log ("'Door.Unlock()' was called");

		locked = false;
	}
}

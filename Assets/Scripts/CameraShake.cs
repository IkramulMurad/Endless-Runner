using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	private GameObject player;
	private Vector3 initialDistance;

	// Transform of the camera to shake. Grabs the gameObject's transform if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 2.0f;
	private float shakeDurationStore;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.5f;
	public float decreaseFactor = 1.0f;

	public bool shaketrue= false;

	Vector3 originalPos;

	void Awake() {
		if (camTransform == null) {
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable() {
		originalPos = camTransform.localPosition;
	}

	// Use this for initialization
	void Start () {
		shakeDurationStore = shakeDuration;
		player = GameObject.FindGameObjectWithTag("Player");
		initialDistance = gameObject.GetComponent<CameraMotor>().initialDistance;
	}


	// Update is called once per frame
	void Update() {
		if (shaketrue) {
			if (shakeDuration > 0) {
				Vector3 pos = originalPos + Random.insideUnitSphere * shakeAmount;
				pos.z = player.transform.position.z + initialDistance.z;
				camTransform.localPosition = pos;
				shakeDuration -= Time.deltaTime * decreaseFactor;
			} else {
				shakeDuration = shakeDurationStore;
				camTransform.localPosition = originalPos;
				shaketrue = false;
			}
		}
	}

	public void shakecamera() {
		shaketrue = true;
	}
}

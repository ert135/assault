using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] float xSpeed = 4f;
    [SerializeField] float ySpeed = 4f;
    [SerializeField] float xConstraint = 6f;
    [SerializeField] float yConstraint = 6f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 4.5f;
    [SerializeField] float controlRollFactor = -20f;
    float xOffsetValue;
    float yOffsetValue;
    float xThrow;
    float yThrow;

    // Use this for initialization
    void Start () {

	}

    void processTranslation()
    {
        this.xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        this.xOffsetValue = this.xThrow * this.xSpeed * Time.deltaTime;
        float rawNewXPosition = transform.localPosition.x + xOffsetValue;
        float finalPositionX = Mathf.Clamp(rawNewXPosition, -xConstraint, xConstraint);

        transform.localPosition = new Vector3(finalPositionX, transform.localPosition.y, transform.localPosition.z);

        this.yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        this.yOffsetValue = this.yThrow * this.ySpeed * Time.deltaTime;
        float rawNewYPosition = transform.localPosition.y + yOffsetValue;
        float finalPositionY = Mathf.Clamp(rawNewYPosition, -yConstraint, yConstraint);

        transform.localPosition = new Vector3(transform.localPosition.x, finalPositionY, transform.localPosition.z);
    }

    void processRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * this.positionPitchFactor;
        float pitchDueToControlThrow = this.yThrow * this.controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * this.positionYawFactor;
        float roll = this.xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
	
	// Update is called once per frame
	void Update () {
        this.processTranslation();
        this.processRotation();
    }
}

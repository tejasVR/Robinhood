using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;

    public GameObject cameraRig;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("hi!");

        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {

            
            //Rigidbody r = cameraRig.GetComponent<Rigidbody>();

            Vector2 touchpad;

            touchpad = device.GetAxis();
            cameraRig.transform.position = cameraRig.transform.position + new Vector3(touchpad.x / 80f, 0f, touchpad.y / 80f);

            // = Vector3.Lerp(cameraRig.transform.position, direction, Time.deltaTime /2);
            //if (camera)

            //Debug.Log(cameraRig.transform.position);
            //r.AddForce(force);


        }

        /*if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {


            //Rigidbody r = cameraRig.GetComponent<Rigidbody>();

            Vector2 touchpad;

            touchpad = device.GetAxis();
            Vector3 direction = cameraRig.transform.position + new Vector3(-touchpad.x / 10, 0f, -touchpad.y / 10);

            cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, direction, 10f);

            Debug.Log(cameraRig.transform.position);
            //r.AddForce(force);


        }*/

    }
}

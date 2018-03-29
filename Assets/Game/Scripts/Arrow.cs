using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    bool isAttached = false;
    private bool isFired = false;


    private void OnTriggerStay(Collider other)
    {
        AttachArrow();
    }

    private void OnTriggerEnter(Collider other)
    {
        AttachArrow();
    }

    void Update()
    {
        if (isFired)
        {
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }

    public void Fired()
    {
        isFired = true;
    }

    private void AttachArrow()
    {
        var device = SteamVR_Controller.Input((int)ArrowManager.Instance.trackedObj.index);
        if (!isAttached && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            ArrowManager.Instance.AttatchBowToArrow();
            isAttached = true;
        }
    }
}

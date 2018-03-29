using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    public static ArrowManager Instance;
    public GameObject arrowPrefab;
    public GameObject stringAttatchPoint;
    public GameObject arrowStartPoint;
    public GameObject stringStartPoint;
    public SteamVR_TrackedObject trackedObj;


    private GameObject currentArrow;
    private bool isAttached = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AttackArrow();
        PullString();
	}

    private void PullString()
    {
        if (isAttached)
        {
            float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
            stringAttatchPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3((5f * Mathf.Abs(dist))+1.416228f, 0f, 1.416228f);

            var device = SteamVR_Controller.Input((int)trackedObj.index);
            if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;

        currentArrow.transform.parent = null;
        currentArrow.GetComponent<Arrow>().Fired();
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        r.velocity = currentArrow.transform.forward * 13f * dist;
        r.useGravity = true;

        stringAttatchPoint.transform.position = stringStartPoint.transform.position;

        currentArrow = null;
        isAttached = false;

    }

    private void AttackArrow()
    {
        if (currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, .342f);
            currentArrow.transform.localRotation = Quaternion.identity;

        }
    }

    public void AttatchBowToArrow()
    {
        currentArrow.transform.parent = stringAttatchPoint.transform;
        currentArrow.transform.position = arrowStartPoint.transform.position;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

        isAttached = true;
    }
}

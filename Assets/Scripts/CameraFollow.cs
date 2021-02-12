using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public GameObject stick;
    public Vector3 offset;
    public float smoothSpeed = 0.25f;

    void Start()
    {
        offset = new Vector3(0, 5, 0);
    }
	// -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- 
	void Update()
    {
        Vector3 desiredPosition = new Vector3(0,target.transform.position.y,target.transform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(new Vector3(0,transform.position.y,transform.position.z), desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

		if (FindObjectOfType<PlayerAnimator>().stick.transform.localScale.y >= 2.2f)
		{
			offset = new Vector3(0, 7, -5);
			Vector3 newDesiredPosition = new Vector3(0, target.transform.position.y, target.transform.position.z) + offset;
			Vector3 newSmoothedPosition = Vector3.MoveTowards(new Vector3(0, transform.position.y, transform.position.z), newDesiredPosition, smoothSpeed * Time.deltaTime);
			transform.position = newSmoothedPosition;
		}
		else
		{
			offset = new Vector3(0, 5, -1);
			Vector3 newDesiredPosition = new Vector3(0, target.transform.position.y, target.transform.position.z) + offset;
			Vector3 newSmoothedPosition = Vector3.MoveTowards(new Vector3(0, transform.position.y, transform.position.z), newDesiredPosition, smoothSpeed * Time.deltaTime);
			transform.position = newSmoothedPosition;
		}
	}
}

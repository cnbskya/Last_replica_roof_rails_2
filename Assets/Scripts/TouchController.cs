using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchController : MonoBehaviour

	, IPointerDownHandler // parmak üstüne geldiğinde tek sefer çalışır // onpointerenter / onpointerup
	, IDragHandler // Üstünde input kaydığı sürece update gibi çalışır 
{

	public static TouchController instance;

	private Vector3 firstTouchPos;
	private Vector3 dragPos;
	public float sens;

	private void Awake()
	{
		instance = this;
	}
	private void CheckMovement()
	{
		//if (Defines.IS_GAMEFINISH) return;

		Vector3 distanceVal = dragPos - firstTouchPos;

		if (Vector3.Distance(firstTouchPos, dragPos) >= 20f)
		{
			firstTouchPos = dragPos;

			if (Mathf.Abs(distanceVal.x) >= Mathf.Abs(distanceVal.y)) // horizontal movement
			{
				if(FindObjectOfType<PlayerAnimator>().largeClamp == false)
				{
					Vector3 targetpos = CharacterControlScript.instance.transform.position;
					targetpos += Vector3.right * distanceVal.x * Time.deltaTime * sens;
					targetpos.x = Mathf.Clamp(targetpos.x, -2.25f, 2.25f);
					CharacterControlScript.instance.transform.position = targetpos;
				}else if (FindObjectOfType<PlayerAnimator>().largeClamp == true)
				{
					Vector3 targetpos = CharacterControlScript.instance.transform.position;
					targetpos += Vector3.right * distanceVal.x * Time.deltaTime * sens;
					targetpos.x = Mathf.Clamp(targetpos.x, -3.5f, 3.5f);
					CharacterControlScript.instance.transform.position = targetpos;
				}
				
			}
		}
	}
	public void OnPointerDown(PointerEventData data)
	{
		firstTouchPos = data.position;
	}
	public void OnDrag(PointerEventData data)
	{
		dragPos = data.position;
		CheckMovement();
	}

}

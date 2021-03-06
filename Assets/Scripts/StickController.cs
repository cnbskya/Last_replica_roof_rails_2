﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
	public Transform xBotRunning;
	public GameObject targetGhost;
	public List<GameObject> liste = new List<GameObject>();
	public ParticleSystem electric;
	public Transform particleLeft;
	public Transform particleRight;
	public GameObject diamond;
	public float lerpTime = 10f;
	public bool relocationBool = false;
	public float speed;
	public float relocaionTime;
	void Start()
	{

	}

	private void Update()
	{
		if (relocationBool == true)
		{
			Invoke("Relocation", relocaionTime);
		}

		if (GameManager.instance.isSlide == true)
		{
			if (GameManager.instance.isGameOn)
			{
				Vector3 newLerpPosition = new Vector3(targetGhost.transform.position.x, transform.position.y, targetGhost.transform.position.z);
				transform.position = Vector3.Lerp(transform.position, newLerpPosition, Time.deltaTime * 8);
			}
		}

	}
	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Saw"))
		{
			other.GetComponent<Collider>().enabled = false;
			float triggerPointX = other.transform.position.x;
			float sawScale = other.transform.localScale.x;
			float differenceValue = transform.position.x - other.gameObject.transform.position.x;

			float largePartScale = transform.localScale.y / 2 + differenceValue / 2;
			float smallPartScale = transform.localScale.y - largePartScale;


			float smallPartXPos = other.gameObject.transform.position.x - smallPartScale;
			float largePartXPos = other.gameObject.transform.position.x + largePartScale;


			Vector3 stickPos = transform.position;
			Vector3 smallPartPos = new Vector3(smallPartXPos, stickPos.y, stickPos.z);
			Vector3 largePartPos = new Vector3(largePartXPos, stickPos.y, stickPos.z);

			// Kesilen parçalar smallParttan küçükse bir problem yok. Ama SmallPart LargeParttan büyük olduğu senaryoda sıkıntı var // FİXED (Canbaşkaya)
			GameObject smallPart = Instantiate(gameObject);
			smallPart.GetComponent<Rigidbody>().useGravity = true;
			Destroy(smallPart, 1f);

			if (other.gameObject.transform.position.x < targetGhost.transform.position.x)
			{
				smallPart.transform.localScale = new Vector3(smallPart.transform.localScale.x, smallPartScale, smallPart.transform.localScale.z);
				transform.localScale = new Vector3(transform.localScale.x, largePartScale, transform.localScale.z);

				smallPart.transform.position = smallPartPos;
				transform.position = largePartPos;
				relocationBool = true;
			}
			else
			{
				smallPart.transform.localScale = new Vector3(smallPart.transform.localScale.x, largePartScale, smallPart.transform.localScale.z);
				transform.localScale = new Vector3(transform.localScale.x, smallPartScale, transform.localScale.z);

				smallPart.transform.position = largePartPos;
				transform.position = smallPartPos;
				relocationBool = true;
			}
			other.gameObject.GetComponent<Collider>().enabled = false;

		}

		if (other.gameObject.CompareTag("Diamond"))
		{
			Debug.Log(Camera.main.WorldToScreenPoint(other.gameObject.transform.position));
			Debug.Log(" Wiewport Point: " + Camera.main.WorldToViewportPoint(other.gameObject.transform.position));
			Destroy(other.gameObject);

		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("SlideStick"))
		{
			FindObjectOfType<CharacterControlScript>().speed = 10.5f;
		}
	}

	public void Relocation()
	{
		transform.position = Vector3.Lerp(transform.position, new Vector3(xBotRunning.position.x, transform.position.y, transform.position.z), lerpTime * Time.deltaTime);
		relocationBool = false;
	}

	


}

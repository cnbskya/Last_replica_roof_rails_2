using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Saw : MonoBehaviour
{
	void Start()
	{
		StartRotateObject();
	}
	public void StartRotateObject()
	{
		gameObject.transform.DORotate(new Vector3(180, 0, 0), 1).SetLoops(-1).SetEase(Ease.Linear);
	}
}

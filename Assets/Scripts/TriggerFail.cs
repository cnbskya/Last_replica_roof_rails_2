using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFail : MonoBehaviour
{
	public GameObject xBot;
	public GameObject targetGhost;
	public bool ayrildi;

	private void Start()
	{
		
	}
	private void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.CompareTag("Player"))
		{
			ayrildi = true;
			xBot.AddComponent<Rigidbody>();
			xBot.GetComponent<Rigidbody>().velocity = Vector3.forward * 300 * Time.deltaTime;
			FindObjectOfType<PlayerAnimator>().transform.SetParent(null);
            Debug.Log("ÇÖZDÜM");
		}
	}
}

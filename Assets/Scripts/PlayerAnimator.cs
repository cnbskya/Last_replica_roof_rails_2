using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	public GameObject[] levelFinishBonus;
	public GameObject targetGhost;
	public GameObject stick;
	public GameObject piece;
	public Transform right, left;
	public bool largeClamp;

	Animator animator;
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update()
	{
		if (GameManager.instance.isSlide == false)
		{
			transform.position = Vector3.Lerp(transform.position, targetGhost.transform.position, Time.deltaTime * 8);
		}

	}

	// FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED 
	private void OnTriggerEnter(Collider other)
	{
		// BONUS
		CheckBonus(other);
		// SLİDE PROCES
		CheckSlide(other);
		//FİNİSH BONUS PROCESS
		CheckFinishBonus(other);
	}

	private void OnTriggerExit(Collider other)
	{
		if ((other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("GroundEnd")) && GameManager.instance.isSlide == false)
		{
			
			GameManager.instance.isSlide = true;
			// PARENT CHANGE
			stick.transform.SetParent(null);
			gameObject.transform.SetParent(stick.transform);
			// STİCK TRİGGER AND RİGİDBODY PROCESS
			stick.GetComponent<Collider>().isTrigger = false;
			stick.GetComponent<Rigidbody>().useGravity = true;

			Rigidbody targetRb =  targetGhost.AddComponent<Rigidbody>();
			targetRb.angularDrag = 0.65f;
		}
	}

	// FUNCTIONS
	public void CheckBonus(Collider other)
	{

		if (other.gameObject.CompareTag("Bonus"))
		{
			stick.transform.localScale += new Vector3(0, 0.2f, 0);
			Destroy(other.gameObject);
		}

		else if (other.gameObject.CompareTag("LavBlock"))
		{

			if (stick.transform.localScale.y >= 0.2f)
			{
				stick.transform.localScale -= new Vector3(0, 0.2f, 0);
				GameObject go1 = Instantiate(piece, right.transform.position, right.transform.rotation);
				GameObject go2 = Instantiate(piece, left.transform.position, left.transform.rotation);
				Destroy(go1, 1f);
				Destroy(go2, 1f);
			}
			else
			{
				return;
			}
		}
		
	}
	public void CheckSlide(Collider other)
	{
		// KAYMA İŞLEMİ BİTİNCE 
		if (other.gameObject.CompareTag("Ground") && GameManager.instance.isSlide == true)
		{
			largeClamp = false;
			FindObjectOfType<CharacterControlScript>().speed = 8.5f;
			Destroy(targetGhost.GetComponent<Rigidbody>());
			targetGhost.transform.position = new Vector3(targetGhost.transform.position.x, other.gameObject.transform.position.y + other.gameObject.transform.localScale.y/2 , targetGhost.transform.position.z);

			// PARENT CHANGE
			GameManager.instance.isSlide = false;
			gameObject.transform.SetParent(null);
			stick.transform.SetParent(gameObject.transform);
			stick.transform.SetParent(gameObject.transform);

			// STİCK TRİGGER AND RİGİDBODY PROCESS
			stick.GetComponent<Collider>().isTrigger = true;
			stick.GetComponent<Rigidbody>().useGravity = false;
			stick.GetComponent<Rigidbody>().isKinematic = true;
			stick.GetComponent<Rigidbody>().isKinematic = false;
		}else if (other.gameObject.CompareTag("GroundEnd") && GameManager.instance.isSlide == true)
		{
			largeClamp = true;
			FindObjectOfType<CharacterControlScript>().speed = 7;
			Destroy(targetGhost.GetComponent<Rigidbody>());
			targetGhost.transform.position = new Vector3(targetGhost.transform.position.x, other.gameObject.transform.position.y + other.gameObject.transform.localScale.y / 2, targetGhost.transform.position.z);

			// PARENT CHANGE
			GameManager.instance.isSlide = false;
			gameObject.transform.SetParent(null);
			stick.transform.SetParent(gameObject.transform);

			// STİCK TRİGGER AND RİGİDBODY PROCESS
			stick.GetComponent<Collider>().isTrigger = true;
			stick.GetComponent<Rigidbody>().useGravity = false;
			stick.GetComponent<Rigidbody>().isKinematic = true;
			stick.GetComponent<Rigidbody>().isKinematic = false;
		}
		else if (other.gameObject.CompareTag("GroundBonus")) 
		{
			FindObjectOfType<CharacterControlScript>().speed = 7;
			Destroy(targetGhost.GetComponent<Rigidbody>());
			targetGhost.transform.position = new Vector3(targetGhost.transform.position.x, other.gameObject.transform.position.y + other.gameObject.transform.localScale.y / 2, targetGhost.transform.position.z);

			// PARENT CHANGE
			GameManager.instance.isSlide = false;
			gameObject.transform.SetParent(null);
			stick.transform.SetParent(gameObject.transform);
			// STİCK TRİGGER AND RİGİDBODY PROCESS
			stick.GetComponent<Collider>().isTrigger = true;
			stick.GetComponent<Rigidbody>().useGravity = false;
			stick.GetComponent<Rigidbody>().isKinematic = true;
			stick.GetComponent<Rigidbody>().isKinematic = false;
		}
	}

	public void CheckFinishBonus(Collider other)
	{
		if (other.gameObject.CompareTag("FinishBonus"))
		{
			// BONUSA ÇARPINCA YAPILACAK OLANLAR BURAYA YAZILACAK.
			GameManager.instance.isGameOn = false;
			gameObject.transform.SetParent(null);
			gameObject.transform.eulerAngles = Vector3.zero; // Karakter dik duruyor.
			stick.GetComponent<Rigidbody>().velocity = Vector3.forward * 500 * Time.deltaTime; // Çubuğa ileri yönlü tek bir sefer hız veriliyor. 

			for (int i = 0; i < levelFinishBonus.Length; i++)
			{
				if(other.gameObject.name == levelFinishBonus[i].gameObject.name)
				{
					Debug.Log(i);
					// BONUS AYARLAMA İŞLERİM İ DEĞİŞKENİ ÜZERİNDEN YAPILACAK
				}
			}
		}
	}
}



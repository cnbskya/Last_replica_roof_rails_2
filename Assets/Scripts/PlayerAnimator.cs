using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	public Transform targetGhost;
	public GameObject stick;
	public GameObject piece;
	public Transform right, left;

	Animator animator;
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, targetGhost.position, Time.deltaTime * 8);
	}

	// FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- 
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bonus"))
		{
			stick.transform.localScale += new Vector3(0, 0.2f, 0);
			Destroy(other.gameObject);
		}
		// BURAYA BAKILACAK // COLLİSİON İLE YAPTIĞIM İÇİN BİRDEN FAZLASI AYNI ANDA TRİGGERLANABİLİYOR. // -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- FİXED -- 
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
}



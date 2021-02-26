using UnityEngine;

public class SlideStickController : MonoBehaviour
{
	public GameObject electricPrefab;
	private GameObject electric;
	private void OnCollisionStay(Collision collision)
	{
		electric.transform.position = collision.contacts[0].point;

	}

	private void OnCollisionEnter(Collision collision)
	{
		electric = Instantiate(electricPrefab);
	}

	private void OnCollisionExit(Collision collision)
	{
		var emission = electric.GetComponent<ParticleSystem>().emission;
		emission.enabled = false;
	}
}

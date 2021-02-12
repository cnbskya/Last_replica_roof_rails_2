using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlScript : MonoBehaviour
{
    public static CharacterControlScript instance;
    public Transform player;
    public int speed;
    //float velocity = 0.5f;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOn == true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;        
        }
    }

}

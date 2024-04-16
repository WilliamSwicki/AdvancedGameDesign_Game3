using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public GameObject player;
    public bool isCaptureing;
    public int captureRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move to the player
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,1,player.transform.position.z), speed * Time.deltaTime);
        if(isCaptureing )
        {
            player.GetComponent<PlayerScript>().capture -= (captureRate * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isCaptureing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isCaptureing = false;

        }
    }
}

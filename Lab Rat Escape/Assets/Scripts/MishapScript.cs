using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MishapScript : MonoBehaviour
{
    public GameObject puddle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Instantiate(puddle,new Vector3(this.transform.position.x,0,this.transform.position.z),Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

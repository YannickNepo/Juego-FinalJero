using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionManzana : MonoBehaviour
{
    public GameObject yo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(yo);
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionSerpiente : MonoBehaviour
{
    public Vector3 originalPosition;
    public GameObject perdiste;
    float tiempo;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = originalPosition;
        originalPosition = new Vector3(0, 1, 0);
        perdiste.SetActive(!perdiste.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tiempo + 1)
        {
            perdiste.SetActive(false);
        }
    }

    void OnCollisionExit(Collision col2)
    {
        if (col2.gameObject.name == "Piso")
        {
            perdiste.SetActive(true);
            gameObject.transform.position = originalPosition;
            tiempo = Time.time;
        }
    }
}

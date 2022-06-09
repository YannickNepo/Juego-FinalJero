using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSerpiente : MonoBehaviour
{
    public float MoveSpeed = 4;
    public float steerSpeed = 180;
    public GameObject CuerpoPrefab;
    public int gap = 10;
    public float VelocidadCuerpo = 4;
    public float xPos, zPos;
    public GameObject Manzanas;

    private List<GameObject> PartesCuerpo = new List<GameObject> ();
    private List<Vector3> PosicionSerpiente = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        CrecerSerpiente();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        float Control = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Control * steerSpeed * Time.deltaTime);



        PosicionSerpiente.Insert(0, transform.position);

        int index = 0;
        foreach (var Cuerpo in PartesCuerpo)
        {
            Vector3 point = PosicionSerpiente[Mathf.Min(index * gap, PosicionSerpiente.Count - 1)];
            Vector3 MoverDireccion = point - Cuerpo.transform.position;
            Cuerpo.transform.position += MoverDireccion * VelocidadCuerpo * Time.deltaTime;
            Cuerpo.transform.LookAt(point);
            index++;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        xPos = Random.Range(-14, 14);
        zPos = Random.Range(-10, 10);

        if (other.gameObject.tag == "Manzanas")
        {
            //Destroy(gameObject);
            CrecerSerpiente();
            Instantiate(Manzanas, new Vector3(xPos,1.01f, zPos), Quaternion.identity);
        }

    }
    private void CrecerSerpiente()
    {
        GameObject Cuerpo = Instantiate(CuerpoPrefab);
        PartesCuerpo.Add(Cuerpo);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    public float xContraint = 14.3f;
    public float zContraint = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
       if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
       if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
       if (transform.position.x > xContraint)
        {
            transform.position = new Vector3(xContraint, transform.position.y, transform.position.z);
        }
       if (transform.position.x < -xContraint)
        {
            transform.position = new Vector3(-xContraint, transform.position.y, transform.position.z);
        }
       if (transform.position.z > zContraint)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zContraint);
        }
       if (transform.position.z < -zContraint)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zContraint);
        }
    }
}

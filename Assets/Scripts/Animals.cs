using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody enemyRb;
    private GameObject player;
    public float xContraint = 14.3f;
    public float zContraint = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(-lookDirection * speed * Time.deltaTime);
        ConstrainPlayerPosition();
    }
    void ConstrainPlayerPosition()
    {
       if (transform.position.x > xContraint) {
        transform.position = new Vector3(xContraint, transform.position.y, transform.position.z);
        }
       if (transform.position.x < -xContraint) {
        transform.position = new Vector3(-xContraint, transform.position.y, transform.position.z);
        }
       if (transform.position.z > zContraint) {
        transform.position = new Vector3(transform.position.x, transform.position.y, zContraint);
        }
       if (transform.position.z < -zContraint) {
        transform.position = new Vector3(transform.position.x, transform.position.y, -zContraint);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    public float xContraint = 14.3f;
    public float zContraint = 5.5f;
    public bool hasPowerup;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        hasPowerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
        Powerup();
    }

    // Moves the player based on key input
    void MovePlayer()
    {
       if (Input.GetKey(KeyCode.W)) {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
       if (Input.GetKey(KeyCode.S)) {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
       if (Input.GetKey(KeyCode.A)) {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       if (Input.GetKey(KeyCode.D)) {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    // Prevent the player from leaving the screen
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    void Powerup()
    {
        if (hasPowerup)
        {
            speed = 7;
        }
        else
        {
            speed = 5;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}

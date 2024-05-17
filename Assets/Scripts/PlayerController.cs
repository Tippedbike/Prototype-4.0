using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public float speed = 25;
    public bool hasPowerup = false; 
    public bool hasPowerup2 = false; 
    public bool hasPowerup3 = false;
    public GameObject powerupIndicator;
    float powerupStrength = 15.0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
        if (other.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
        if (other.CompareTag("Powerup3"))
        {
            hasPowerup3 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false; 
        hasPowerup2 = false;
        hasPowerup3 = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
            
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Enemy") && hasPowerup2)
        {
            Debug.Log("Hi");
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        }



        if (collision.gameObject.CompareTag("Enemy") && hasPowerup3)
        {
            Debug.Log("Hi");
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        }
    }
}
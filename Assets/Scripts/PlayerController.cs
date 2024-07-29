using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMax, xMin, zMax, zMin;
}


public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource audioSource;

    public float speed;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire;
    public float fireRate;
    public Boundary boundary;

    void Start() {
        nextFire = 0.0f;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if(Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            GameObject shotClone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;

            audioSource.Play();
        }
    }

    void FixedUpdate() {
        // Grab input from player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}

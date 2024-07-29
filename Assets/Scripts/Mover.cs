using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * speed);
        rb.velocity = transform.forward * speed;

        print(rb.velocity);
    }
}

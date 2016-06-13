using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
    private Rigidbody rb;

    public float speed;

    void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}

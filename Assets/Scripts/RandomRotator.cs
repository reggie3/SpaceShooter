using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float tumble = 3;

    private Rigidbody rb;

    void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}

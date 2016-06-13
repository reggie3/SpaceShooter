using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {
    public float speed = 10;
    public Boundary boundary;
    public float tiltFactor;

    public GameObject shot;
    public Transform shotSpawn;

    private Rigidbody rb;
    private AudioSource audioSource;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    void Awake()
    {   
        rb = transform.GetComponent<Rigidbody>();
        audioSource = transform.GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetButton("Fire1")) && (Time.time > nextFire)){
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            audioSource.Play();
        }
    }

	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
            0,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tiltFactor);
    }
}

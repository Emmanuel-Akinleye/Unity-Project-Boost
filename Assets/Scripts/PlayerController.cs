using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float mainThrust;
    [SerializeField] private float rotateStrength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Thrust(mainThrust);
        }
        else if (Input.GetKey(KeyCode.S)) {
            Thrust(-mainThrust);
        }
    }

    private void Thrust(float mainThrust)
    {
        playerRb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateThrust(rotateStrength);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateThrust(-rotateStrength);
        }
    }

    private void RotateThrust(float rotationThisFrame)
    {
        playerRb.freezeRotation = true; // Freezing rotation so we can manually
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        playerRb.freezeRotation = false;
    }
}

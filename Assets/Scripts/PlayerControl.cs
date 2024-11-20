using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement Variables")]
    private float horizontalInput;
    [SerializeField] private float turnSpeed;
    private float verticalInput;
    [SerializeField] private float thrustForce;

    [Header("Shooting")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform bulletSpawn;


    //Components
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);

        //Shooting
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * verticalInput * thrustForce);

    }
}

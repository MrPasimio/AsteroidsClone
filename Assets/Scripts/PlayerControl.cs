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

    [Header("Particles")]
    public ParticleSystem mainThruster;
    public ParticleSystem rightThruster;
    public ParticleSystem leftThruster;

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
        if(horizontalInput > 0)
        {
            rightThruster.Stop();
            if(!leftThruster.isPlaying)
            {
                leftThruster.Play();
            }
        }

         else if (horizontalInput < 0)
        {
            leftThruster.Stop();
            if (!rightThruster.isPlaying)
            {
                rightThruster.Play();
            }
        }
        else
        {
            leftThruster.Stop();
            rightThruster.Stop();
        }

        //Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            rb.AddRelativeForce(Vector3.forward * verticalInput * thrustForce);
            if(!mainThruster.isPlaying)
            {
                mainThruster.Play();
            }
        }
        else
        {
            mainThruster.Stop();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField]
    public GameObject pigeonPrefab;//this script shall launch the pigeon along a parabolic path 
    private Rigidbody pigeonRb;
    [SerializeField] private float launchSpeed = 20f;
    [SerializeField] private Transform launchPoint;
    [SerializeField] public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    //each pigeon can only be launched once
    public void Launch()
    {
        GameObject pigeon = Instantiate(
            pigeonPrefab,launchPoint.position,launchPoint.rotation
        );

        Rigidbody rb = pigeon.GetComponent<Rigidbody>();

        Vector3 direction = (target.position - launchPoint.position).normalized;
        rb.velocity = direction * launchSpeed;
    }
}

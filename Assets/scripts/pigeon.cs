using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    //this script shall handle the rotation and projectile like movement of the pigeon
    //the pigeon shall be fired from the low and high houses 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RotatePigeon();
    }

    private void RotatePigeon()
    {
        if (rb.velocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rb.velocity);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            //disable current pigeon after 2 seconds
            StartCoroutine(killPigeon(2));
        }
    }

    IEnumerator killPigeon(int time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

}

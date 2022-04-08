using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Section one script
public class Move : MonoBehaviour
{
    // One meter per second.
    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.forward;
        moveDirection *= moveSpeed * Time.deltaTime;

        transform.Translate(moveDirection, Space.World);
    }
}
*/

/* Sectiont two script
public class Move : MonoBehaviour
{
    // One meter per second.
    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.forward;
        moveDirection *= moveSpeed * Time.deltaTime;
        
        moveDirection *= Input.GetAxisRaw("Horizontal");

        transform.Translate(moveDirection, Space.World);

        if (moveDirection.magnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        
    }
}
*/

//
public class Move : MonoBehaviour
{
    // One meter per second.
    public float moveSpeed = 1.0f;
    public float jumpStrength = 5.0f;
    public Rigidbody rigidbody;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.forward;
        moveDirection *= moveSpeed * Time.deltaTime;
        
        moveDirection *= Input.GetAxisRaw("Horizontal");

        // transform.Translate(moveDirection, Space.World);
        
        rigidbody.AddForce(moveDirection, ForceMode.Acceleration);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
            //animator.SetTrigger("Fly");
        }
        
        if (moveDirection.magnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        
    }
}
//
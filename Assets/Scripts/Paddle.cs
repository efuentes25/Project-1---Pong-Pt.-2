using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// credit to Michael Guerrero

public class Paddle : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    public float speed;
    public float collisionSpeed = 1.5f;
    public string inputAxis;

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis(inputAxis);
        Vector3 newPos = transform.position + new Vector3(0, 0, direction) * (speed * Time.deltaTime);
        newPos.z = Mathf.Clamp(newPos.z, minHeight, maxHeight);
        
        transform.position = newPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var bounds = GetComponent<BoxCollider>().bounds;
        float maxPadHeight = bounds.max.z;
        float minPadHeight = bounds.min.z;

        float percHeight = (collision.transform.position.z - minPadHeight) / (maxPadHeight - minPadHeight);
        float bounceDirec = (percHeight - 0.5f) / 0.5f;
        
        Vector3 currVelocity = collision.relativeVelocity;
        float newSignal = currVelocity.x > 0 ? -1f: 1f;
        float newRotationSignal = newSignal < 0f ? 1f: -1f;
        
        float newSpeed = currVelocity.magnitude * collisionSpeed;
        Vector3 newVelocity = new Vector3(newSignal, 0f, 0f) * newSpeed;
        newVelocity = Quaternion.Euler(0f, newRotationSignal * 60f * bounceDirec, 0f) * newVelocity;
        collision.rigidbody.velocity = newVelocity;
    }
}

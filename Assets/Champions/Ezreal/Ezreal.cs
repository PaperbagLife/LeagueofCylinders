using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ezreal : playerMovement
{
    public float cdQ;
    private float nextFireQ;
    public GameObject mysticShot;
    public float qOffset = 3f;
    public int qSpeed = 10;
    public float cdW;
    private float nextFireW;
    public float cdE;
    private float nextFireE;
    public float cdR;
    private float nextFireR;
    public override void q(Vector3 mousePos) {
        // Send out mystic shot
        if (Time.time > nextFireQ) {
            Vector3 direction = (mousePos - gameObject.transform.position);
            direction.y = 0;
            direction.Normalize();
            GameObject newQ = Instantiate(mysticShot, transform.position + direction * qOffset, Quaternion.identity);
            Debug.Log(direction);
            newQ.GetComponent<skillShot>().setDirection(direction);
            nextFireQ = Time.time + cdQ;
        }
    }

}

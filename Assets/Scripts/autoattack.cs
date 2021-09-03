using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoattack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed = 5.0f;
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            target.transform.position, Time.deltaTime * speed);
        if ((transform.position - target.transform.position).magnitude < 0.8f) {
            Destroy(gameObject);
        }
    }
    public void setTarget(GameObject t) {
        target = t;
    }
}

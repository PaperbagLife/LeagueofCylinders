using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    public Camera cam;
    // public ThirdPersonCharacter character;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (Input.GetMouseButtonDown(1)) {
                agent.SetDestination(hit.point);
            }
            if (agent.remainingDistance > agent.stoppingDistance) {
                // character.Move(agent.desiredVelocity, false, false);
            }
            if (Input.GetKeyDown("q")) {
                q(hit.point);
            }
            if (Input.GetKeyDown("w")) {
                w(hit.point);
            }
            if (Input.GetKeyDown("e")) {
                e(hit.point);
            }
            if (Input.GetKeyDown("r")) {
                r(hit.point);
            }
        }
        
    }

    public virtual void q(Vector3 mousePos) {

    }
    public virtual void w(Vector3 mousePos) {
        
    }
    public virtual void e(Vector3 mousePos) {
        
    }
    public virtual void r(Vector3 mousePos) {
        
    }
}

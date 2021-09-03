﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    public Camera cam;
    public LineRenderer line;
    public float attackRange = 100f;
    public bool attacking = false;
    public float attackSpeed = 0.5f;
    private GameObject attackTarget;
    public GameObject aaProjectile;
    private float nextAttackTime;

    // public ThirdPersonCharacter character;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)) {
            if (Input.GetMouseButtonDown(1)) {
                GameObject target = hit.collider.gameObject;
                if (target.tag == "enemy") {
                    attacking = true;
                    attackTarget = target;
                }
                else {
                    attacking = false;
                }
                if (!attacking) {
                    agent.SetDestination(hit.point);
                }
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
        if (agent.remainingDistance > agent.stoppingDistance) {
            drawPath(agent.path);
        }
        if (attacking) {
            // Check target distance
            if (inRange(attackTarget)) {
                autoAttack(attackTarget);
            }
            else {
                agent.SetDestination(attackTarget.transform.position);
            }
        }
    }
    public void autoAttack(GameObject target) {
        if (Time.time >= nextAttackTime) {
            // Actually attack lol
            GameObject aa = Instantiate(aaProjectile, transform.position, Quaternion.identity);
            aa.GetComponent<autoattack>().setTarget(target);
            nextAttackTime = Time.time + 1/attackSpeed;
        }
    }
    public bool inRange(GameObject target) {
        float dist = Vector3.Distance(target.transform.position,
                                      transform.position);
        return dist <= attackRange;
    }
    public void drawPath(NavMeshPath path) {
        if (path.corners.Length < 2) 
            return;
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
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

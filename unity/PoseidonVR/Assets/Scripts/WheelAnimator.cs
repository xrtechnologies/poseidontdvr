using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class WheelAnimator : MonoBehaviour
{
    [SerializeField]
    private float BaseSpeed = 1.0f;
    private NavMeshAgent agent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", BaseSpeed * agent.velocity.magnitude / 15.0f);
    }
}

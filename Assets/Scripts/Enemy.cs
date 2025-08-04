using System;
using Enums;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    //enum State {Idle, Running}
    [Header("Settings")] 
    [SerializeField] private float searchRadius;
    [SerializeField] private float moveSpeed;
    [SerializeField] private EnemyState state;
    [SerializeField] private Transform targetRunner;
    
    [SerializeField] private Animator animator; 

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
    }
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case EnemyState.Idle:
                SearchForTarget();
                break;
            case EnemyState.Running:
                RunnerTowardsTarget();
                break;
        }
    }

    private void SearchForTarget() //runnerlarin tespit edilip enemylerin bu runnerlara dogru kosma metodunun cagrilmasi
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);
        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget())
                {
                    continue;
                }

                runner.SetTarget();
                targetRunner = runner.transform;
                
                StartRunningTowardsTarget();
            }
        }
    }

    private void StartRunningTowardsTarget()
    {
        state = EnemyState.Running;
        animator.Play("Run");
    }
    private void RunnerTowardsTarget()
    {
        if (targetRunner == null)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetRunner.position) < 0.1f)
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }
    }
}

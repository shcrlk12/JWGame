using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject Target;
    public float HP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject, 1f);
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }
    }

    protected virtual void FollowPlayer(GameObject target)
    {
        if (target != null)
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(target.transform.position);
        }
    }
}

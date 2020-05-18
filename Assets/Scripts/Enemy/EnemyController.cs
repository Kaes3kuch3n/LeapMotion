using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
    public class EnemyController : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(player.transform.position);
            _agent.isStopped = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            _agent.enabled = false;
            Destroy(gameObject, 5);
        }
    }
}
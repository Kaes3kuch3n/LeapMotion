using UnityEngine;

namespace Enemy
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnRate;
        [SerializeField] private int range;

        private float _lastSpawnTime = 0;

        private void Update()
        {
            if (Time.time < _lastSpawnTime + 1 / spawnRate)
                return;

            _lastSpawnTime = Time.time;
            Vector3 randomPosition = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
            Instantiate(enemyPrefab, transform.position + randomPosition, Quaternion.identity);
        }

    #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    #endif
    }
}
using UnityEngine;

namespace Assets._SourceV1
{
    public class FoodItemSpawnerV1 : MonoBehaviour
    {
        [SerializeField] private WorldGridV1 _worldGrid;        
        [SerializeField] private GameObject _foodItemPrefab;

        [Range(0.1f, 10f)]
        [SerializeField] private float _spawnIntervalSeconds;

        private float _elapsedTime = 0;
        private Vector2 _minPosition;
        private Vector2 _maxPosition;

        private void Start()
        {
            _minPosition = _worldGrid.GetMinPosition();
            _maxPosition = _worldGrid.GetMaxPosition();
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _spawnIntervalSeconds)
            {
                _elapsedTime = 0;
                Spawn();
            }
        }

        private void Spawn()
        {            
            var foodItem = GameObject.Instantiate(_foodItemPrefab);
            foodItem.transform.position = GetRandomPosition();
        }

        private Vector2 GetRandomPosition()
        {
            var randomX = UnityEngine.Random.Range((int)_minPosition.x, (int)_maxPosition.x);
            var randomY = UnityEngine.Random.Range((int)_minPosition.y, (int)_maxPosition.y);

            return new Vector2(randomX, randomY);
        }
    }
}

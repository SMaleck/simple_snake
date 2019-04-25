using UnityEngine;

namespace Assets._Source.World
{
    public class FoodItemSpawner : MonoBehaviour
    {
        [SerializeField] private WorldGrid _worldGrid;
        [SerializeField] private FoodItem _foodItemPrefab;

        private Vector2 _minPosition;
        private Vector2 _maxPosition;

        private void Start()
        {
            _minPosition = _worldGrid.GetMinPosition();
            _maxPosition = _worldGrid.GetMaxPosition();

            Spawn();
        }

        public void OnFoodWasDestroyed()
        {
            Spawn();
        }

        private void Spawn()
        {
            var foodItem = GameObject.Instantiate(_foodItemPrefab);
            foodItem.SetFoodItemSpawner(this);
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

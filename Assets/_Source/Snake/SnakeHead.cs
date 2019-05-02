using Assets._Source.World;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeHead : SnakeElement
    {
        private SnakeManager _snakeManager;

        public void OnTriggerEnter2D(Collider2D other)
        {
            var foodItem = other.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                foodItem.Eat();
                _snakeManager.OnPickedUpFood();
            }
        }

        public void SetSnakeManager(SnakeManager snakeManager)
        {
            _snakeManager = snakeManager;
        }
    }
}

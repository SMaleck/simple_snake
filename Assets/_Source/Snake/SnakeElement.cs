using Assets._Source.World;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeElement : MonoBehaviour
    {                
        private SnakeManager _snakeManager;

        public Vector3 Position
        {
            get { return gameObject.transform.position; }
            set { gameObject.transform.position = value; }
        }

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

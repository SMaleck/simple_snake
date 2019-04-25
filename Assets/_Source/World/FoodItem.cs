using UnityEngine;

namespace Assets._Source.World
{
    public class FoodItem : MonoBehaviour
    {
        private FoodItemSpawner _foodItemSpawner;

        public void Eat()
        {
            _foodItemSpawner.OnFoodWasDestroyed();
            Destroy(this.gameObject);
        }

        public void SetFoodItemSpawner(FoodItemSpawner foodItemSpawner)
        {
            _foodItemSpawner = foodItemSpawner;
        }
    }
}

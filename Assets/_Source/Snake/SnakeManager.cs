using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeManager : MonoBehaviour
    {
        [SerializeField] private SnakeElement _snakeElementPrefab;

        private List<SnakeElement> _snakeElements;

        public void OnPickedUpFood()
        {

        }

        public void OnCollidedWithSelf()
        {

        }

        private SnakeElement SpawnAt(Vector3 spawnPosition)
        {
            var snakeElement = Instantiate(_snakeElementPrefab);
            snakeElement.gameObject.transform.position = spawnPosition;
            
            return snakeElement;
        }

        private void MoveElement()
        {
            var tail = _snakeElements.Last();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeElement : MonoBehaviour
    {
        private SnakeHead _snakeHead;
        public bool IsHead { get; private set; }

        public void SetIsHead(bool value)
        {
            IsHead = value;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            
        }
    }
}

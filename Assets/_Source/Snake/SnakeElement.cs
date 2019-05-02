using Assets._Source.World;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeElement : MonoBehaviour
    {                
        public Vector3 Position
        {
            get { return gameObject.transform.position; }
            set { gameObject.transform.position = value; }
        }        
    }
}

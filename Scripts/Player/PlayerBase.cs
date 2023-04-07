using UnityEngine;
using System.Collections;

namespace Player
{
    public class PlayerBase : MonoBehaviour
    {

        [SerializeField] protected int dddd;
        public int dsdd; 

        protected void Death()
        {
            Debug.Log("das");
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
using System;
using UnityEngine;

namespace World
{
    public class RoomPortal : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Application.Quit();
            }
        }
    }
}
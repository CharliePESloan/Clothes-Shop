using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStuff
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        void Update()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) *
                               (speed * Time.deltaTime);
            transform.position = transform.position + movement;
        }
    }
}

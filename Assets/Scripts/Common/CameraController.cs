using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

namespace Common
{
    public class CameraController : MonoGenericSingleton<CameraController>
    {
        public float damp_time = 0.2f;
        [SerializeField] private Camera game_camera;
        private Vector3 move_velocity;
        private Vector3 desiredPosition;

        private void LateUpdate()
        {
            Move();
        }
        private void Move()
        {
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref move_velocity, damp_time);
        }
        public void SetPosition(Vector3 tankPosition)
        {

            Vector3 new_Position = new Vector3();
            new_Position = tankPosition;
            new_Position.y = transform.position.y;
            desiredPosition = new_Position;
        }
    }
}
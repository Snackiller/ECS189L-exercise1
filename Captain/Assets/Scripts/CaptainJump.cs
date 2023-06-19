/*In the stage 4, I write a jump command for the captain. You can click the space button to jump. When the captain is on the ground, 
captain can jump with speed of 8. I use if (rigidBody.velocity.y==0) to avoid jumping stiff.*/
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class CaptainJump : ScriptableObject, ICaptainCommand
    {
        private float jumpSpeed = 8.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody.velocity.y==0)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, this.jumpSpeed);
            }
        }
    }
}
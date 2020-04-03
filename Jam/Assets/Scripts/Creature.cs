using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Creature : MonoBehaviour
    {
        protected abstract void Start();
        protected abstract void Update();
        protected Rigidbody2D Rigidbody { get; set; }
        protected Animator Animator { get; set; }
        protected bool Grounded { get; set; }
        public void Jump()
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Constants.PlayerJumpForce);
            Grounded = false;
        }
        public void Move(float direction)
        {
            this.transform.rotation.Set(transform.rotation.x, direction > 0.00f ? 0.00f : 180.00f, transform.rotation.z, transform.rotation.w);
            Rigidbody.velocity = new Vector2(direction * Constants.PlayerVelocityModifier, Rigidbody.velocity.y);
        }
        public bool IsStandingStill
        {
            get
            {
                return Rigidbody.velocity.y == 0;
            }
        }
    }
}

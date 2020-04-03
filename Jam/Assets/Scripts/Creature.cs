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
        [SerializeField] protected int health;
        [SerializeField] protected int speed;
        [SerializeField] protected int damage;
        public void Jump()
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Constants.PlayerJumpForce);
            Grounded = false;
        }
        public void Move(float direction)
        {
            float newY = direction == 0 ? transform.rotation.y : direction > 0.00f ? 0f : 180f;
            transform.rotation = new Quaternion(transform.rotation.x, newY, transform.rotation.z, transform.rotation.w);
            Rigidbody.velocity = new Vector2(direction * Constants.PlayerVelocityModifier, Rigidbody.velocity.y);
        }
        public bool IsStandingStill
        {
            get
            {
                return Rigidbody.velocity.y == 0.00f;
            }
        }
        public virtual void Attack()
        {
            Animator.SetTrigger(Constants.Attack);
        }
    }
}

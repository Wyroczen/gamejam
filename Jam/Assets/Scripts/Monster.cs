﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Monster : Creature
    {
        private float direction;

        public override void Damage()
        {
            Debug.Log("Damaged!");
            Health -= Constants.AttackDamage;
            Debug.Log("Health: " + Health);
            base.Damage();
            
        }

        protected override void Start()
        {
            direction = -200.00f;
            health = 100;
            Health = health;
            Rigidbody = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            RunRandomly();
            AttackRandomly();
        }

        private void AttackRandomly()
        {
            if ((int)direction % 10 == 0)
                base.Attack();
        }
        private void RunRandomly()
        {
            direction += 1.0f;
            if (direction > 200.0f)
                direction = -200.0f;
            base.Move(direction > 0 ? 1.0f : -1.0f, Constants.MonsterVelocityModfier);
        }
    }
}

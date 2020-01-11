﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPGtest
{
    class Enemy
    {
        private Vector2 position;
        protected int health;
        protected int speed;
        protected int radius;

        public static List<Enemy> enemies = new List<Enemy>();

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Vector2 Position
        {
            get { return position; }
        }
        public int Radius
        {
            get { return radius; }
        }

        public Enemy(Vector2 newPos)
        {
            position = newPos;
        }

        public void Update(GameTime gameTime, Vector2 playerPos)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // moves enemy toward player based on relative positions
            Vector2 moveDir = playerPos - position;
            moveDir.Normalize();

            Vector2 tempPos = position;
            tempPos += moveDir * speed * dt;
            if (!Obstacle.didCollide(tempPos, radius))
            {
                position += moveDir * speed * dt;
            }
        }
    }

    class Snake : Enemy {
        public Snake(Vector2 newPos) : base(newPos) {
            health = 3;
            speed = 120;
            radius = 42;
        }
    }

    class Eye : Enemy {
        public Eye(Vector2 newPos) : base(newPos) {
            health = 5;
            speed = 80;
            radius = 45;
        }
    }
}

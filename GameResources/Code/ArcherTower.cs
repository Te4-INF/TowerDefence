﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF.GameResources.Code
{
    class ArcherTower : Tower
    {

        float shotTimer;

        List<Shots> shotsList;

        public ArcherTower(Texture2D tex, Vector2 pos, List<Shots> shotsList) :base(tex, pos)
        {

            price = 100;
            this.shotsList = shotsList;

        }

        public override void Update(GameTime gameTime, List<Enemy> enemyList, ProjectileHandler projectileHandler)
        {

            shotTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemy e in enemyList)
            {
                float dist = Vector2.Distance(pos, e.GetPos());
                if (dist < radius && shotTimer <= 0)
                {
                    shotTimer = 2f;
                    projectileHandler.ArrowShoot(pos, e);

                }

                else if (dist > radius && shotTimer <= 0)
                {

                    foreach (StoneShot stone in shotsList)
                    {
                        shotsList.Remove(stone);
                        break;
                    }


                }
                Console.WriteLine("ENEMY NOT DETECTED");

            };

        }

        public override void Draw(SpriteBatch sb)
        {

            base.Draw(sb);

        }
    }
}
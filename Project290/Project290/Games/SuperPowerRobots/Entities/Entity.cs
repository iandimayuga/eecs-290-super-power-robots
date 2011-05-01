﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project290.Physics.Dynamics;
using Microsoft.Xna.Framework;
using Project290.Rendering;
using Microsoft.Xna.Framework.Graphics;

namespace Project290.Games.SuperPowerRobots.Entities
{
    public abstract class Entity
    {
        protected static ulong s_ID = 0;

        private Body m_Body;
        private SPRWorld m_SPRWorld;
        private ulong m_ID;
        private bool m_Dead;
        private Texture2D m_Texture;
        private float m_Width;
        private float m_Height;

        public Entity(SPRWorld sprWorld, Body body, Texture2D texture, float width, float height)
        {
            this.m_SPRWorld = sprWorld;
            this.m_Body = body;
            m_ID = s_ID++;
            m_Dead = false;
            m_Texture = texture;
            m_Width = width;
            m_Height = height;
        }

        public Body Body
        {
            get { return m_Body; }
            private set { m_Body = value; }
        }

        public SPRWorld SPRWorld
        {
            get { return m_SPRWorld; }
            private set { m_SPRWorld = value; }
        }

        public Vector2 GetPosition()
        {
            return m_Body.Position;
        }

        public float GetRotation()
        {
            return m_Body.Rotation;
        }

        public ulong GetID()
        {
            return m_ID;
        }

        public void ApplyLinearImpulse(Vector2 impulse)
        {
            this.Body.ApplyLinearImpulse(impulse);
        }

        public void ApplyAngularImpulse(float impulse)
        {
            this.Body.ApplyAngularImpulse(impulse);
        }

        public void SetRotation(float rotation)
        {
            this.Body.Rotation = rotation;
        }

        public void SetDead(bool dead)
        {
            m_Dead = dead;
        }

        public bool IsDead()
        {
            return m_Dead;
        }

        public Texture2D GetTexture()
        {
            return m_Texture;
        }

        public void SetTexture(Texture2D texture)
        {
            m_Texture = texture;
        }

        public float GetWidth()
        {
            return m_Width;
        }

        public void SetWidth(float width)
        {
            m_Width = width;
        }

        public float GetHeight()
        {
            return m_Height;
        }

        public void SetHeight(float height)
        {
            m_Height = height;
        }

        public abstract void Update(float dTime);

        public virtual void Draw()
        {
            //Texture2D texture = TextureStatic.Get("4SideFriendlyRobot");
            Drawer.Draw(
                m_Texture,
                this.GetPosition() * Settings.PixelsPerMeter,
                new Rectangle(0, 0, m_Texture.Width, m_Texture.Height),
                Color.White,
                this.GetRotation(),
                new Vector2(m_Texture.Width / 2, m_Texture.Height / 2),
                m_Width * Settings.PixelsPerMeter / m_Texture.Width,
                SpriteEffects.None,
                0f);
        }
    }
}

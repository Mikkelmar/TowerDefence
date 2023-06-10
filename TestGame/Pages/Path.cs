using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestGame.Pages
{
    
    public class Path
    {
        private List<int[]> road;
        public float totalDistance = 0;

        public Path(List<int[]> road)
        {
            this.road = road;
            Vector2 lastPos = new Vector2(road[0][0], road[0][1]);
            for (int i = 1; i < road.Count;i++)
            {
                Vector2 nextPos = new Vector2(road[i][0], road[i][1]);
                totalDistance += Vector2.Distance(nextPos, lastPos);
                lastPos = nextPos;
            }
        }
        public bool inGoal(float distance)
        {
            return distance >= totalDistance;
        }
        public Vector2 GetPos(float distance)
        {
            float travelDist = 0;
            Vector2 lastPos = new Vector2(road[0][0], road[0][1]);
            for (int i = 1; i < road.Count; i++)
            {
                Vector2 nextPos = new Vector2(road[i][0], road[i][1]);
                float currentDistance = Vector2.Distance(nextPos, lastPos);
                travelDist += currentDistance;



                if (travelDist > distance)
                {
                    Vector2 newPost = new Vector2(nextPos.X - lastPos.X, nextPos.Y - lastPos.Y) *((travelDist- distance) /currentDistance);
                    
                    return new Vector2(nextPos.X - newPost.X, nextPos.Y - newPost.Y);
                }

                lastPos = nextPos;
            }
            return new Vector2(-100, -100);
        }
    }
}

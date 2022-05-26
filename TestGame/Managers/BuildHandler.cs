using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    /**
     * BuildHandler har ansvar for å la spilleren plasere(bygge)
     * GameObjects inn i spillet
     */
    public class BuildHandler
    {
        private ObjectManager objm;
        private SceneManager scenem;
        private Game1 g;
        public BuildHandler(ObjectManager objm, SceneManager scenem, Game1 g)
        {
            this.objm = objm;
            this.scenem = scenem;
            this.g = g;
        }
        public bool Build(GameObject obj)
        {
            if (!objm.Intersect(obj.GetHitbox()))
            {
                objm.Add(obj, g);
                return true;
            }
            return false;
        }
    }
}

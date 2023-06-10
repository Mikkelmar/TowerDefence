using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds;
using TestGame.Huds.PopupDisplays;
using TestGame.Managers;
using TestGame.Objects.Monsters;
using TestGame.Objects.Particles;
using TestGame.Objects.PlayerLogic;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Soldiers.Heros;
using TestGame.Objects.Towers;

namespace TestGame.Objects
{

    public class Player : GameObject
    {
        public int money = 1000;
        public int hp = 20;
        public int displayTange;

        public List<PlayerPower> playerPowers = new List<PlayerPower>();
        public List<HeroIcon> heroIcons = new List<HeroIcon>();
        public static int activeHero = 0;
        private static Sound loseHpSound = new Sound(Sounds.playerLoseHp, 0.5f, SoundManager.types.Normal);
        private static Sound clickSound = new Sound(Sounds.click2, 0.1f, SoundManager.types.Normal);
        private static Sound moneySound = new Sound(Sounds.sell, 0.4f, SoundManager.types.Normal);
        public static Hero fridaHero = new HeroFrida(200,200);
        public static Hero skeletonHero = new LichHero(200, 200);
        
        public List<Hero> heros = new List<Hero>() { fridaHero, skeletonHero };
        public Hero getHero() { return heros[activeHero]; }
        private Dictionary<Keys, bool> isKeyDown = new Dictionary<Keys, bool>() 
        { {Keys.D1, false }, {Keys.D2, false }, {Keys.D3, false }, {Keys.D4, false }, 
            {Keys.Escape, false }, {Keys.W, false }, {Keys.Q, false }, { Keys.S, false} };
        
        private List<Keys> indexList = new List<Keys>() { Keys.D1, Keys.D2, Keys.D3, Keys.D4 };
        public Player() : base(0, 0, 0, 0)
        {
        }
        public void takeDamage(int damage, Game1 g)
        {
            hp -= damage;
            if(hp <= 0)
            {
                Die(g);
            }
            else
            {
                loseHpSound.play(g);
            }
        }
        public void Die(Game1 g)
        {
            PopupDisplay pd = new PopupDisplay();
            pd.hm.Add(new DefeatDisplay(pd)
            {
                depth = pd.depth * 0.5f
            }, g);
            
            g.pageGame.hudManager.Add(pd, g);
            MediaPlayer.Play(Sounds.defeat);
            MediaPlayer.IsRepeating = false;
        }
        public void Win(Game1 g)
        {
            g.pageGame.sceneManager.GetScene().clearLevel(g);
            PopupDisplay pd = new PopupDisplay();
            pd.hm.Add(new WictoryDisplay(pd)
            {
                depth = pd.depth * 0.5f
            }, g);
            g.pageGame.hudManager.Add(pd, g);

            MediaPlayer.Play(Sounds.levelClear);
            MediaPlayer.IsRepeating = false;
        }
        public override void Destroy(Game1 g)
        {
            foreach(PlayerPower pp in playerPowers)
            {
                g.pageGame.mouseManager.Remove(pp);
            }
            foreach (HeroIcon heroIcon in heroIcons)
            {
                g.pageGame.mouseManager.Remove(heroIcon);
            }
        }
        public void rechargePowers(TimeSpan t, Game1 g)
        {
            foreach (PlayerPower pp in playerPowers)
            {
                pp.rechargePower(t, g);
            }
        }
        public override void Update(GameTime gt, Game1 g)
        {
            foreach (PlayerPower pp in playerPowers)
            {
                pp.Update(gt, g);
            }
            foreach (HeroIcon _hero in heroIcons)
            {
                if(_hero.hero.hp <= 0)
                {
                    _hero.hero.Update(gt, g);
                }
                
            }

            //TODO: rydd opp i keyboard input spagetty
            KeyboardState state = Keyboard.GetState();
            
            if (state.IsKeyDown(Keys.R)) 
            {
                PopupDisplay pd = new PopupDisplay();
                pd.hm.Add(new MonsterDisplay(pd, new BasicUnit(null)), g);
                new Sound(Sounds.pause, 0.8f).play(g);
                MediaPlayer.Pause();
                g.pageGame.hudManager.Add(pd, g);
            }
            if (state.IsKeyDown(Keys.E))
            {
                g.pageGame.getHudManager().closeActiveObject(g);
            }
            if (state.IsKeyDown(Keys.Escape) && !isKeyDown[Keys.Escape])
            {
                isKeyDown[Keys.Escape] = true;
                if (g.pageGame.getHudManager().activeObject != null)
                {
                    g.pageGame.getHudManager().closeActiveObject(g);
                }
                else
                {
                    PopupDisplay pd = new PopupDisplay();
                    pd.hm.Add(new GamePauseDisplay(pd)
                    {
                        depth = pd.depth * 0.5f
                    }, g);
                    new Sound(Sounds.pause, 0.8f).play(g);
                    MediaPlayer.Pause();
                    g.pageGame.hudManager.Add(pd, g);
                }       
            }else if (state.IsKeyUp(Keys.Escape))
            {
                isKeyDown[Keys.Escape] = false;
            }

            //Wave speed
            if (state.IsKeyDown(Keys.W) && !isKeyDown[Keys.W])
            {
                g.gameSpeed = Math.Min(2, ++g.gameSpeed);
                clickSound.play(g);
                isKeyDown[Keys.W] = true;
            }
            else if(state.IsKeyUp(Keys.W))
            {
                isKeyDown[Keys.W] = false;
            }
            if (state.IsKeyDown(Keys.Q) && !isKeyDown[Keys.Q])
            {

                isKeyDown[Keys.Q] = true;
                g.gameSpeed = Math.Max(1, --g.gameSpeed);
                clickSound.play(g);
            }
            else if (state.IsKeyUp(Keys.Q))
            {
                isKeyDown[Keys.Q] = false;
            }

            if (state.IsKeyDown(Keys.S) && !isKeyDown[Keys.S])
            {
                //TODO flytt mye av logikken et annet sted
                //dobbelt opp kode her og i waveButton
                WaveManager wm = g.pageGame.sceneManager.GetScene().waveManager;
                if (wm.gameStarted)
                {
                    if (wm.waveComplete() && wm.hasNextWave())
                    {

                        double completePercent = wm.getTimeSinceWaveCompleted().TotalMilliseconds / wm.getNextWaveStartTime().TotalMilliseconds;
                        int bonusMoney = Math.Max((int)(g.pageGame.sceneManager.GetScene().waveStartMoneyValue * (1 - completePercent)), 1);
                        g.pageGame.player.money += bonusMoney;
                        g.pageGame.player.rechargePowers(wm.getNextWaveStartTime() - wm.getTimeSinceWaveCompleted(), g);
                        g.pageGame.getObjectManager().Add(new DamageParticle(new Vector2(X + 80, Y), bonusMoney), g);
                        wm.NextWave(g);
                        moneySound.play(g);

                    }
                }
            }
            else if (state.IsKeyUp(Keys.S))
            {
                isKeyDown[Keys.S] = false;
            }

            //Powers shortKey
            foreach (Keys k in indexList)
            {
                if (state.IsKeyDown(k) && !isKeyDown[k])
                {
                    if (playerPowers.Count > indexList.IndexOf(k))
                    {
                        playerPowers[indexList.IndexOf(k)].activateFromKeyboard(g);
                        isKeyDown[k] = true;
                    }
                }
                else if(state.IsKeyUp(k))
                {
                    isKeyDown[k] = false;
                }
            }
            
        }

        public override void Draw(Game1 g)
        {
            foreach (PlayerPower pp in playerPowers)
            {
                pp.Draw(g);
            }
            foreach (HeroIcon heroIcon in heroIcons)
            {
                heroIcon.Draw(g);
            }
            //TODO cammpt be hud
            if (g.pageGame.getHudManager().activeObject is Tower)
            {
                Tower tower = g.pageGame.getHudManager().activeObject as Tower;
                Vector2 pos = new Vector2(tower.GetPosCenter().X - displayTange, tower.GetPosCenter().Y - displayTange);
                new Sprite(Textures.range).Draw(pos, size: displayTange * 2f, layerDepth: 0.1f);
            }
            
        }

        public override void Init(Game1 g)
        {
            foreach(Hero hero in heros)
            {
                hero.resetHeroPowers();
            }

            AddPlayerPower(g, new PlayerPower_Meteor(200, 600));
            AddPlayerPower(g, new PlayerPower_Soldiers(200, 600));
            AddHero(g, getHero());

        }
        public void AddPlayerPower(Game1 g, PlayerPower pp)
        {
            //float zc = 1 / g.gameCamera.Zoom;
            pp.X = 60 + 128 * playerPowers.Count;
            pp.Y = Drawing.WINDOW_HEIGHT - 130;
            playerPowers.Add(pp);
            g.pageGame.mouseManager.Add(pp);
        }
        public void AddHero(Game1 g, Hero hero)
        {
            //float zc = 1 / g.gameCamera.Zoom;
            HeroIcon icon = new HeroIcon(60+ (HeroIcon.iconSize + 30) * heroIcons.Count, Drawing.WINDOW_HEIGHT-180- HeroIcon.iconSize, hero);
            heroIcons.Add(icon);
            g.pageGame.getObjectManager().Add(hero, g);
            g.pageGame.mouseManager.Add(icon);
        }
    }
}

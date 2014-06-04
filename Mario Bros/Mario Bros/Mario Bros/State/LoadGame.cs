using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mario_Bros.Framework.GameState;
using Mario_Bros.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Mario_Bros.State
{
    class LoadGame : GameState
    {
        private float CoolDown = 0;
        public LoadGame(IDGameState _ID)
            : base(_ID)
        {
        }
        public override void InitState(ContentManager CM)
        {
            MediaPlayer.Stop();
            base.InitState(CM);
        }

        public override void HandleInput(GameTime gameTime, CInput _Input)
        {
            CoolDown += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (CoolDown > 2000)
            {
                CoolDown = 0;
                StateManager.getInst().ExitScreen();
                StateManager.getInst().AddScreen(new MainGame(IDGameState.MAINGAME));
            }
            GlobalValue.IS_LOCK_KEYBOARD = false;
            base.HandleInput(gameTime, _Input);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch SB)
        {
            SB.Begin();
            CResourceManager.GetInstance().GetResource(IDResource.LOAD).Draw(SB);
            StateManager.StringDrawer(GlobalValue.MARIO_LIFE.ToString(), new Vector2(192, 108), SB, Color.White);
            SB.End();
            base.Draw(SB);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.Controller
{
    internal class GameController
    {
        private Game? ActiveGame;

        public void Init()
        {
            ActiveGame = new Game();
        }

        public void Start() { 
            bool stop = false;
            while (!stop)
            {
                int[,] copiedArray = (int[,])ActiveGame.Land.Clone();
                if (CanDown())
                {
                    ActiveGame.Bloc.DownBlock();
                }
                else
                {
                    FixBloc();
                    ActiveGame.Bloc.Reset();
                }
                System.Threading.Thread.Sleep(3000);
            }
        }

        public void Draw() {
            int[,] DrawLand = (int[,])ActiveGame.Land.Clone();
            for (int i = 0; i < ActiveGame.Bloc.coords.Length; i++)
            {
                DrawLand[ActiveGame.Bloc.coords[i].x, ActiveGame.Bloc.coords[i].y] = 1;
            }
            for (int i = 0; i < ActiveGame.Land.GetLength(0); i++)
            {
                for (int j = 0; j < ActiveGame.Land.GetLength(1); j++)
                {
                    Console.Write("{0} ", (DrawLand[i, j]>0 ? 1 : 0));
                }
                Console.WriteLine();
            }
        }

        private bool CanDown()
        {
            for (int i = 0; i < ActiveGame.Bloc.coords.Length; i++)
            {
                if (ActiveGame.Land[ActiveGame.Bloc.coords[i].x+1, ActiveGame.Bloc.coords[i].y] != 0)
                {
                    return false;
                }
            }
            return true;

        }

        private void FixBloc()
        {
            for (int i = 0; i < ActiveGame.Bloc.coords.Length; i++)
            {
                ActiveGame.Land[ActiveGame.Bloc.coords[i].x, ActiveGame.Bloc.coords[i].y] = 1;
            }

        }
        
    }
}

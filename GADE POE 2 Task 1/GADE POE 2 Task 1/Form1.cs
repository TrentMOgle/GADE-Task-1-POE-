using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_POE_2_Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[,] Extra;
            Map Display = new Map();
            Extra = Display.TileArray;
            for(int I = 0; I < Extra.GetLength(0); I++)
            {
                for(int J = 0; J < Extra.GetLength(1); J++)
                {
                    Label.Text += Extra[I, J] + " ";
                }
                Label.Text += "\n";
            }
        }
        abstract class Tile
        {

            protected int x;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            protected int y;
            public int Y
            {
                get { return y; }
                set { y = value; }
            }

            public enum TileType
            {
                hero, enemy, gold, weapon
            }
            public Tile(int TempX, int TempY)
            {
                x = TempX;
                y = TempY;
            }
            private int hero;
            private int enemy;
            private int gold;
            private int weapon;
        }
        class obstacle : Tile
        {
            public obstacle(int x, int y) : base(x, y)
            {

            }
        }
        class EmptyTile : Tile
        {
            public EmptyTile(int x, int y) : base(x, y)
            {

            }
        }
    }
    abstract class character
    {
        public int variables;
        protected int Hp, MaxHp, Damage, x, y;


        public enum movement
        {
            NoMovement, Up, Down, Left, Right
        }
        public character(int x, int y)
        {

        }
        public virtual void attack(string character)
        {
            int target = Convert.ToInt32(character);
            target--;
        }
        public bool IsDead()
        {
            return true;
        }
        public virtual bool CheckRange(string character)
        {
            return true;
        }
        public abstract movement returnmove(movement move = 0);
        

        
        public abstract override string ToString();
    }


    class Enemy : character
    {
        public Enemy(int X, int Y) : base(X, Y)
        {

        }

        public override movement returnmove(movement move = movement.NoMovement)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
    public class Hero
    {

    }
    public class Map
    {
        public string[,] TileArray;
        public int width = 7;
        public int height = 7;
        public void TileCreate()
        {
            string Hero = "H";
            
            string Enemy = "G";
            for(int X = 0; X < width; X++)
            {
                for(int Y = 0; Y < height; Y++)
                {
                    if(X == 0 || X == width - 1 || Y == 0 || Y == height - 1)
                    {
                        TileArray[X, Y] = "x";
                    }
                    else if (X == 3 && Y == 2)
                    {
                        TileArray[X, Y] = Hero;
                    }
                    else
                    {
                        TileArray[X, Y] = ".";
                    }
                }
            }
        }
    }

                        
}

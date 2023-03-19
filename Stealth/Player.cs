using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public enum Direction { left, up, right, down };
    public enum Animation { still, left, up, right, down, crouch, stand, turn };
    
    public class Player
    {
        private double timer;

        public Direction Direction { get; set; }
        public Animation Animation { get; set; }
        public bool Crouching { get; set; }
        public bool Running { get; set; }
        public sbyte Room { get; set; }
        public sbyte X { get; set; }
        public double Xfine
        {
            get
            {
                switch (Animation)
                {
                    case Animation.left:
                        return X + Distance;
                    case Animation.right:
                        return X - Distance;
                    default:
                        return X;
                }
            }
        }
        public sbyte Y { get; set; }
        public double Yfine
        {
            get
            {
                switch (Animation)
                {
                    case Animation.up:
                        return Y - Distance;
                    case Animation.down:
                        return Y + Distance;
                    default:
                        return Y;
                }
            }
        }
        public double Distance { get; set; }

        public Player()
        {
            Direction = Direction.down;
            Animation = Animation.still;
            Crouching = false;
            X = 0;
            Y = 0;
            Distance = 0;
        }

        public void Move(Animation animation, byte[,] collision)
        {
            if (Animation != Animation.still)
                return;

            Animation = animation;
            Distance = 1;
            
            switch (animation)
            {
                case Animation.left:
                    if ((collision[Y,X] & 0x01) == 0 && (Direction == Direction.left || Running) && ((collision[Y,X-1] & 0x10) == 0 || Crouching))
                        X -= 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.left;
                    break;
                case Animation.up:
                    if ((collision[Y, X] & 0x02) == 0 && (Direction == Direction.up || Running) && ((collision[Y + 1, X] & 0x10) == 0 || Crouching))
                        Y += 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.up;
                    break;
                case Animation.right:
                    if ((collision[Y, X] & 0x04) == 0 && (Direction == Direction.right || Running) && ((collision[Y, X + 1] & 0x10) == 0 || Crouching))
                        X += 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.right;
                    break;
                case Animation.down:
                    if ((collision[Y, X] & 0x08) == 0 && (Direction == Direction.down || Running) && ((collision[Y - 1, X] & 0x10) == 0 || Crouching))
                        Y -= 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.down;
                    break;
            }
        }

        public void Crouch(bool crouch, byte[,] collision)
        {
            if (Animation != Animation.still)
                return;

            if ((crouch && Crouching) || (!crouch && !Crouching))
                return;

            if (!crouch && (collision[Y, X] & 0x10) != 0)
                return;

            Crouching = crouch;
            Animation = crouch ? Animation.crouch : Animation.stand;
            Distance = 1;
        }

        public void Run(bool run)
        {
            if (Animation != Animation.still || Crouching)
                return;

            Running = run;
        }

        public void Update(double seconds)
        {
            timer += seconds;
            double speed = 3;
            if (Animation == Animation.crouch || Animation == Animation.stand)
                speed = 4;
            else if (Animation == Animation.turn)
                speed = 10;
            else if (Crouching)
                speed = 1;
            else if (Running)
                speed = 7;

            Distance -= speed * seconds;
            if (Distance <= 0)
            {
                Distance = 0;
                if (Animation != Animation.still)
                {
                    timer = 0;
                    Animation = Animation.still;
                }
            }
        }

        public Sprite Sprite 
        {
            get
            {
                short animation = 0;
                short frame = 0;
                if (Animation == Animation.still || Animation == Animation.turn || Animation == Animation.crouch)
                {
                    animation = (short)(Crouching ? 1 : 0);
                    frame = (short)((int)(timer * 4) % 8);
                }
                else
                {
                    animation = (short)(Crouching ? 4 : (Running ? 3 : 2));
                    int which = (X + Y) % 2;
                    frame = (short)((int)((1 - Distance) * 3) % 3 + 3 * which);
                }
                return Assets.Player.Sprites[(short)(animation * 32 + (short)Direction * 8 + frame)];
            }
        }
    }
}

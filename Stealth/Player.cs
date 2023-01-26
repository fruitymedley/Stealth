using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public enum Direction { left, up, right, down };
    public enum Animation { still, left, up, right, down, crouch, stand, turn };
    
    public class Player
    {
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

        public void Move(Animation animation)
        {
            if (Animation != Animation.still)
                return;

            Animation = animation;
            Distance = 1;
            
            switch (animation)
            {
                case Animation.left:
                    if (Direction == Direction.left || Running)
                        X -= 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.left;
                    break;
                case Animation.up:
                    if (Direction == Direction.up || Running)
                        Y += 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.up;
                    break;
                case Animation.right:
                    if (Direction == Direction.right || Running)
                        X += 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.right;
                    break;
                case Animation.down:
                    if (Direction == Direction.down || Running)
                        Y -= 1;
                    else
                        Animation = Animation.turn;
                    Direction = Direction.down;
                    break;
            }
        }

        public void Crouch(bool crouch)
        {
            if (Animation != Animation.still)
                return;

            if ((crouch && Crouching) || (!crouch && !Crouching))
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
                Animation = Animation.still;
            }
        }

        public Sprite Sprite
        {
            get => Assets.Player.Sprites[(short)((short)Direction + (Crouching ? 1 : 0) * 4)];
        }
    }
}

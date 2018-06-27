﻿using System;
using System.Collections.Generic;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Algorithms;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde : Ghost
    {
        public override event Action SinkAboutEatPacman;
        private Stack<Position> list = new Stack<Position>();
        private IStrategy random = new RandomMoving();
        public Clyde(Map map) : base(map)
        {
            StartPosition();
            oldcoord = new Empty(Position);
        }

        public override void StartPosition()
        {
            Position = new Position(19, 11);
        }
        
        protected override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            pacmanIsLive = Move();
            if (pacmanIsLive == false)
            {
                SinkAboutEatPacman();
            }
        }

        public override bool Move()
        {
            lock (obj)
            {
                PacmanPosition = SearchPacman();

                if (PacmanPosition != Position)
                {
                    if (list.Count == 0)
                    {
                        list = random.FindPath(Map, Position, PacmanPosition);
                    }
                    oldcoord = Go(list, oldcoord);
                    if (PacmanPosition == Position)
                    {
                        oldcoord = new Empty(Position);
                        return false;
                    }
                    return true;
                }
                else
                {
                    oldcoord = new Empty(Position);
                    return false;
                }
            }
        }

        public static char GetCharElement()
        {
            return 'C';
        }
    }
}

using System;
using System.Collections.Generic;
using Abstract;


namespace SheepGame.Desktop
{
    public interface IBoo
    {
        bool find(int x);
    }

    public class CharacterEngine<T> where T: IBoo
    {
        private List<T> _npcList = new List<T>();
        private readonly Func<int, int, bool> _mapReviewer;
        private readonly Func<AbstractObject> _mapInsert;

        public CharacterEngine(Func<int, int, bool> mapReview,
                               Func<AbstractObject> mapInsert)
        {
            _mapReviewer = mapReview;
            _mapInsert = mapInsert;
        }

        public bool Add(T npc, int x, int y) 
        {
            if (_mapReviewer(x, y)) return false;

            _npcList.Add(npc);
            return true;
        }

        public void Remove(T npc) 
        {
            _npcList.Remove(npc);
        }

        public T GetInPossition(int x, int y)
        {
            return _npcList.Find((obj) => obj.find(x));
        }

        public void MoveOneTile(Direction direction, T npc) 
        { 
            
        }
    }

    public enum Direction
    {
        Right,
        Top,
        Left,
        Dowm
    }
}

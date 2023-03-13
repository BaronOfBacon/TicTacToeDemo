using System.Collections.Generic;
using Leopotam.Ecs;
using NUnit.Framework;
using UnityEngine;

namespace Root
{
    [TestFixture]
    public class GameLogicTest
    {
        
        [Test]
        public void Check()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0,0), CreateCell(world,new Vector2Int(0,0))},
                {new Vector2Int(0,1), CreateCell(world,new Vector2Int(0,1))},
                {new Vector2Int(0,2), CreateCell(world,new Vector2Int(0,2))},
                {new Vector2Int(1,0), CreateCell(world,new Vector2Int(1,0))},
                {new Vector2Int(1,1), CreateCell(world,new Vector2Int(1,1))},
                {new Vector2Int(1,2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2,0), CreateCell(world,new Vector2Int(2,0))},
                {new Vector2Int(2,1), CreateCell(world,new Vector2Int(2,1))},
                {new Vector2Int(2,2), CreateCell(world,new Vector2Int(2,2))},
            };

            var chainLength = GameExtensions.GetLongestChain(cells, Vector2Int.zero);
            Assert.AreEqual(0, chainLength);
        }
        
        [Test]
        public void CheckOne()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0,0), CreateCell(world,new Vector2Int(0,0))},
                {new Vector2Int(0,1), CreateCell(world,new Vector2Int(0,1))},
                {new Vector2Int(0,2), CreateCell(world,new Vector2Int(0,2))},
                {new Vector2Int(1,0), CreateCell(world,new Vector2Int(1,0))},
                {new Vector2Int(1,1), CreateCell(world,new Vector2Int(1,1))},
                {new Vector2Int(1,2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2,0), CreateCell(world,new Vector2Int(2,0))},
                {new Vector2Int(2,1), CreateCell(world,new Vector2Int(2,1))},
                {new Vector2Int(2,2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[Vector2Int.zero].Get<Taken>().value = SignType.Cross;
            
            var chainLength = GameExtensions.GetLongestChain(cells, Vector2Int.zero);
            Assert.AreEqual(1, chainLength);
        }
        
        [Test]
        public void CheckHorizontalToLeft()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0,0), CreateCell(world,new Vector2Int(0,0))},
                {new Vector2Int(0,1), CreateCell(world,new Vector2Int(0,1))},
                {new Vector2Int(0,2), CreateCell(world,new Vector2Int(0,2))},
                {new Vector2Int(1,0), CreateCell(world,new Vector2Int(1,0))},
                {new Vector2Int(1,1), CreateCell(world,new Vector2Int(1,1))},
                {new Vector2Int(1,2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2,0), CreateCell(world,new Vector2Int(2,0))},
                {new Vector2Int(2,1), CreateCell(world,new Vector2Int(2,1))},
                {new Vector2Int(2,2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(2,0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1,0)].Get<Taken>().value = SignType.Cross;
            
            var chainLength = GameExtensions.GetLongestChain(cells, new Vector2Int(2,0));
            
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckHorizontalToRight()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0,0), CreateCell(world,new Vector2Int(0,0))},
                {new Vector2Int(0,1), CreateCell(world,new Vector2Int(0,1))},
                {new Vector2Int(0,2), CreateCell(world,new Vector2Int(0,2))},
                {new Vector2Int(1,0), CreateCell(world,new Vector2Int(1,0))},
                {new Vector2Int(1,1), CreateCell(world,new Vector2Int(1,1))},
                {new Vector2Int(1,2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2,0), CreateCell(world,new Vector2Int(2,0))},
                {new Vector2Int(2,1), CreateCell(world,new Vector2Int(2,1))},
                {new Vector2Int(2,2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(2,0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1,0)].Get<Taken>().value = SignType.Cross;
            
            var chainLength = GameExtensions.GetLongestChain(cells, new Vector2Int(1,0));
            
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckHorizontalThreeToRight()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0,0), CreateCell(world,new Vector2Int(0,0))},
                {new Vector2Int(0,1), CreateCell(world,new Vector2Int(0,1))},
                {new Vector2Int(0,2), CreateCell(world,new Vector2Int(0,2))},
                {new Vector2Int(1,0), CreateCell(world,new Vector2Int(1,0))},
                {new Vector2Int(1,1), CreateCell(world,new Vector2Int(1,1))},
                {new Vector2Int(1,2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2,0), CreateCell(world,new Vector2Int(2,0))},
                {new Vector2Int(2,1), CreateCell(world,new Vector2Int(2,1))},
                {new Vector2Int(2,2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(0,0)].Get<Taken>().value = SignType.Circle;
            cells[new Vector2Int(1,0)].Get<Taken>().value = SignType.Circle;
            cells[new Vector2Int(2,0)].Get<Taken>().value = SignType.Circle;
            
            var chainLength = GameExtensions.GetLongestChain(cells, new Vector2Int(0,0));
            
            Assert.AreEqual(3, chainLength);
        }
        
        [Test]
        public void CheckDiagonalThree()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0,0), CreateCell(world,new Vector2Int(0,0))},
                {new Vector2Int(0,1), CreateCell(world,new Vector2Int(0,1))},
                {new Vector2Int(0,2), CreateCell(world,new Vector2Int(0,2))},
                {new Vector2Int(1,0), CreateCell(world,new Vector2Int(1,0))},
                {new Vector2Int(1,1), CreateCell(world,new Vector2Int(1,1))},
                {new Vector2Int(1,2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2,0), CreateCell(world,new Vector2Int(2,0))},
                {new Vector2Int(2,1), CreateCell(world,new Vector2Int(2,1))},
                {new Vector2Int(2,2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(0,0)].Get<Taken>().value = SignType.Circle;
            cells[new Vector2Int(1,1)].Get<Taken>().value = SignType.Circle;
            cells[new Vector2Int(2,2)].Get<Taken>().value = SignType.Circle;
            
            var chainLength = GameExtensions.GetLongestChain(cells, new Vector2Int(1,1));
            
            Assert.AreEqual(3, chainLength);
        }

        private EcsEntity CreateCell(EcsWorld world, Vector2Int position)
        {
            var entity = world.NewEntity();
            entity.Get<Position>().value = position;
            entity.Get<Cell>();

            return entity;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Coroutine;
using Microsoft.Xna.Framework;
using MLEM.Extensions;
using MLEM.Misc;
using MonoWorld.Camera;
using MonoWorld.World;

namespace MonoGame {
    public class Board : FixedWorld {

        public Board(int size) : base(size, size, new WorldCamera()) { }

        public void Swipe(GameTime gameTime, Direction2 direction) {
            if (!direction.IsAdjacent()) {
                Console.Error.WriteLine("Swiped in non cardinal direction: " + direction);
                return;
            }

            bool moved = false;

            Point offset = direction.Offset();
            Point start = ((offset + new Point(1)).Divide(2).Multiply(this.Size.X - 3) + new Point(1)) * offset.Abs();
            Point end = ((offset - new Point(1)).Abs() + new Point(1)) / new Point(2) * new Point(this.Size.X - 1);
            Point inc = (end - start) / (end - start).Abs();

            for (int i = 0; i < this.Size.X; i++) {
                for (int x = start.X; x >= 0 && x < this.Size.X; x += inc.X) {
                    for (int y = start.Y; y >= 0 && y < this.Size.Y; y += inc.Y) {
                        Point pos = new Point(x, y);

                        Number tile = this.GetTile<Number>(pos);

                        Point newPos = pos + direction.Offset();

                        if (tile == null || newPos.X < 0 || newPos.X >= this.Size.X || newPos.Y < 0 || newPos.Y >= this.Size.Y) {
                            continue;
                        }

                        Number newTile = this.GetTile<Number>(newPos);
                        if (newTile != null) {
                            if (newTile.Value == tile.Value) {
                                moved = true;
                                tile.Value *= 2;
                                tile.Position = newPos;
                            }
                        } else {
                            moved = true;
                            tile.Position = newPos;
                        }
                    }
                }
            }


            if (!moved) {
                return;
            }

            List<ActiveCoroutine> actives = new List<ActiveCoroutine>();
            foreach (Number number in this.AllTiles<Number>()) {
                actives.Add(CoroutineHandler.Start(number.Animate(gameTime)));
            }

            CoroutineHandler.InvokeLater(new WaitUntil(() => {
                return actives.All(coroutine => coroutine.IsFinished);
            }), () => {
                this.AddRandomTiles(2);
            });
        }

        public void Reset() {
            this.Clear();
            this.AddRandomTiles(2);
        }

        private void AddRandomTiles(int amount) {
            for (int i = 0; i < amount; i++) {
                Point? empty = this.GetRandomEmptyTile();
                if (empty == null) {
                    break;
                }

                int value = WorldInqDemo.Random.Next(1, 3);
                this.SetTile(new Number(this, empty.Value, (int) Math.Pow(2, value)));
            }
        }

        private Point? GetRandomEmptyTile() {
            List<Point> empty = new List<Point>();
            for (int x = 0; x < this.Size.X; x++) {
                for (int y = 0; y < this.Size.Y; y++) {
                    Point point = new Point(x, y);
                    if (this.GetTile<Number>(point) == null) {
                        empty.Add(point);
                    }
                }
            }

            if (empty.Count == 0) {
                return null;
            }

            return empty[WorldInqDemo.Random.Next(empty.Count)];
        }
    }
}
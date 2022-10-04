using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGenerator
{
    private int Width = 8;
    private int Height = 5;

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, Height - 1].WallLeft = false;
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[Width- 1, y].WallBottom = false;
        }


        RemoveWallsWithBacktracker(maze);

        PlaceExit(maze);

        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0,0];
        current.used = true;
        current.Distance = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> avaliableCells = new List<MazeGeneratorCell>();

            int x = current.X;
            int y = current.Y;


            if (x > 0 && !maze[x - 1, y].used) avaliableCells.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].used) avaliableCells.Add(maze[x, y - 1]);
            if (x < Width - 2 && !maze[x + 1, y].used) avaliableCells.Add(maze[x + 1, y]);
            if (y < Height - 2 & !maze[x, y + 1].used) avaliableCells.Add(maze[x, y + 1]);

            if(avaliableCells.Count > 0)
            {
                MazeGeneratorCell chosen = avaliableCells[Random.Range(0, avaliableCells.Count)];
                RemoveWall(current, chosen);
                chosen.used = true;             
                current = chosen;
                stack.Push(chosen);
                chosen.Distance = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);


    }

    private void RemoveWall(MazeGeneratorCell startCell, MazeGeneratorCell nextCell)
    {
        if (startCell.X == nextCell.X) 
        {
            if (startCell.Y > nextCell.Y) startCell.WallBottom = false;
            else nextCell.WallBottom = false;

        }
        else
        {
            if (startCell.X > nextCell.X) startCell.WallLeft = false;
            else nextCell.WallLeft = false;
        }
    }

    private void PlaceExit(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell furthest = maze[0, 0];

        for(int i = 1; i < maze.GetLength(0); i++)
        {
            if(maze[i, Height - 2].Distance > furthest.Distance) furthest = maze[i, Height - 2];
            if(maze[i, 0].Distance > furthest.Distance) furthest = maze[i, 0];
        }

        for (int i = 1; i < maze.GetLength(1); i++)
        {
            if (maze[Width - 2, i].Distance > furthest.Distance) furthest = maze[Width - 2, i];
            if (maze[0, i].Distance > furthest.Distance) furthest = maze[0, i];
        }


        if (furthest.X == 0)
        {
            furthest.WallLeft = false;
            furthest.ExitX = furthest.X;
            furthest.ExitY = furthest.Y;
        }
        else if (furthest.Y == 0)
        {
            Debug.Log(2);
            furthest.WallBottom = false;
            furthest.ExitX = furthest.X;
            furthest.ExitY = furthest.Y;
        }
        else if (furthest.X == Width - 2)
        {
            maze[furthest.X + 1, furthest.Y].WallLeft = false;
            maze[furthest.X + 1, furthest.Y].ExitY = furthest.Y;
            maze[furthest.X + 1, furthest.Y].ExitX = furthest.X+1;
        }
        else if (furthest.Y == Height - 2)
        {
            maze[furthest.X, furthest.Y + 1].WallBottom = false;
            maze[furthest.X , furthest.Y + 1].ExitY = furthest.Y + 1;
            maze[furthest.X , furthest.Y + 1].ExitX = furthest.X ;

        }
        
    }


}


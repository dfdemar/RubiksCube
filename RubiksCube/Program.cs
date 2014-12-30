using System;
using System.Collections.Generic;

public class RubiksCube
{
    public IDictionary<Face, CubeFace> Faces { get; set; }

    public RubiksCube()
    {
        Faces = new Dictionary<Face, CubeFace>();
        Faces.Add(Face.F, new CubeFace(new Dictionary<Face, Edge>() { { Face.U, Edge.Bottom }, { Face.R, Edge.Left }, { Face.D, Edge.Bottom }, { Face.L, Edge.Right } }));
        Faces.Add(Face.L, new CubeFace(new Dictionary<Face, Edge>() { { Face.U, Edge.Left }, { Face.F, Edge.Left }, { Face.D, Edge.Left }, { Face.B, Edge.Right } }));
        Faces.Add(Face.R, new CubeFace(new Dictionary<Face, Edge>() { { Face.U, Edge.Right }, { Face.B, Edge.Left }, { Face.D, Edge.Right }, { Face.F, Edge.Right } }));
        Faces.Add(Face.B, new CubeFace(new Dictionary<Face, Edge>() { { Face.U, Edge.Top }, { Face.L, Edge.Left }, { Face.D, Edge.Top }, { Face.R, Edge.Right } }));
        Faces.Add(Face.U, new CubeFace(new Dictionary<Face, Edge>() { { Face.B, Edge.Top }, { Face.R, Edge.Top }, { Face.F, Edge.Top }, { Face.L, Edge.Top } }));
        Faces.Add(Face.D, new CubeFace(new Dictionary<Face, Edge>() { { Face.B, Edge.Bottom }, { Face.R, Edge.Bottom }, { Face.F, Edge.Bottom }, { Face.L, Edge.Bottom } }));
    }

    public void Rotate(CubeFace face)
    {
        face.Rotate();
        foreach(var connection in face.Connections)
        {
            if (connection.Value == Edge.Top)
            {

            }
        }
    }
}

public enum Face { F, B, L, R, U, D }
public enum Edge { Top, Bottom, Left, Right }

public class CubeFace
{
    public int[,] Values { get; set; }
    public IDictionary<Face, Edge> Connections { get; set; }

    public CubeFace(IDictionary<Face, Edge> connections)
    {
        Values = new int[3,3];
        Connections = connections;
    }

    public void Rotate()
    {
        int n = Values.GetLength(0);
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = i; j < n - i - 1; j++)
            {
                int temp = Values[i, j];
                Values[i, j] = Values[n - 1 - j, i];
                Values[n - 1 - j, i] = Values[n - 1 - i, n - 1 - j];
                Values[n - 1 - i, n - 1 - j] = Values[j, n - 1 - i];
                Values[j, n - 1 - i] = temp;
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        var cube = new RubiksCube();
        int count = 1;
        int[,] frontFace = new int[3, 3];
        for (int i = 2; i >= 0; i--)
        {
            for (int j = 0; j < 3; j++)
            {
                frontFace[i, j] = count++;
            }
        }
        cube.Faces[Face.F].Values = frontFace;
        cube.Faces[Face.F].Rotate();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(frontFace[i, j]);
            }
            Console.WriteLine();
        }
    }
}
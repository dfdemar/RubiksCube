using System;
using System.Collections.Generic;
using System.Linq;

public class RubiksCube
{
    public IDictionary<Face, CubeFace> Faces { get; set; }

    public RubiksCube()
    {
        Faces = new Dictionary<Face, CubeFace>();
        Faces.Add(Face.F, new CubeFace());
        Faces.Add(Face.L, new CubeFace());
        Faces.Add(Face.R, new CubeFace());
        Faces.Add(Face.B, new CubeFace());
        Faces.Add(Face.U, new CubeFace());
        Faces.Add(Face.D, new CubeFace());
    }

    public void Move(IEnumerable<string> moves)
    {
        foreach (var move in moves)
        {
            Rotate((Face)Enum.Parse(typeof(Face), move));
        }
    }

    public void Rotate(Face face)
    {
        Faces[face].Rotate();
        switch (face)
        {
            case Face.F:
                Rotate(Faces[Face.U].Squares[2][0], Faces[Face.R].Squares[0][0], Faces[Face.D].Squares[2][0], Faces[Face.L].Squares[2][2]);
                Rotate(Faces[Face.U].Squares[2][1], Faces[Face.R].Squares[1][0], Faces[Face.D].Squares[2][1], Faces[Face.L].Squares[1][2]);
                Rotate(Faces[Face.U].Squares[2][2], Faces[Face.R].Squares[2][0], Faces[Face.D].Squares[2][2], Faces[Face.L].Squares[0][2]);
                break;
            case Face.L:
                Rotate(Faces[Face.U].Squares[0][0], Faces[Face.F].Squares[0][0], Faces[Face.D].Squares[2][2], Faces[Face.B].Squares[2][2]);
                Rotate(Faces[Face.U].Squares[1][0], Faces[Face.F].Squares[1][0], Faces[Face.D].Squares[1][2], Faces[Face.B].Squares[1][2]);
                Rotate(Faces[Face.U].Squares[2][0], Faces[Face.F].Squares[2][0], Faces[Face.D].Squares[0][2], Faces[Face.B].Squares[0][2]);
                break;
            case Face.R:
                Rotate(Faces[Face.U].Squares[2][2], Faces[Face.B].Squares[0][0], Faces[Face.D].Squares[0][0], Faces[Face.F].Squares[2][2]);
                Rotate(Faces[Face.U].Squares[1][2], Faces[Face.B].Squares[1][0], Faces[Face.D].Squares[1][0], Faces[Face.F].Squares[1][2]);
                Rotate(Faces[Face.U].Squares[0][2], Faces[Face.B].Squares[2][0], Faces[Face.D].Squares[2][0], Faces[Face.F].Squares[0][2]);
                break;
            case Face.B:
                Rotate(Faces[Face.U].Squares[0][2], Faces[Face.L].Squares[0][0], Faces[Face.D].Squares[0][2], Faces[Face.R].Squares[2][2]);
                Rotate(Faces[Face.U].Squares[0][1], Faces[Face.L].Squares[1][0], Faces[Face.D].Squares[0][1], Faces[Face.R].Squares[1][2]);
                Rotate(Faces[Face.U].Squares[0][0], Faces[Face.L].Squares[2][0], Faces[Face.D].Squares[0][0], Faces[Face.R].Squares[0][2]);
                break;
            case Face.U:
                Rotate(Faces[Face.B].Squares[0][2], Faces[Face.R].Squares[0][2], Faces[Face.F].Squares[0][2], Faces[Face.L].Squares[0][2]);
                Rotate(Faces[Face.B].Squares[0][1], Faces[Face.R].Squares[0][1], Faces[Face.F].Squares[0][1], Faces[Face.L].Squares[0][1]);
                Rotate(Faces[Face.B].Squares[0][0], Faces[Face.R].Squares[0][0], Faces[Face.F].Squares[0][0], Faces[Face.L].Squares[0][0]);
                break;
            case Face.D:
                Rotate(Faces[Face.B].Squares[2][0], Faces[Face.L].Squares[2][0], Faces[Face.F].Squares[2][0], Faces[Face.R].Squares[2][0]);
                Rotate(Faces[Face.B].Squares[2][1], Faces[Face.L].Squares[2][1], Faces[Face.F].Squares[2][1], Faces[Face.R].Squares[2][1]);
                Rotate(Faces[Face.B].Squares[2][2], Faces[Face.L].Squares[2][2], Faces[Face.F].Squares[2][2], Faces[Face.R].Squares[2][2]);
                break;
        }
    }

    private void Rotate(Square square1, Square square2, Square square3, Square square4)
    {
        int temp = square4.Value;
        square4.Value = square3.Value;
        square3.Value = square2.Value;
        square2.Value = square1.Value;
        square1.Value = temp;
    }
}

public enum Face { F, B, L, R, U, D }

public class CubeFace
{
    public Square[][] Squares { get; set; }

    public CubeFace()
    {
        Squares = new Square[3][];
        for (int i = 0; i < 3; i++)
        {
            Squares[i] = new Square[3];
            for (int j = 0; j < 3; j++)
            {
                Squares[i][j] = new Square();
            }
        }
    }

    public CubeFace(Square[][] layout)
    {
        Squares = layout;
    }

    public void Rotate()
    {
        int n = Squares.GetLength(0);
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = i; j < n - i - 1; j++)
            {
                Square temp = Squares[i][j];
                Squares[i][j] = Squares[n - 1 - j][i];
                Squares[n - 1 - j][i] = Squares[n - 1 - i][n - 1 - j];
                Squares[n - 1 - i][n - 1 - j] = Squares[j][n - 1 - i];
                Squares[j][n - 1 - i] = temp;
            }
        }
    }
}

public class Square
{
    public int Value { get; set; }
}

public class Program
{
    public static void Main()
    {
        var cube = new RubiksCube();
        int count = 1;
        Square[][] frontFace = new Square[3][];
        for (int i = 2; i >= 0; i--)
        {
            frontFace[i] = new Square[3];
            for (int j = 0; j < 3; j++)
            {
                frontFace[i][j] = new Square() { Value = count++ };
            }
        }
        cube.Faces[Face.F] = new CubeFace(frontFace);

        //int num = Int32.Parse(Console.ReadLine());
        //List<string> moves = Console.ReadLine().Split().ToList();
        //cube.Move(moves);

        //string[] results = new string[10];
        //foreach (var kvp in cube.Faces)
        //{
        //    for (int i = 2; i >= 0; i--)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            results[kvp.Value.Squares[i][j].Value] = kvp.Key.ToString();
        //        }
        //    }
        //}

        //foreach (var value in results.Skip(1))
        //{
        //    Console.Write(value + " ");
        //}

        cube.Rotate(Face.L);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(cube.Faces[Face.D].Squares[i][j].Value);
            }
            Console.WriteLine();
        }
    }
}
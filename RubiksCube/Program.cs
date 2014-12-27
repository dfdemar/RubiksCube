using System.Collections.Generic;

public class RubiksCube
{
    private IDictionary<Face, CubeFace> Faces { get; set; }
    public enum Face { F, B, L, R, U, D }

    public RubiksCube()
    {
        Faces = new Dictionary<Face, CubeFace>();
        Faces.Add(Face.U, new CubeFace(new[] { Face.R, Face.B, Face.L, Face.F }));
        Faces.Add(Face.L, new CubeFace(new[] { Face.F, Face.U, Face.B, Face.D }));
        Faces.Add(Face.F, new CubeFace(new[] { Face.R, Face.U, Face.L, Face.D }));
        Faces.Add(Face.R, new CubeFace(new[] { Face.B, Face.U, Face.F, Face.D }));
        Faces.Add(Face.D, new CubeFace(new[] { Face.R, Face.F, Face.L, Face.B }));
        Faces.Add(Face.B, new CubeFace(new[] { Face.R, Face.D, Face.L, Face.U }));
    }
}

public class CubeFace
{
    public int[,] Values { get; set; }
    public IEnumerable<char> Connections { get; set; }

    public CubeFace(IEnumerable<RubiksCube.Face> connections)
    {
        Values = new int[3, 3];
    }
}

public class Program
{
    public static void Main()
    {
        var cube = new RubiksCube();
    }
}
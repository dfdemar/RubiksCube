using System.Collections.Generic;

public class RubiksCube
{
    private IDictionary<Face, CubeFace> Faces { get; set; }
    public enum Face { F, B, L, R, U, D }
    public enum FaceType { Side, Top, Bottom }

    public RubiksCube()
    {
        Faces = new Dictionary<Face, CubeFace>();
        Faces.Add(Face.F, new CubeFace(FaceType.Side, new[] { Face.U, Face.R, Face.D, Face.L }));
        Faces.Add(Face.L, new CubeFace(FaceType.Side, new[] { Face.U, Face.F, Face.D, Face.B }));
        Faces.Add(Face.R, new CubeFace(FaceType.Side, new[] { Face.U, Face.B, Face.D, Face.F }));
        Faces.Add(Face.B, new CubeFace(FaceType.Side, new[] { Face.U, Face.L, Face.B, Face.R }));
        Faces.Add(Face.U, new CubeFace(FaceType.Top, new[] { Face.B, Face.R, Face.F, Face.L }));
        Faces.Add(Face.D, new CubeFace(FaceType.Bottom, new[] { Face.B, Face.R, Face.F, Face.L }));
    }

    public void Rotate(CubeFace face)
    {
        if (face.FaceType == FaceType.Side)
        {
            int n = face.Values.GetLength(0);
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    tmp=a[i][j];
                    a[i][j]=a[j][n-i-1];
                    a[j][n-i-1]=a[n-i-1][n-j-1];
                    a[n-i-1][n-j-1]=a[n-j-1][i];
                    a[n-j-1][i]=tmp;
                }
            }
        }
    }
}

public class CubeFace
{
    public int[,] Values { get; set; }
    public IEnumerable<char> Connections { get; set; }
    public RubiksCube.FaceType FaceType { get; set; }

    public CubeFace(RubiksCube.FaceType faceType, IEnumerable<RubiksCube.Face> connections)
    {
        FaceType = faceType;
        Values = new int[3,3];
    }
}

public class Program
{
    public static void Main()
    {
        var cube = new RubiksCube();
    }
}
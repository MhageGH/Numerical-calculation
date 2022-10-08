void LUDecomposition(float[,] A)    // LU分解：LとUを重ねた行列に変換
{
    var n = A.GetLength(0);
    for (var k = 0; k < n; ++k)
    {
        var w = 1 / A[k, k];
        for (var i = k + 1; i < n; ++i)
        {
            A[i, k] *= w;
            for (var j = k + 1; j < n; ++j) A[i, j] -= A[i, k] * A[k, j];
        }
    }
}

float[,] A = new float[,]    // 正方行列
{ 
    { 1, 2, 3, 0 }, 
    { 2, 3, 1, 5 }, 
    { 1, 3, 3, 0 }, 
    { 4, 5, 5, 1 } 
};


LUDecomposition(A);
Console.Write("L = " + Environment.NewLine);
for (int i = 0; i < A.GetLength(0); ++i) for (int j = 0; j < A.GetLength(1); ++j)
        Console.Write((i > j ? A[i, j] : i == j ? 1 : 0).ToString("F3") + (j < A.GetLength(1) - 1 ? "\t" : Environment.NewLine));
Console.Write(Environment.NewLine + "U = " + Environment.NewLine);
for (int i = 0; i < A.GetLength(0); ++i) for (int j = 0; j < A.GetLength(1); ++j)
        Console.Write((i <= j ? A[i, j] : 0).ToString("F3") + (j < A.GetLength(1) - 1 ? "\t" : Environment.NewLine));
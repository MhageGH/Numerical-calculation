int N = 10000000, n = 0;
var random = new Random();
for (int i = 0; i < N; i++)
{
    double r2 = 0;
    for (int j = 0; j < 3; j++) r2 += Math.Pow(random.NextDouble() - 0.5, 2);
    if (r2 <= Math.Pow(0.5, 2)) n++;
}
var V = (double)n / (double)N;
Console.WriteLine("V = " + V);
Console.WriteLine("π = " + 3.0 / 4.0 * V * Math.Pow(0.5, -3));
double f(double[] xs)   // f(x1,x2, …, x10) = x1x2…x10
{
    double p = 1;
    for (int i = 0; i < xs.Length; ++i) p *= xs[i];
    return p;
}

var random = new Random();
int N = 1000000;
double s = 0;
for (int i = 0; i < N; ++i)
{
    var xs = new double[10];
    for (int j = 0; j < xs.Length; ++j) xs[j] = random.NextDouble();
    s += f(xs) * (1.0 / N);
}
Console.WriteLine(s);
int N = 10000000, n = 0;
var randaom = new Random();
for (int j = 0; j < N; ++j)
{
    long s = 0;
    for (int i = 0; i < 10; ++i) s += randaom.NextInt64(1, 7);
    if (20 <= s && s <= 30) n++;
}
Console.WriteLine((double)n / (double)N * 100.0 + "%");
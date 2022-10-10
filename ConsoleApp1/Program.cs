var fs = new Func<double[], double, double>[]   // 微分方程式の右辺(ベクトルに対応)
{
    (xs, t) => xs[2],   // xs はベクトル(x, y, u, v)
    (xs, t) => xs[3],
    (xs, t) => -xs[0] / Math.Pow(xs[0] * xs[0] + xs[1] * xs[1], 3.0 / 2),
    (xs, t) => -xs[1] / Math.Pow(xs[0] * xs[0] + xs[1] * xs[1], 3.0 / 2)
};
double[] Euler(double[] xs, double h, double t)  // オイラー法
{
    var xs_next = new double[xs.Length];
    for (int i = 0; i < xs.Length; ++i) xs_next[i] = xs[i] + h * fs[i](xs, t);
    return xs_next;
}
double[] ModifiedEuler(double[] xs, double h, double t)  // 修正オイラー法
{
    var xs_temp = Euler(xs, h, t);
    var xs_next = new double[xs.Length];
    for (int i = 0; i < xs.Length; ++i) xs_next[i] = xs[i] + h * (fs[i](xs, t) + fs[i](xs_temp, t + h)) / 2.0;
    return xs_next;
}
double[] RungeKutta(double[] xs, double h, double t)     // ルンゲクッタ法
{
    double[,] fss = new double[xs.Length, 4];
    double[] xs_next = new double[xs.Length];
    for (int i = 0; i < xs.Length; ++i) fss[i, 0] = fs[i](xs, t);
    for (int i = 0; i < xs.Length; ++i) xs_next[i] = xs[i] + h * fss[i, 0] / 2;
    for (int i = 0; i < xs.Length; ++i) fss[i, 1] = fs[i](xs_next, t + h / 2);
    for (int i = 0; i < xs.Length; ++i) xs_next[i] = xs[i] + h * fss[i, 1] / 2;
    for (int i = 0; i < xs.Length; ++i) fss[i, 2] = fs[i](xs_next, t + h / 2);
    for (int i = 0; i < xs.Length; ++i) xs_next[i] = xs[i] + h * fss[i, 2];
    for (int i = 0; i < xs.Length; ++i) fss[i, 3] = fs[i](xs_next, t + h);
    for (int i = 0; i < xs.Length; ++i) xs_next[i] = xs[i] + h * (fss[i, 0] + 2 * fss[i, 1] + 2 * fss[i, 2] + fss[i, 3]) / 6;
    return xs_next;
}
const double t0 = 0, t1 = 30.0, h = 0.01, e = 0.001;
var fileNames = new String[] { "オイラー法.csv", "修正オイラー法.csv", "ルンゲクッタ法.csv" };
var methods = new Func<double[], double, double, double[]>[] { Euler, ModifiedEuler, RungeKutta };
for (int i = 0; i < fileNames.Length; i++)
{
    var xs = new double[] { 3, 0, 0.3, 0.2 };   // (x, y, u, v)の初期値
    var sb = new System.Text.StringBuilder();
    sb.AppendLine("t,x,y");
    for (double t = t0; t <= t1 + e; t += h)
    {
        sb.AppendLine(t + "," + xs[0] + "," + xs[1]);
        xs = methods[i](xs, h, t);
    }
    File.WriteAllText(fileNames[i], sb.ToString());
}
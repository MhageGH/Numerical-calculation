double f (double x, double t) { // 微分方程式の右辺 ⇒ 厳密解 tanh(t)
    return 1.0 - x * x; 
}

double Euler(double x, double h, double t)  // オイラー法
{
    return x + h * f(x, t);
}

double ModifiedEuler(double x, double h, double t)  // 修正オイラー法
{
    return x + h * (f(x, t) + f(x + h * f(x, t), t + h)) / 2.0;
}

const double t0 = 0, t1 = 1.6;  // 定義域
const double x0 = 0;            // 初期値
const double h = 0.05;          // 刻み幅
const double e = 0.001;         // 定義域拡大量(浮動小数点の誤差による終端部抜け防止)
var methodName = new String[] { "オイラー法：", "修正オイラー法：" };

for (int i = 0; i < methodName.Length; i++)
{
    Console.WriteLine(methodName[i]);
    double x = x0, error = 0;
    for (double t = t0; t <= t1 + e; t += h)
    {
        error = Math.Max(Math.Abs(x - Math.Tanh(t)), error);    // 厳密解tanh(t)との差
        if (i == 0) x = Euler(x, h, t);
        else if (i == 1) x = ModifiedEuler(x, h, t);
    }
    Console.WriteLine("誤差の最大値 = " + error.ToString("F10") + Environment.NewLine);
}
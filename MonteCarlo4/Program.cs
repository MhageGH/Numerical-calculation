using System.Numerics;

const int N_divide = 50;
var walk = new Vector2[] { new Vector2(-1, 0), new Vector2(1, 0), new Vector2(0, -1), new Vector2(0, 1) };
var random = new Random();
var sb = new System.Text.StringBuilder();
for (int j = 0; j < N_divide; ++j)
{
    for (int i = 1; i < N_divide; ++i)
    {
        double temperature = 0;
        const int N_walk = 10000;
        for (int k = 0; k < N_walk; ++k)
        {
            var position = new Vector2(i, j);
            while (true)
            {
                position += walk[random.Next() % 4];
                if (position.X == 0 || position.X == N_divide || position.Y == 0) break;
                else if (position.Y == N_divide)
                {
                    temperature += 100;
                    break;
                }
            }
        }
        temperature /= N_walk;
        sb.Append(temperature.ToString("F3") + "\t");
    }
    sb.Append("\r\n");
}
System.IO.File.WriteAllText("Laplace.txt", sb.ToString());
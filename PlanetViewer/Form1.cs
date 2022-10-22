namespace PlanetViewer
{
    public partial class Form1 : Form
    {
        List<double>[] t = new List<double>[3], x = new List<double>[3], y = new List<double>[3];
        int currentNumber = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 注) Planetプロジェクトの実行ファイルのあるフォルダに出力される以下のファイルを本プロジェクトの実行フォルダにコピーすること
            var filename = new String[] { "オイラー法.csv", "修正オイラー法.csv", "ルンゲクッタ法.csv" };  
            for (int i = 0; i < filename.Length; i++)
            {
                t[i] = new List<double>();
                x[i] = new List<double>();
                y[i] = new List<double>();
                var sr = File.OpenText(filename[i]);
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line != null)
                    {
                        var word = line.Split(',');
                        if (word[0] != "t")
                        {
                            t[i].Add(Convert.ToDouble(word[0]));
                            x[i].Add(Convert.ToDouble(word[1]));
                            y[i].Add(Convert.ToDouble(word[2]));
                        }
                    }
                }
            }
        }

        void Draw(int methodNo, PaintEventArgs e)
        {
            var points = new PointF[currentNumber];
            for (int i = 0; i < currentNumber; i++)
            {
                points[i].X = 100.0f * (float)x[methodNo][i] + 50.0f;
                points[i].Y = -100.0f * (float)y[methodNo][i] + 150.0f;
            }
            if (currentNumber != 0)
            {
                e.Graphics.DrawLines(Pens.White, points);
                float r = 10.0f;
                e.Graphics.FillEllipse(Brushes.DeepSkyBlue, points[currentNumber - 1].X - r, points[currentNumber - 1].Y - r, 2 * r, 2 * r);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(0, e);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Draw(1, e);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Draw(2, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var pictureBoxs = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3 };
            foreach (var pictureBox in pictureBoxs) pictureBox.Invalidate();
            currentNumber += 10;
            if (currentNumber >= t[0].Count)
            {
                timer1.Stop();
                currentNumber = currentNumber = t[0].Count - 1;
            }
        }
    }
}
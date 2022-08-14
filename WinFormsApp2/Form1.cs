using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
               

                using var image = SixLabors.ImageSharp.Image.Load(openFileDialog1.FileName);
                image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                image.Save(Path.GetDirectoryName(openFileDialog1.FileName)+"\\output.png");
            }
        }
    }
}
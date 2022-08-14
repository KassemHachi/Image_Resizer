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
        private void ResizeFunc(int width,int Height, string path,string name)
        {
            using var image = SixLabors.ImageSharp.Image.Load(path);
            image.Mutate(x => x.Resize( width,Height));
            image.Save(Path.GetDirectoryName(path) +"\\"+ name + "-"+width.ToString()+".png");
        }
        string pathImage = "";
        string imageName = "";
        string safeName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                pathImage = openFileDialog1.FileName;
                safeName = openFileDialog1.SafeFileName;
                label1.Text = pathImage;
                
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                for (int x = 0; x < listBox1.Items.Count; x++)
                {
                    ResizeFunc(int.Parse(listBox1.Items[x].ToString()), int.Parse(listBox2.Items[x].ToString()), pathImage, safeName); ;

                }
                this.Cursor = Cursors.Default;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value !=0 && numericUpDown2.Value != 0)
            {
                listBox1.Items.Add(numericUpDown1.Value);
                listBox2.Items.Add(numericUpDown2.Value);
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex=listBox2.SelectedIndex;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int selectedIndex = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(selectedIndex);
            listBox2.Items.RemoveAt(selectedIndex);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
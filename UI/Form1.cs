using _163311055_ysa.Classes;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _163311055_ysa
{
    /// <summary>
    /// NeuronDotNet Adlı kütüphane Nuhet ten indirilmiştir. Bu dll ile gerekli işlemler kullanılmıştır. 
    /// </summary>
    public partial class UI_YSA : Form
    {
        /// <summary>
        /// TrainingSet değişken tanımlaması
        /// </summary>
        TrainingSet trainingSet = new TrainingSet(35, 5);
        #region  CONSTRUCTOR
        public UI_YSA()
        {
            InitializeComponent();
        }
        #endregion

        #region CLICK / EVENT

        #region Butona Tıklanıldığında Arka plan Renginin Siyah olması Sağlanılıyor ve Klavye Durumu DragOver işlevi yerine getiriliyor... 
        private void button31_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Black)
            {
                ((Button)sender).BackColor = SystemColors.Control;
                return;
            }
              ((Button)sender).BackColor = Color.Black;
        }

        private void button31_DragOver(object sender, DragEventArgs e)
        {
            button31_Click(sender, e);
        }
        #endregion

        #region Temizle Aksiyonuna Basıldığında Butonların Temizlenmesi Sağlanılıyor 
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Button item in panelMatrisContainer.Controls)
            {
                if (item is Button)
                    item.BackColor = SystemColors.Control;
            }
        }
        #endregion

        #region Tanımla Butonuna tıklanıldığında gerçekleşecek işlemler yer almaktadır ..
        private void btnTanımla_Click(object sender, EventArgs e)
        {
            Define();
        }
        #endregion

        /// <summary>
        /// Form Load -> Ekran ilk açılırken çalışacak kısımdır ... 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_YSA_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Eğit aksiyonuna tıklanıldığında gerçekleeşcek olaylar yer almaktadır .. 
        private void btnEgit_Click(object sender, EventArgs e)
        {
            DataSetLoadAndInOutResult();
            
            Constansts.network.SetLearningRate(Convert.ToDouble(txtLearningRate.Text));
            Constansts.network.Learn(trainingSet, Convert.ToInt32(txtIteration.Text));
            lstLog.Items.Insert(Constansts.zeros, Constansts.succesfull);

            //Buton Enabled Düzenlemesi Yapılıyor
            txtLearningRate.Enabled = false;
            txtIteration.Enabled = false;

            lblError.Text += Constansts.network.MeanSquaredError.ToString();
            txtLearning.Text += Constansts.network.InputLayer.LearningRate.ToString();
            btnEgit.Enabled = false;
            btnTanımla.Enabled = true;
        }
        #endregion

        /// <summary>
        /// Timer yer almaktadır. Burada belirlemiş olduğum tect ifadesi kayan yazı şeklinde yer almaktadır .. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTeacher.Text = lblTeacher.Text.Substring(1) + lblTeacher.Text.Substring(0, 1);
        }

        #region Çıkış yapma butonu 
        private void button34_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Constansts.WouldYouOutput,
                                Constansts.Answer,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }
        #endregion

        #region Tam Ekran Modunu Açma - Kapama İşlevini Sağlamaktadır.
        private void chkFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            #region Tam Ekranı Modunu Açar
            if (chkFullScreen.Text == Constansts.FullScreenOpen)
            {
                WindowState = FormWindowState.Maximized;
                chkFullScreen.Text = Constansts.FullScreenClose;
            }
            #endregion
            #region Tam Ekran Modundan Çıkar
            else if (chkFullScreen.Text == Constansts.FullScreenClose)
            {
                WindowState = FormWindowState.Normal;
                chkFullScreen.Text = Constansts.FullScreenOpen;
            }
            #endregion
        }
        #endregion

        #endregion

        #region METHODS

        /// <summary>
        /// Matris Çizilmesi Sağlanılıyor
        /// </summary>
        /// <returns></returns>
        public double[] GetInputs()
        {
            #region Panel içerisindeki butoların kontrolü yapılıyor...
            foreach (Control item in panelMatrisContainer.Controls)
            {
                #region Buton kontrolü sağlanılıyor...
                if (item is Button)
                {
                    int index = Convert.ToInt32(((Button)item).Tag.ToString());
                    if (item.BackColor == Color.Black)
                    {
                        // Gelen index numarasına göre  0 değerleri atanıyor .. 
                        if (index <= 4)
                            Constansts.inputs[Constansts.zeros, index] = Constansts.ones;
                        else if (index <= 9)
                            Constansts.inputs[Constansts.ones, index % Constansts.five] = Constansts.ones;
                        else if (index <= 14)
                            Constansts.inputs[Constansts.two, index % Constansts.five] = Constansts.ones;
                        else if (index <= 19)
                            Constansts.inputs[Constansts.three, index % Constansts.five] = Constansts.ones;
                        else if (index <= 24)
                            Constansts.inputs[Constansts.four, index % Constansts.five] = Constansts.ones;
                        else if (index <= 29)
                            Constansts.inputs[Constansts.five, index % Constansts.five] = Constansts.ones;
                        else if (index <= 34)
                            Constansts.inputs[Constansts.six, index % Constansts.five] = Constansts.ones;
                    }
                    index++;
                }
                #endregion
            }
            #endregion
            double[] response = new double[35];
            Buffer.BlockCopy(Constansts.inputs, 0, response, 0, Constansts.thirtyFive * sizeof(double));
            return response;

        }

        /// <summary>
        /// Ekran ilk açıldığında işlenecek işlemler yer alıyor .. 
        /// </summary>
        public void LoadData()
        {
            timer1.Enabled = true;
            lblTeacher.Text = Constansts.teacherTextValue;
            lstLog.Items.Insert(0, Constansts.defineYSAModel);
            Constansts.inputLayer = new LinearLayer(Constansts.thirtyFive);
            Constansts.hiddenLayer = new SigmoidLayer(Constansts.thirtyFive);
            Constansts.outputLayer = new SigmoidLayer(Constansts.five);
            BackpropagationConnector connector = new BackpropagationConnector(Constansts.inputLayer, Constansts.hiddenLayer);
            BackpropagationConnector connector2 = new BackpropagationConnector(Constansts.hiddenLayer, Constansts.outputLayer);
            Constansts.network = new BackpropagationNetwork(Constansts.inputLayer, Constansts.outputLayer);
            Constansts.network.Initialize();
        }

        /// <summary>
        /// DatSet Yüklenemsi - Giriş Çıkış Belirlenmesi
        /// </summary>
        public void DataSetLoadAndInOutResult()
        {
            #region DataSet Yüklenmesi - Giriş - Çıkış Belirlenmesi
            trainingSet.Add(new TrainingSample(MyDataSet.A, new double[5]
                { Constansts.ones, Constansts.zeros, Constansts.zeros, Constansts.zeros, Constansts.zeros }));
            lstLog.Items.Insert(Constansts.zeros, Constansts.A);
            trainingSet.Add(new TrainingSample(MyDataSet.B, new double[5]
                { Constansts.zeros, Constansts.ones, Constansts.zeros, Constansts.zeros, Constansts.zeros }));
            lstLog.Items.Insert(Constansts.zeros, Constansts.B);
            trainingSet.Add(new TrainingSample(MyDataSet.C, new double[5]
                { Constansts.zeros, Constansts.zeros, Constansts.ones, Constansts.zeros, Constansts.zeros }));
            lstLog.Items.Insert(Constansts.zeros, Constansts.C);
            trainingSet.Add(new TrainingSample(MyDataSet.D, new double[5]
            { Constansts.zeros, Constansts.zeros, Constansts.zeros, Constansts.ones, Constansts.zeros }));
            lstLog.Items.Insert(Constansts.zeros, Constansts.D);
            trainingSet.Add(new TrainingSample(MyDataSet.E, new double[5]
                { Constansts.zeros, Constansts.zeros, Constansts.zeros, Constansts.zeros, Constansts.ones }));
            lstLog.Items.Insert(Constansts.zeros, Constansts.E);
            #endregion
        }

        public void Define()
        {
            if (listBoxOutputs.Items.Count > 0)
            {
                listBoxOutputs.Items.Clear();
                txtMatris.Clear();
            }

            double[] inputMatris = GetInputs();
            lstLog.Items.Insert(0, Constansts.inputMatrixRead);

            #region Tanımlama kısmı 
            double[] output = Constansts.network.Run(inputMatris);
            int index = 1;
            foreach (double item in output)
            {
                listBoxOutputs.Items.Add(index + "-" + item.ToString() + "\n");
                index++;
            }
            lstLog.Items.Insert(0, Constansts.classificationCompleted);
            #endregion

            #region İfade yazılıyor
            index = 1;
            foreach (var item in inputMatris)
            {
                txtMatris.Text += (item.ToString() + "    ");
                if (index % Constansts.five == Constansts.zeros)
                {
                    txtMatris.Text += "\n";
                }
                index++;
            }
            txtMatris.SelectAll();
            txtMatris.SelectionAlignment = HorizontalAlignment.Center;
            txtMatris.DeselectAll();
            #endregion
        }

        #endregion
    }
}

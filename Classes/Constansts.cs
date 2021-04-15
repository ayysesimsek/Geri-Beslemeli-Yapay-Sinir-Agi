using NeuronDotNet.Core.Backpropagation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _163311055_ysa.Classes
{
    public static class Constansts
    {
        #region Properties

        /// <summary>
        /// İndirilmiş olunan kütüphane tanımı kullanılarak network adında değişken tanımlanmıştır.
        /// </summary>
        public static BackpropagationNetwork network;
        /// <summary>
        /// Giriş Katmanı Tanımlanmıştır.
        /// </summary>
        public static LinearLayer inputLayer;
        /// <summary>
        /// Gizli Katman Tanımlanmıştır.
        /// </summary>
        public static SigmoidLayer hiddenLayer;
        /// <summary>
        /// Çıkış Katmanı Tanımlanmıştır.
        /// </summary>
        public static SigmoidLayer outputLayer;

        #endregion

        #region Matris input değeri ..
        public static double[,] inputs =
        {
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0}
        };
        #endregion

        #region Sabit değerler, rakam ve string ifadelerin tanımlaması yer almaktadır ..

        #region Sayılar Tanımlanmıştır.

        /// <summary>
        /// Değer = 35
        /// </summary>
        public static int thirtyFive = 35;
        /// <summary>
        /// Değer = 0
        /// </summary>
        public static int zeros = 0;
        /// <summary>
        /// Değer = 1
        /// </summary>
        public static int ones = 1;
        /// <summary>
        /// Değer = 2
        /// </summary>
        public static int two = 2;
        /// <summary>
        /// Değer = 3
        /// </summary>
        public static int three = 3;
        /// <summary>
        /// Değer = 4
        /// </summary>
        public static int four = 4;
        /// <summary>
        /// Değer = 5
        /// </summary>
        public static int five = 5;
        /// <summary>
        /// Değer = 6
        /// </summary>
        public static int six = 6;

        #endregion

        #region Harf Tanımlaması Yapılmıştır.

        /// <summary>
        /// Değer = A
        /// </summary>
        public static string A = "A";
        /// <summary>
        /// Değer = B
        /// </summary>
        public static string B = "B";
        /// <summary>
        /// Değer = C
        /// </summary>
        public static string C = "C";
        /// <summary>
        /// Değer = D
        /// </summary>
        public static string D = "D";
        /// <summary>
        /// Değer = E
        /// </summary>
        public static string E = "E";

        #endregion

        #region Sayfada kullanılan text ifadeler kullanılmıştır.

        /// <summary>
        /// Değer = Tamamlandı
        /// </summary>
        public static string succesfull = "Tamamlandı";
        /// <summary>
        /// Değer = TAHİR SAĞ - SELÇUK ÜNİVERSİTESİ - TEKNOLOJİ FAKÜLTESİ
        /// </summary>
        public static string teacherTextValue = "TAHİR SAĞ - SELÇUK ÜNİVERSİTESİ - TEKNOLOJİ FAKÜLTESİ      ";
        /// <summary>
        /// Değer = YSA Modelini Tanımlaya Bas
        /// </summary>
        public static string defineYSAModel = "YSA Modelini Tanımlaya Bas!";
        /// <summary>
        /// Değer = Giriş Matrisi Okundu
        /// </summary>
        public static string inputMatrixRead = "Giriş Matrisi Okundu";
        /// <summary>
        /// Değer = Sınıflandırma Tamamlandı
        /// </summary>
        public static string classificationCompleted = "Sınıflandırma Tamamlandı!";

        #endregion

        /// <summary>
        /// FullScreenOpen --> "Tam Ekran Modunu Aç"
        /// </summary>
        public static string FullScreenOpen = "Tam Ekran Modunu Aç";

        /// <summary>
        /// FullScreenClose --> "Tam Ekran Modunu Kapat"
        /// </summary>
        public static string FullScreenClose = "Tam Ekran Modunu Kapat";

        /// <summary>
        /// WouldYouOutput --> "Çıkış yapmak istediğinize emin misiniz ? "
        /// </summary>
        public static string WouldYouOutput = "Çıkış yapmak istediğinize emin misiniz ? ";

        /// <summary>
        /// Answer --> "Soru"
        /// </summary>
        public static string Answer = "Soru";

        #endregion
    }
}

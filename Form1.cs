using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Keras.Models;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using NumSharp;


namespace Lao_Sign_Language_Alphabet_Recognition
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        bool turnOn;
        InferenceSession session = new InferenceSession("C:\\Users\\spxph\\Documents\\nuol\\projects\\Lao-Sign-Language-Alphabet-Recognition\\model\\lsl_model.onnx");
        string[] labels = { "ກ", "ຂ", "ຄ", "ງ", "ຈ", "ຊ", "ຍ", "ດ", "ຕ", "ທ", "ນ", "ບ", "ຜ", "ຝ", "ພ", "ຟ", "ມ", "ຣ", "ລ", "ວ", "ສ", "ຫ", "ອ" };
        int roiWidth = 250;
        int roiHeight = 250;
        public Form1()
        {
            InitializeComponent();
            turnOn = false;
            capture = new VideoCapture();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            var frame = capture.QueryFrame();

            if (frame == null)
            {
                MessageBox.Show("Failed to open camera");
            }

            int topRightX = frame.Width - roiWidth - 50;
            int topRightY = 50;

            CvInvoke.Flip(frame, frame, FlipType.Horizontal);
            Rectangle rect = new Rectangle(topRightX, topRightY, roiWidth, roiHeight);
            CvInvoke.Rectangle(frame, rect, new MCvScalar(0, 255, 0), 1);

            Mat roi = new Mat(frame, rect);
            var bmp = frame.ToBitmap();
            var roi_bmp = roi.ToBitmap();

            pictBox.Image?.Dispose();
            pictBoxRoi.Image?.Dispose();

            pictBoxRoi.Image = roi_bmp;
            pictBox.Image = bmp;

            NDArray imgArray = np.zeros(new Shape(roi.Rows, roi.Cols, 3));
            
            // Access pixel data and populate imgArray
            for (int i = 0; i < roi.Rows; i++)
            {
                for (int j = 0; j < roi.Cols; j++)
                {
                    // Get pixel value (BGR channels)
                    Vec3b color = roi.Data[i, j];

                    // Populate imgArray with pixel values
                    imgArray[i, j, 0] = color.Item0 / 255.0;
                    imgArray[i, j, 1] = color.Item1 / 255.0;
                    imgArray[i, j, 2] = color.Item2 / 255.0;
                }
            }

            // Reshape and normalize the image array
            NDArray img = imgArray.Reshape(1, roi.Rows, roi.Cols, 3);
            img /= 255.0;

            // Create tensor
            var tensor = new DenseTensor<float>(new[] { 1, roi.Rows, roi.Cols, 3 }, img.ToArray<float>());

            // Run inference
            var inputs = new[] { session.InputMetadata.Keys.GetEnumerator().Current };
            var outputs = session.Run(inputs, new[] { tensor });
            var output = outputs.GetEnumerator().Current;

            // Convert output tensor to array
            var prediction = output.ToArray<float>();
            int predictedLabelIndex = Array.IndexOf(prediction, prediction.Max());
            double confidence = prediction[predictedLabelIndex];
            string predictedLabel = labels[predictedLabelIndex];

            predict.Text = predict.Text + "  " + predictedLabel;
            lblConfidence.Text = lblConfidence.Text + "  " + confidence.ToString();
                 
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            turnOn = true;
            Application.Idle += Application_Idle;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            turnOn = false;
            Application.Idle -= Application_Idle;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture?.Dispose();
        }
    }
}

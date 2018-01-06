using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MetroFramework.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WindowsFormsApp3
{
    public partial class Form1 : MetroForm
    {



       
        List<Image<Bgr, byte>> trainingImages = new List<Image<Bgr, byte>>();
        Image<Gray, Byte> save_face_frame ;
        private CascadeClassifier haarcascade_frontalface_default;
            int k = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            haarcascade_frontalface_default = new CascadeClassifier(@"D:\OpenCV\opencv\build\etc\haarcascades\haarcascade_frontalface_default.xml");


            string[] fileEntries = Directory.GetFiles(Application.StartupPath +"/photos");
            foreach (string fileName in fileEntries)
            {
               


                trainingImages.Add(new Image<Bgr, byte>(fileName));

            }

                foreach (var images in trainingImages)
                {

                k++;

                    Image<Gray, Byte> grayFrame = images.Convert<Gray, Byte>();
                    var detectedFaces_default = haarcascade_frontalface_default.DetectMultiScale(grayFrame);

                    foreach (var detectedFace in detectedFaces_default)
                    {


                         save_face_frame = grayFrame.GetSubRect(detectedFace);
                        




                    }




                    save_face_frame = save_face_frame.Resize(200,200,Emgu.CV.CvEnum.Inter.Cubic);
                    save_face_frame.ToBitmap().Save(Application.StartupPath + "/photos-finished/" +"face"+ k + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);


                





            }








        }
    }
}

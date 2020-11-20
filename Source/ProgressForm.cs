using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProgressForm : Form
    {
        private String fileName;
        private Form1 form1;
        private string type;
        private int uploadCount;
        private int resultCount;
        private string result;
        private Bitmap bitmap;
        private string status, state;
        private int fileCount;
        private string dir;

        public ProgressForm(String type)
        {
            InitializeComponent();

            int count;
            dir = Directory.GetCurrentDirectory();
            progressBar.Value = progressBar.Minimum;
            uploadCount = 0;

            Console.WriteLine("already");
            this.type = type;

            if (type == "Count")
            {
                this.Text = "Counting";
                progressBar.Style = ProgressBarStyle.Marquee;
            }
            else if (type == "Status")
            {
                this.Text = "Checking";
                progressBar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                this.Text = "Retrieving";
                progressBar.Style = ProgressBarStyle.Continuous;
            }

            BackgroundWorker worker = new BackgroundWorker();
            //worker.WorkerReportsProgress = true;
            /*  worker.DoWork += workerDoWork;
              worker.RunWorkerCompleted += worker_Completed;
              worker.RunWorkerAsync();*/
            

        }

        


        void workerDoWork(Object sender, DoWorkEventArgs e)
        {

            crowdCount();
                
            
        }
        
            
         void worker_Completed(Object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            
            

        }


        int crowdCount()
        {
            Console.WriteLine(dir);
            String dirWithoutName = Path.GetDirectoryName(dir);
            Console.WriteLine(dirWithoutName);
            //  MessageBox.Show(dir);
            //MessageBox.Show(dirWithoutName);
            String batFileName = dir + @"\nanonets-pedestrian-detection\" + Guid.NewGuid() + ".bat";
          //  String batFileName = @"C:\Users\Shafi\CrowdCount\nanonets-pedestrian-detection" + Guid.NewGuid() + ".bat";


            using (StreamWriter batFile = new StreamWriter(batFileName))
            {

                batFile.WriteLine($"cd" + " "  + dir + @"\nanonets-pedestrian-detection");
               // batFile.WriteLine($"cd" + " " + @"C:\Users\Shafi\CrowdCount\nanonets-pedestrian-detection");
                batFile.WriteLine($"python ./code/prediction.py " + fileName);
                batFile.WriteLine("del %0");

                batFile.Close(); 

            }






            resultCount = CountStringOccurences(runCmd(batFileName), "pedestrian");
  

            return resultCount;

        }


        public static int CountStringOccurences(String text, String pattern)
        {
            int count = 0, i = 0;

            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }


        public void setFile(String fileName)
        {
            this.fileName = fileName;
           // Console.WriteLine(fileName);
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            if (type == "Count")
            {
                progressCrowdCount();
            }
            else if (type == "Status")
            {
                ShowStatus();
            }
            else
            {
                copyFilesProgress();
            }
           // this.Dispose();
            
        }

        void progressCrowdCount()
        {
            form1.DisableBtn("count");
            int count = 0;
            this.Show();

            Thread bgThread = new Thread(
                new ThreadStart(() =>
                {
                    count = crowdCount();
                    
                    this.BeginInvoke(
                        new Action(() =>
                        {
                            PictureViewer pictureViewer = new PictureViewer("result", bitmap);
                            pictureViewer.SetBitmap(bitmap);
                            pictureViewer.setResult(result);
                            pictureViewer.SetResultCount(count);
                            pictureViewer.Show();
                            this.Dispose();
                        }
                       ));

                    form1.setResult("Crowd Count: " + count.ToString());
                    form1.EnableBtn("count");
                }
              ));

            try
            {
                bgThread.Start();
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Oops, Something went wrong, Please try again", "Error");
            }
        }

        void copyFiles()
        {
            String folderPath;


            folderPath = BrowseFolder();
            
        }

        public void copyFilesProgress()
        {
            DirectoryInfo directory = new DirectoryInfo(dir + @"\nanonets-pedestrian-detection\images\");
            fileCount = directory.GetFiles().Length;
            form1.DisableBtn("train");
            Thread bgThread = new Thread(
                new ThreadStart(() =>
                {
       
                      string batFileName = dir + @"\nanonets-pedestrian-detection\" + Guid.NewGuid() + ".bat";

                      using (StreamWriter batFile = new StreamWriter(batFileName))
                      {

                          batFile.WriteLine($"cd" + " " + dir + @"\nanonets-pedestrian-detection");
                          batFile.WriteLine("python ./code/upload-training.py");
                          batFile.WriteLine("del %0");

                          batFile.Close();
                      }

                    

                    Process p = new Process();
                    ProcessStartInfo process = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe", "/c" + batFileName);
                    
                   // ProcessStartInfo process = new ProcessStartInfo();
                    process.UseShellExecute = false;
                            process.RedirectStandardOutput = true;
                        process.RedirectStandardError = true;
                    process.RedirectStandardInput = true;
                            process.CreateNoWindow = true;
                    
                            process.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo = process;
                    p.EnableRaisingEvents = true;
                    //p.StartInfo = process;
                    p.OutputDataReceived += writeStreamInfo;
                   // p.ErrorDataReceived += errorStreamInfo;
                    


                 /*    using (Process p = Process.Start(process))
                                 using (StreamReader reader = p.StandardOutput)
                                 {

                         p.StandardInput.WriteLine("cd" + @" C:\Users\Shafi\CrowdCount\nanonets-pedestrian-detection");
                         p.StandardInput.WriteLine("python -u ./code/upload-training.py");
                         string stder = p.StandardError.ReadToEnd();
                         string result = reader.ReadToEnd();
                         Console.WriteLine("result" + result);
                         Console.WriteLine("error" + stder);

                     }*/

                     p.Start();
                     p.BeginOutputReadLine();
                 //   p.BeginErrorReadLine();




                    Console.WriteLine("read");
                      




                           p.WaitForExit();
                    Train();
                    MessageBox.Show("Model is currently under training" + Environment.NewLine + Environment.NewLine + "Please Check after 1 hour" + Environment.NewLine + Environment.NewLine + "You can check the training status by clicking the button Check Status" + Environment.NewLine + Environment.NewLine + "You can start crowd counting when status shows ready" + Environment.NewLine + Environment.NewLine + "Do not close the Application, you may minimize it", "Training Started");
                    form1.EnableBtn("train");
                    Console.WriteLine("exit");
                    
                    this.BeginInvoke(
                        new Action(() =>
                        {
                            this.Dispose();
                        }
                       ));

                    
                }
              ));

            bgThread.Start();
            Console.WriteLine("stoped");
        }

        private void ShowStatus()
        {
            form1.DisableBtn("status");
            Thread bgThread = new Thread(
               new ThreadStart(() =>
               {
                   string batFileName = dir + @"\nanonets-pedestrian-detection\" + Guid.NewGuid() + ".bat";

                   using (StreamWriter batFile = new StreamWriter(batFileName))
                   {

                       batFile.WriteLine($"cd" + " " + dir + @"\nanonets-pedestrian-detection");
                       batFile.WriteLine("python ./code/model-state.py");
                       batFile.WriteLine("del %0");

                       batFile.Close();
                   }

                   runCmd(batFileName);

                   this.BeginInvoke(
                       new Action(() =>
                       {
                           
                           this.Dispose();
                       }
                      ));
                   status = File.ReadAllText( dir + @"\nanonets-pedestrian-detection\status.txt");
                   state = File.ReadAllText( dir + @"\nanonets-pedestrian-detection\state.txt");
                   CrowdStatus crowdStatus = JsonConvert.DeserializeObject<CrowdStatus>(status);

                   if (state == "Ready")
                       MessageBox.Show("Model Status : Ready" + Environment.NewLine + Environment.NewLine + "Accuracy : " + crowdStatus.accuracy, "Training Status");
                   else
                       MessageBox.Show("Model Status : " + crowdStatus.status + Environment.NewLine + Environment.NewLine + "Accuracy : " + crowdStatus.accuracy, "Training Status");

                   form1.EnableBtn("status");
               }
             ));

            try
            {
                bgThread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Oops, Something went wrong, Please try again", "Error");
            }
        }
        private String BrowseFolder()
        {
            String folderPath = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog.RootFolder;
            }

            return folderPath;
        }

        string runCmd(String batFileName)
        {
            
            Process p = new Process();
            ProcessStartInfo process = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe", "/c" + batFileName);

            process.UseShellExecute = false;
            process.RedirectStandardOutput = true;
            process.CreateNoWindow = true;
            process.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo = process;
            p.Start();

            String output = p.StandardOutput.ReadToEnd();

           

           // Console.WriteLine(output);
            

            p.WaitForExit();

            result = File.ReadAllText(dir + @"\nanonets-pedestrian-detection\result.txt");
            return result;
        }

        private void Train()
        {
            string batFileName = dir + @"\nanonets-pedestrian-detection\" + Guid.NewGuid() + ".bat";

            using (StreamWriter batFile = new StreamWriter(batFileName))
            {

                batFile.WriteLine($"cd" + " " + dir + @"\nanonets-pedestrian-detection");
                batFile.WriteLine("python ./code/train-model.py");
                batFile.WriteLine("del %0");

                batFile.Close();
            }
            runCmd(batFileName);
        }

        private void writeStreamInfo(Object sender, DataReceivedEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(dir + @"\nanonets-pedestrian-detection\images");
            int fileCount = directory.GetFiles().Length;
            Console.WriteLine(fileCount.ToString());

            labelStatus.BeginInvoke(
                       new Action(() =>
                       {
                           uploadCount++;
                           float percentage = ((((float)uploadCount - 4) / (float)fileCount) * 100);
                           decimal flooredPercentage = Math.Floor((decimal)percentage);
                           if (uploadCount - 4 >= 1 && flooredPercentage >=0 && flooredPercentage <= 100)
                           {
                               labelRetrieve.Text = "Retrieving Image data";
                               LblCount.Text = "Total Count : " + fileCount.ToString();
                               progressBar.Value = (int)flooredPercentage;


                               Console.WriteLine(flooredPercentage.ToString());
                               labelStatus.Text = e.Data;
                               Console.WriteLine("uploadCount" + (uploadCount - 4).ToString());
                               //label1.Text = e.Data + Environment.NewLine;
                           }
                           Console.WriteLine(e.Data);
                       }
                      ));

                   

           // bgThread.Start();
           // label1.Text = e.Data;
        }

        private void errorStreamInfo(Object sender, DataReceivedEventArgs e)
        {


            label1.BeginInvoke(
                new Action(() =>
                {
                    label1.Text = e.Data + Environment.NewLine;
                    Console.WriteLine(e.Data);
                }
               ));



            // bgThread.Start();
            // label1.Text = e.Data;
        }

        public void setForm1(Form1 form1)
        {
            this.form1 = form1;
            
        }

        public void SetBitmap(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        private void ProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.EnableBtn("count");
            form1.EnableBtn("train");
            this.Dispose();
        }
    }
}

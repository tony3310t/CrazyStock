using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyStock
{
    public partial class WaterOne : Form
    {
        public WaterOne()
        {
            InitializeComponent();

            txt_Up.Text = "5";
            txt_Volume5.Text = "500";
            txt_VolumeUp.Text = "2";
            txt_Smooth.Text = "20";
            txt_ThresholdPercent.Text = "0.07";
            txt_ThresholdDay.Text = "5";
            Search();
        }

        public void Search()
        {
            BasicInfo BI = BasicInfo.GetInstance;

            double Up = (Convert.ToDouble(txt_Up.Text.Trim()))*0.01;
            double Volume5 = Convert.ToDouble(txt_Volume5.Text.Trim());
            double VolumeUp = Convert.ToDouble(txt_VolumeUp.Text.Trim());
            double Smooth = Convert.ToDouble(txt_Smooth.Text.Trim());
            double ThresholdPercent = Convert.ToDouble(txt_ThresholdPercent.Text.Trim());
            int ThresholdDay = Convert.ToInt32(txt_ThresholdDay.Text.Trim());

            for (int i=0; i< BI.lisBI.Count; i++)
            {
                int Move = 0;
                double Standar1 = 0;
                int Standar1Count = 0;
                int Standar1Move = 0;

                double Standar2 = 0;
                int Standar2Count = 0;
                int Standar2Move = 0;

                for (int j=0; j< BI.lisBI[i].lieB.Count; j++)
                {
                    if(j == 0)
                    {
                        if (BI.lisBI[i].lieB[0].UpDown < Up || BI.lisBI[i].lieB[0].Volume5 < Volume5
                            || BI.lisBI[i].lieB[0].Volume < BI.lisBI[i].lieB[0].Volume5 * VolumeUp
                            || BI.lisBI[i].lieB[0].Close < (BI.lisBI[i].lieB[0].MA20 + (BI.lisBI[i].lieB[0].SD20 * 2.1)))
                        {
                            break;
                        }

                        if (BI.lisBI[i].lieB.Count > 2)
                        {
                            Standar1 = BI.lisBI[i].lieB[1].Close;
                            Standar2 = BI.lisBI[i].lieB[2].Close;
                        }
                    }

                    if(j == 1)
                    {
                        if(BI.lisBI[i].lieB[1].Close > (BI.lisBI[i].lieB[1].MA20 + (BI.lisBI[i].lieB[1].SD20 * 2.1)))
                        {
                            break;
                        }
                    }

                    if(j>1)
                    {
                        if((BI.lisBI[i].lieB[j].Close / Standar1) > (1 + ThresholdPercent) 
                            || (BI.lisBI[i].lieB[j].Close / Standar1) < (1 - ThresholdPercent))
                        {
                            Standar1Move++;
                        }
                        else
                        {
                            Standar1Count++;
                        }
                    }

                    if (j > 2)
                    {
                        if ((BI.lisBI[i].lieB[j].Close / Standar2) > (1 + ThresholdPercent) 
                            || (BI.lisBI[i].lieB[j].Close / Standar2) < (1 - ThresholdPercent))
                        {
                            Standar2Move++;
                        }
                        else
                        {
                            Standar2Count++;
                        }
                    }

                    if(Standar1Move > ThresholdDay)
                    {
                        Standar1 = 100000;
                    }

                    if (Standar2Move > ThresholdDay)
                    {
                        Standar2 = 100000;
                    }
                    
                    if (j == BI.lisBI[i].lieB.Count - 1)
                    {
                        if(Standar1Count > Smooth || Standar2Count > Smooth)
                        {
                            if(Standar1Count >= Standar2Count)
                            {
                                string s = BI.lisBI[i].StockNo;
                            }
                            else
                            {
                                string s = BI.lisBI[i].StockNo;
                            }
                        }
                        else
                        {
                            string s = BI.lisBI[i].StockNo;
                        }                       
                    }

                    /*
                    if (Move > 5)
                    {
                        if (Count > Smooth)
                        {
                            string s = BI.lisBI[i].StockNo;
                        }
                            
                        break;
                    }

                    if(j == BI.lisBI[i].lieB.Count-1)
                    {
                        string s = BI.lisBI[i].StockNo;
                    }*/

                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}

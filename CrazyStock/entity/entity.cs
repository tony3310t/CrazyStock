using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyStock
{
    class Stock
    {
        public string StockNo { get; set; }
        public string StockName { get; set; }
    }
    class entityRonche
    {
        public DateTime RoncheDate { get; set; }
        public int RoncheBuy { get; set; }
        public int RoncheSell { get; set; }
        public int RoncheReturn { get; set; }
        public int RoncheUse { get; set; }
        public int RoncheSub { get; set; }
        public int RoncheLimit { get; set; }
        public double RoncheUseRate { get; set; }
        public double RoncheUseRateSub { get; set; }

        public int ChenBuy { get; set; }
        public int ChenSell { get; set; }
        public int ChenReturn { get; set; }
        public int ChenUse { get; set; }
        public int ChenSub { get; set; }
    }

    class StockRonche
    {
        public string StockNo { get; set; }
        public List<entityRonche> lieR { get; set; }
    }

    class entityForeign
    {
        public DateTime ForeignDate { get; set; }
        public int ForeignBuy { get; set; }
        public int ForeignSell { get; set; }
        public int ForeignSub { get; set; }
        public int ForeignKeep { get; set; }
        public double ForeignKeepRate { get; set; }
        public double ForeignRateSub { get; set; }
    }

    class StockForeign
    {
        public string StockNo { get; set; }
        public List<entityForeign> lieF { get; set; }
    }

    class entityMA
    {
        public DateTime MADate { get; set; }
        public double Close { get; set; }
        public double MA20 { get; set; }
        public double Volume5 { get; set; }
    }

    class StockMA
    {
        public string StockNo { get; set; }
        public entityMA eMA { get; set; }
    }

    public class entityBasicInfo
    {
        public string Date { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double EPS { get; set; }
        public double UpDown { get; set; }
        public double Volume { get; set; }
        public double Volume5 { get; set; }
        //public double Volume20 { get; set; }
        public double MA5 { get; set; }
        public double MA20 { get; set; }
        //public double MA60 { get; set; }
        public double SD20 { get; set; }
    }

    public class stockBasicInfo
    {
        public string StockNo { get; set; }
        public List<entityBasicInfo> lieB { get; set; }
    }

    public class BasicInfo
    {
        public List<stockBasicInfo> lisBI { get; set; }

        private static readonly object Mutex = new object();
        private static volatile BasicInfo _instance;

        private BasicInfo()
        {
            lisBI = new List<stockBasicInfo>();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            System.IO.StreamReader file = new System.IO.StreamReader(appDataPath + "\\stockList.csv");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                System.IO.StreamReader SRreader = null;

                try
                {
                    SRreader = new System.IO.StreamReader(appDataPath + "\\StockData\\" + line + "\\BasicInfo.txt");
                    string str = SRreader.ReadToEnd();
                    SRreader.Close();
                    string jsonString = str;

                    stockBasicInfo tmpsBI = new stockBasicInfo();
                    tmpsBI.StockNo = line.Trim();
                    tmpsBI.lieB = new List<entityBasicInfo>();

                    Newtonsoft.Json.Linq.JArray jArry = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonString.Trim());
                    foreach (JObject content in jArry.Children<JObject>())
                    {
                        entityBasicInfo tmpeBI = new entityBasicInfo();
                        foreach (JProperty prop in content.Properties())
                        {
                            switch (prop.Name.Trim())
                            {
                                case "Date":
                                    tmpeBI.Date = prop.Value.ToString().Trim();
                                    break;
                                case "Open":
                                    tmpeBI.Open = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "Close":
                                    tmpeBI.Close = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "High":
                                    tmpeBI.High = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "Low":
                                    tmpeBI.Low = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "EPS":
                                    tmpeBI.EPS = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "UpDown":
                                    tmpeBI.UpDown = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "Volume":
                                    tmpeBI.Volume = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "Volume5":
                                    tmpeBI.Volume5 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "MA5":
                                    tmpeBI.MA5 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "MA20":
                                    tmpeBI.MA20 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "SD20":
                                    tmpeBI.SD20 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                            }
                        }

                        tmpsBI.lieB.Add(tmpeBI);
                    }

                    lisBI.Add(tmpsBI);
                }
                catch (Exception e)
                {

                }
                finally
                {
                    
                }
            }

            file.Close();
        }

        public static BasicInfo GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Mutex)
                    {
                        if (_instance == null)
                            _instance = new BasicInfo();
                    }
                }
                return _instance;
            }
        }
    }
}

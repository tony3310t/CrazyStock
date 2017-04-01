using CCWin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CrazyStock
{
    public partial class Ronche : CCSkinMain
    {
        List<StockRonche> liSR;
        List<StockForeign> liSF;
        List<StockMA> liSMA;
        List<Stock> liStock;

        public Ronche()
        {
            InitializeComponent();

            GetBasicInfo();

            Thread tStock = new Thread(GetStockList);
            tStock.Start();
            /*Thread tRonche = new Thread(GetRoncheInfo);
            tRonche.Start();*/

            Thread tForeign = new Thread(GetForeignInfo);
            tForeign.Start();

            Thread tMA = new Thread(GetMAandVolumeInfo);
            tMA.Start();


            /*Object obj = SearchRonche(10, 30, 5);
            List<StockRonche> li = obj as List<StockRonche>;

            DataTable dt = new DataTable("table");
            DataColumn colItem = new DataColumn("StockNo", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("RecentDay", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("RoncheBottom", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            
            DataRow NewRow;
            for (int i=0; i<li.Count; i++)
            {
                NewRow = dt.NewRow();
                NewRow["StockNo"] = li[i].StockNo;
                NewRow["RecentDay"] = 10;
                NewRow["RoncheBottom"] = li[i].lieR[0].RoncheUseRate;
                dt.Rows.Add(NewRow);
            }

            gv_List.DataSource = dt;*/
        }

        public void GetStockList()
        {
            liStock = new List<Stock>();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        
            System.IO.StreamReader SRreader = new System.IO.StreamReader(appDataPath + "\\StockListMap.txt");
            string str = SRreader.ReadToEnd();
            string jsonString = str;

            Newtonsoft.Json.Linq.JArray jArry = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonString.Trim());
            foreach (JObject content in jArry.Children<JObject>())
            {
                foreach (JProperty prop in content.Properties())
                {
                    Stock stock = new Stock();
                    stock.StockNo = prop.Name.Trim();
                    stock.StockName = prop.Value.ToString().Trim();
                    liStock.Add(stock);
                }                
            }                    
        }

        public void GetRoncheInfo()
        {
            liSR = new List<StockRonche>();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            System.IO.StreamReader file = new System.IO.StreamReader(appDataPath + "\\stockList.csv");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    StockRonche SR = new StockRonche();
                    SR.StockNo = line;
                    SR.lieR = new List<entityRonche>();
                    System.IO.StreamReader SRreader = new System.IO.StreamReader(appDataPath + "\\StockData\\" + line + "\\Ronche.txt");
                    string str = SRreader.ReadToEnd();
                    string jsonString = str;

                    Newtonsoft.Json.Linq.JArray jArry = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonString.Trim());
                    foreach (JObject content in jArry.Children<JObject>())
                    {
                        entityRonche eR = new entityRonche();
                        eR.RoncheUseRateSub = 0;
                        foreach (JProperty prop in content.Properties())
                        {
                            switch (prop.Name.Trim())
                            {
                                case "RoncheDate":
                                    eR.RoncheDate = Convert.ToDateTime(prop.Value.ToString().Trim());
                                    break;
                                case "RoncheBuy":
                                    eR.RoncheBuy = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "RoncheSell":
                                    eR.RoncheSell = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "RoncheReturn":
                                    eR.RoncheReturn = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "RoncheUse":
                                    eR.RoncheUse = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "RoncheChange":
                                    eR.RoncheSub = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "RoncheTotal":
                                    eR.RoncheLimit = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "RonchePercent":
                                    eR.RoncheUseRate = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;

                                case "ChenSell":
                                    eR.ChenSell = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ChenBuy":
                                    eR.ChenBuy = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ChenReturn":
                                    eR.ChenReturn = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ChenUse":
                                    eR.ChenUse = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ChenChange":
                                    eR.ChenSub = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                            }
                        }

                        SR.lieR.Add(eR);
                    }

                    liSR.Add(SR);
                }
                catch(Exception e)
                {

                }
            }

            file.Close();
                       
        }

        public void GetForeignInfo()
        {
            liSF = new List<StockForeign>();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            System.IO.StreamReader file = new System.IO.StreamReader(appDataPath + "\\stockList.csv");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    StockForeign SF = new StockForeign();
                    SF.StockNo = line;
                    SF.lieF = new List<entityForeign>();
                    System.IO.StreamReader SRreader = new System.IO.StreamReader(appDataPath + "\\StockData\\" + line + "\\Foreign.txt");
                    string str = SRreader.ReadToEnd();
                    string jsonString = str;

                    Newtonsoft.Json.Linq.JArray jArry = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonString.Trim());
                    foreach (JObject content in jArry.Children<JObject>())
                    {
                        entityForeign eF = new entityForeign();
                        eF.ForeignRateSub = 0;
                        foreach (JProperty prop in content.Properties())
                        {
                            switch (prop.Name.Trim())
                            {
                                case "ForeignDate":
                                    eF.ForeignDate = Convert.ToDateTime(prop.Value.ToString().Trim());
                                    break;
                                case "ForeignBuy":
                                    eF.ForeignBuy = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ForeignSell":
                                    eF.ForeignSell = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ForeignSub":
                                    eF.ForeignSub = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ForeignKeep":
                                    eF.ForeignKeep = Convert.ToInt32(prop.Value.ToString().Trim());
                                    break;
                                case "ForeignRate":
                                    eF.ForeignKeepRate = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;

                            }
                        }

                        SF.lieF.Add(eF);
                    }

                    liSF.Add(SF);
                }
                catch(Exception e)
                {

                }
            }

            file.Close();
            
        }

        public void GetBasicInfo()
        {
            //liSF = new List<StockForeign>();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            System.IO.StreamReader file = new System.IO.StreamReader(appDataPath + "\\stockList.csv");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    //StockForeign SF = new StockForeign();
                    //SF.StockNo = line;
                    //SF.lieF = new List<entityForeign>();
                    System.IO.StreamReader SRreader = new System.IO.StreamReader(appDataPath + "\\StockData\\" + line + "\\BasicInfo.txt");
                    string str = SRreader.ReadToEnd();
                    string jsonString = str;

                    bool Red = false;
                    bool Volume = false;
                    int count = 0;
                    int MoveCount = 0;
                    double dRed = 0;
                    double dVolume = 0;
                    double dV5 = 0;
                    double dMA20 = 0;
                    double dSD20 = 0;

                    Newtonsoft.Json.Linq.JArray jArry = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonString.Trim());
                    foreach (JObject content in jArry.Children<JObject>())
                    {
                        //entityForeign eF = new entityForeign();
                        //eF.ForeignRateSub = 0;
                        foreach (JProperty prop in content.Properties())
                        {
                            switch (prop.Name.Trim())
                            {
                                case "UpDown":
                                    dRed = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "Volume":
                                    dVolume = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "Volume5":
                                    dV5 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "MA20":
                                    dMA20 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "SD20":
                                    dSD20 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                            }
                        }

                        if(count == 0 && (dRed < 0.03 || dVolume < dV5*2 || dVolume<500))
                        {
                            break;
                        }

                        if(dSD20 > dMA20*0.025)
                        {
                            MoveCount++;
                        }

                        if(MoveCount > 5)
                        {
                            if(count > 20)
                            {
                                string a = line;
                            }
                                
                            break;
                        }

                        count++;

                        //SF.lieF.Add(eF);
                    }

                    //liSF.Add(SF);
                }
                catch (Exception e)
                {

                }
            }

            file.Close();

        }

        public void GetMAandVolumeInfo()
        {
            liSMA = new List<StockMA>();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            System.IO.StreamReader file = new System.IO.StreamReader(appDataPath + "\\stockList.csv");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    StockMA SMA = new StockMA();
                    SMA.StockNo = line;
                    System.IO.StreamReader SRreader = new System.IO.StreamReader(appDataPath + "\\StockData\\" + line + "\\MAandVolume.txt");
                    string str = SRreader.ReadToEnd();
                    string jsonString = str;

                    Newtonsoft.Json.Linq.JArray jArry = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonString.Trim());
                    foreach (JObject content in jArry.Children<JObject>())
                    {
                        entityMA eMA = new entityMA();
                        
                        foreach (JProperty prop in content.Properties())
                        {
                            switch (prop.Name.Trim())
                            {
                                case "Date":
                                    eMA.MADate = Convert.ToDateTime(prop.Value.ToString().Trim());
                                    break;
                                case "Close":
                                    eMA.Close = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "MA20":
                                    eMA.MA20 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                                case "Volume5":
                                    eMA.Volume5 = Convert.ToDouble(prop.Value.ToString().Trim());
                                    break;
                            }
                        }

                        SMA.eMA = eMA;
                    }

                    liSMA.Add(SMA);
                }
                catch (Exception e)
                {

                }
            }

            file.Close();

        }

        public Object SearchRonche(int RecentDay, int RoncheRateBottom, int RoncheRateAdd)
        {
            List<StockRonche> liTmp = new List<StockRonche>();

            for(int i=0; i< liSR.Count; i++)
            {
                double head = 0;
                double tail = 0;
                for(int j=0; j< liSR[i].lieR.Count; j++)
                {
                    if(j == 0)
                    {
                        tail = liSR[i].lieR[j].RoncheUseRate;
                    }

                    if(j == RecentDay)
                    {
                        head = liSR[i].lieR[j].RoncheUseRate;
                        break;
                    }
                }

                if(tail > RoncheRateBottom && tail-head > RoncheRateAdd)
                {
                    liTmp.Add(liSR[i]);
                }
            }

            return liTmp;
        }

        public Object SearchForeign(int ForeignDay, double ForeignAdd)
        {
            List<StockForeign> liTmp = new List<StockForeign>();

            for (int i = 0; i < liSF.Count; i++)
            {
                double head = 0;
                double tail = 0;
                for (int j = 0; j < liSF[i].lieF.Count; j++)
                {
                    if (j == 0)
                    {
                        tail = liSF[i].lieF[j].ForeignKeepRate;
                    }

                    if (j == ForeignDay)
                    {
                        head = liSF[i].lieF[j].ForeignKeepRate;
                        break;
                    }
                }

                if (tail - head > ForeignAdd)
                {
                    liSF[i].lieF[0].ForeignRateSub = tail - head;
                    liTmp.Add(liSF[i]);
                }
            }

            return liTmp;
        }

        public Object SearchMA()
        {
            List<StockMA> liTmp = new List<StockMA>();

            for (int i = 0; i < liSMA.Count; i++)
            {
                if(liSMA[i].eMA.Close > liSMA[i].eMA.MA20 && liSMA[i].eMA.Volume5 > 500)
                {
                    string s = liSMA[i].StockNo;
                    liTmp.Add(liSMA[i]);
                }
            }

            return liTmp;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            /*Object obj = Search(Convert.ToInt32(txt_RecentDay.Text), Convert.ToInt32(txt_RoncheBottom.Text), Convert.ToInt32(txt_RoncheAdd.Text));
            List<StockRonche> li = obj as List<StockRonche>;

            DataTable dt = new DataTable("table");
            DataColumn colItem = new DataColumn("StockNo", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("RecentDay", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("RoncheBottom", Type.GetType("System.String"));
            dt.Columns.Add(colItem);

            DataRow NewRow;
            for (int i = 0; i < li.Count; i++)
            {
                NewRow = dt.NewRow();
                NewRow["StockNo"] = li[i].StockNo;
                NewRow["RecentDay"] = txt_RecentDay.Text;
                NewRow["RoncheBottom"] = li[i].lieR[0].RoncheUseRate;
                dt.Rows.Add(NewRow);
            }

            gv_List.DataSource = dt;*/

            Object obj = SearchForeign(Convert.ToInt32(txt_ForeignDay.Text), Convert.ToDouble(txt_ForeignAdd.Text));
            List<StockForeign> liForeign = obj as List<StockForeign>;

            obj = SearchMA();
            List<StockMA> liMA = obj as List<StockMA>;

            DataTable dt = new DataTable("table");
            DataColumn colItem = new DataColumn("StockNo", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("StockName", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("RecentDay", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("ForeignAdd", Type.GetType("System.String"));
            dt.Columns.Add(colItem);
            colItem = new DataColumn("ForeignURL", Type.GetType("System.String"));
            dt.Columns.Add(colItem);

            DataRow NewRow;
            for (int i = 0; i < liForeign.Count; i++)
            {
                for(int j=0; j< liMA.Count; j++)
                {
                    if(liMA[j].StockNo == liForeign[i].StockNo)
                    {
                        NewRow = dt.NewRow();
                        NewRow["StockNo"] = liForeign[i].StockNo;

                        for(int k=0; k<liStock.Count; k++)
                        {
                            if(liStock[k].StockNo == liForeign[i].StockNo)
                            {
                                NewRow["StockName"] = liStock[k].StockName;
                                break;
                            }
                        }

                        NewRow["RecentDay"] = txt_ForeignDay.Text;
                        NewRow["ForeignAdd"] = liForeign[i].lieF[0].ForeignRateSub;
                        NewRow["ForeignURL"] = "http://www.cnyes.com/twstock/QFII/" + liForeign[i].StockNo + ".htm";
                        dt.Rows.Add(NewRow);
                        break;
                    }
                }
                
            }

            gv_List.DataSource = dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using System.Net.Mail;

namespace CrazyStock
{
    public partial class Dashboard : CCSkinMain
    {
        public Dashboard()
        {
            InitializeComponent();

            SendByMail();
        }

        private void btn_Ronche_Click(object sender, EventArgs e)
        {
            Ronche Rc = new Ronche();
            Rc.Show();
        }

        private void btn_WaterOne_Click(object sender, EventArgs e)
        {
            WaterOne WO = new WaterOne();
            WO.Show();
        }

        /// <summary> 
        /// 用Client寄信 需New出來
        /// </summary> 
        /// <param name="pMail">收件者可以,分格寄多人</param>
        /// <param name="pSubject">信件標題</param>
        /// <param name="pBody">信件內容</param>
        /// <param name="pFromMailName">寄件人會顯示的標題</param>
        /// <param name="pFromMail">寄件的Email</param>
        public void SendByMail()
        {
            MailMessage mail = new MailMessage();
            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress("xiastudio93@gmail.com", "CrazyStock");

            //收信者email
            mail.To.Add("tony3310t@gmail.com");

            //設定優先權
            mail.Priority = MailPriority.Normal;

            //標題
            mail.Subject = "subject";

            //內容
            mail.Body = @"<HTML><HEAD><TITLE>Your Title Here</TITLE></HEAD><BODY><H1>This is a Header</H1><H2>This is a Medium Header</H2></ BODY ></ HTML > ";

            //內容使用html
            mail.IsBodyHtml = true;

            //設定gmail的smtp
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("xiastudio93", "kehubvfdwmdafndl");

            //開啟ssl
            MySmtp.EnableSsl = true;

            //發送郵件
            MySmtp.Send(mail);

            //放掉宣告出來的MySmtp
            MySmtp = null;

            //放掉宣告出來的mail
            mail.Dispose();

            
        }
    }
}

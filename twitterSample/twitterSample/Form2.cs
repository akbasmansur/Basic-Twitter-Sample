using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace twitterSample
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string _gelenKullaniciVeri, _gelenYerVeri, _gelenTarihVeri, _gelenRetweetVeri, _gelenTweetVeri;
        private string _webAdres;
        private int _linkBaslangic;

        private void Form2_Load(object sender, EventArgs e)
        {
            _gelenKullaniciVeri = frmHome.KullaniciVeri;
            _gelenTarihVeri = frmHome.TarihVeri;
            _gelenYerVeri = frmHome.YerVeri;
            _gelenRetweetVeri = frmHome.RetweetVeri;
            _gelenTweetVeri = frmHome.TweetVeri;

            webBrowser1.DocumentText = "<p style='font-size:16px;font-family:Cambria;font-weight:bold'>" + _gelenKullaniciVeri + "<br/>" + _gelenTarihVeri + " - " + _gelenYerVeri + "</p>" + "<font face='Calibri'>" + _gelenTweetVeri + "<br/><br/>" + "<strong> Retweet: " + _gelenRetweetVeri + "</strong>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _linkBaslangic = _gelenTweetVeri.LastIndexOf("https://", StringComparison.Ordinal);
            _webAdres = _gelenTweetVeri.Substring(_linkBaslangic);
            Process.Start(_webAdres);
        }
    }
}

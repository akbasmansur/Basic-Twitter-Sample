using System;
using System.Windows.Forms;
using TweetSharp;

namespace twitterSample
{
    public partial class frmHome : Form
    {
        // consumerKey,ConsumerSecret,AccessToken,AccessSecret degerlerini bir twitter hesabı aracılığı ile apps.twitter.com.tr
        readonly string ConsumerKey = "";
        readonly string ConsumerSecret = "";
        readonly string AccessToken = "";
        readonly string AccessSecret = "";
        TwitterService service;
        public frmHome()
        {
            InitializeComponent();
            service = new TwitterService(ConsumerKey, ConsumerSecret, AccessToken, AccessSecret);
        }
        public static string KullaniciVeri, YerVeri, TarihVeri, RetweetVeri, TweetVeri;
        private void listTwitter_Click(object sender, EventArgs e)
        {
            ListViewItem seciliVeriler = listView1.SelectedItems[0];
            KullaniciVeri = seciliVeriler.SubItems[0].Text;
            TarihVeri = seciliVeriler.SubItems[1].Text;
            YerVeri = seciliVeriler.SubItems[2].Text;
            RetweetVeri = seciliVeriler.SubItems[3].Text;
            TweetVeri = seciliVeriler.SubItems[4].Text;

            Form2 frmtweetokuac = new Form2();
            frmtweetokuac.ShowDialog();
        }
        private int _tweetSayisi;
        private void btnYenile_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            _tweetSayisi = (int)numericUpDown1.Value;

            try
            {
                var twitterVerileri = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions { Count = _tweetSayisi });

                foreach (TwitterStatus item in twitterVerileri)
                {
                    string[] elemanlar = {  item.User.Name,
                                            item.CreatedDate.ToLocalTime().ToString("dd-MM-yy (hh:mm)"),
                                            item.User.Location,
                                            item.RetweetCount.ToString(),
                                            item.Text };
                    ListViewItem veriler = new ListViewItem(elemanlar);
                    listView1.Items.Add(veriler);
                }
                chUser.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                chDate.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                chTweet.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                chLoc.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch
            {
                MessageBox.Show(@"Doğru anahtarları girmediniz. Lütfen anahtarlarınızı doğru giriniz.", @"Anahtar Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listView1.Focus();
            }
        }
    }
}

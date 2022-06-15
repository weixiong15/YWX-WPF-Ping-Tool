using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.NetworkInformation;

namespace _1085461017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /// 葉偉雄 - 1085461017
            this.listbox.Items.Clear();
            string ipStr = textbox.Text.ToString().Trim();
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "buffer";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(ipStr, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                listbox.Items.Add("1.回應之目標 = " + reply.Address.ToString());
                listbox.Items.Add("2.回傳时间 = " + reply.RoundtripTime);
                listbox.Items.Add("3.存留時間(TTL) = " + reply.Options.Ttl);
                listbox.Items.Add("4.資料包片段 = " + reply.Options.DontFragment);
                listbox.Items.Add("5.数据传输大小 = " + reply.Buffer.Length);
            }
            else
                listbox.Items.Add(reply.Status.ToString());
        }
    }
}

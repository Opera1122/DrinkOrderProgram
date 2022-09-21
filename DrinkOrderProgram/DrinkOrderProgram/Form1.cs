using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DrinkOrderProgram
{
    public partial class Form1 : Form
    {
        int leftMoney = 0; //잔금
        int payout = 0; //결제금액
        int order = 0; //주문
        object text = null;
        string receipt = "영수증.txt";
        int drinkPrice = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("딸기주스");
            payout += 2000;
            label9.Text = Convert.ToString(payout) + "원";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("망고주스");
            payout += 2200;
            label9.Text = Convert.ToString(payout) + "원";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("초코라떼");
            payout += 2500;
            label9.Text = Convert.ToString(payout) + "원";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("아메리카노");
            payout += 1500;
            label9.Text = Convert.ToString(payout) + "원";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox1.SelectedItem.ToString();

                if (listBox1.SelectedItem.Equals("딸기주스"))
                {
                    payout -= 2000;
                    label9.Text = Convert.ToString(payout) + "원";
                }
                else if (listBox1.SelectedItem.Equals("망고주스"))
                {
                    payout -= 2200;
                    label9.Text = Convert.ToString(payout) + "원";
                }
                else if (listBox1.SelectedItem.Equals("초코라떼"))
                {
                    payout -= 2500;
                    label9.Text = Convert.ToString(payout) + "원";
                }
                else if (listBox1.SelectedItem.Equals("아메리카노"))
                {
                    payout -= 1500;
                    label9.Text = Convert.ToString(payout) + "원";
                }

                Convert.ToString(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            leftMoney += 10000;
            label7.Text = Convert.ToString(leftMoney) + "원";
        }

        private void CreateFile()
        {
            int nCount = listBox1.Items.Count;
            for (int i = 0; i < nCount; i++)
            {
                if (listBox1.Items[i].Equals("딸기주스"))
                {
                    drinkPrice = 2000;
                }
                else if (listBox1.Items[i].Equals("망고주스"))
                {
                    drinkPrice = 2200;
                }
                else if (listBox1.Items[i].Equals("초코라떼"))
                {
                    drinkPrice = 2500;
                }
                else if (listBox1.Items[i].Equals("아메리카노"))
                {
                    drinkPrice = 1500;
                }
                text = listBox1.Items[i] + " " + drinkPrice + "원" + "\n";
                File.AppendAllText(receipt, (string)text);
            }
            text = "\n총 결제금액 " + payout + "원" + "\n" + "잔액 " + leftMoney + "원" + "\n\n\n";
            File.AppendAllText(receipt, (string)text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            order = 0;
            if (leftMoney == 0 || leftMoney < payout)
            {
                MessageBox.Show("돈이 부족합니다.");
            }
            else if (payout != 0 && leftMoney >= payout)
            {
                order = 1;
                leftMoney -= payout;
                label7.Text = Convert.ToString(leftMoney) + "원";
                label9.Text = Convert.ToString(0) + "원";
                CreateFile();
                payout = 0;
                listBox1.Items.Clear();
                MessageBox.Show("결제가 완료되었습니다. 영수증을 확인하세요.");
            }
            else
            {
                MessageBox.Show("결제할 상품이 없습니다.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            payout = 0;
            label9.Text = Convert.ToString(payout) + "원";
        }
    }
}

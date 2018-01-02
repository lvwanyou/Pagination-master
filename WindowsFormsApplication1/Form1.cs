using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        private int CurrentPage = 1;
        private int startPage = 1;
        private int endPage =15;
        private int range = 5;
        public Form1()
        {
            InitializeComponent();
            initPager();
        }

        //根据不同的endPage去初始化 button
        public void initPager()
        {
            label1.Text = "当前" + startPage + "/" + endPage + "页";
            if (endPage > 5)
            {
                button1.Text = "1";
                button2.Text = "2";
                button3.Text = "3";
                button4.Text = "4";
                button5.Text = "5";
            }
            else
            {
                for (int i = 0; i < endPage; i++)
                {
                    if(i==0)
                    {
                        button1.Text = "1";
                    }
                    if (i == 1)
                    {
                        button2.Text = "2";
                    }
                    if (i == 2)
                    {
                        button3.Text = "3";
                    }
                    if (i == 3)
                    {
                        button4.Text = "4";
                    }
                    if (i == 4)
                    {
                        button5.Text = "5";
                    }
                }
            }
            button1.BackColor = System.Drawing.Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeStatus(button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            changeStatus(button2);
        }
  

        private void button3_Click(object sender, EventArgs e)
        {
            changeStatus(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changeStatus(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            changeStatus(button5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            getButtonStatusByColor(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getButtonStatusByColor(button7);
        }

        public void getButtonStatusByColor(Button button )
        {
    
            //首先得到颜色显示在哪个button中，即事件焦点显示
            if (button1.BackColor == System.Drawing.Color.Red)
            {
                if (button.Name == "button6")
                {
                    //不做处理
                }else if (button.Name == "button7")
                {
                    changeStatus(button2);
                }
            }else
            if (button2.BackColor == System.Drawing.Color.Red)
            {
                if (button.Name == "button6")
                {
                    changeStatus(button1);
                }
                else if (button.Name == "button7")
                {
                    changeStatus(button3);
                }
            }else
            if (button3.BackColor == System.Drawing.Color.Red)
            {
                if (button.Name == "button6")
                {
                    changeStatus(button2);
                }
                else if (button.Name == "button7")
                {
                    changeStatus(button4);
                }
            }else
            if (button4.BackColor == System.Drawing.Color.Red)
            {
                if (button.Name == "button6")
                {
                    changeStatus(button3);
                }
                else if (button.Name == "button7")
                {
                    changeStatus(button5);
                }
            }else
            if (button5.BackColor == System.Drawing.Color.Red)
            {
                if (button.Name == "button6")
                {
                    changeStatus(button4);
                }
                else if (button.Name == "button7")
                {
                    //不做处理
                }
            }

        }
       

        //改变被点击按钮的颜色
        public void changeStatus(Button button)
        {
            button1.BackColor = Control.DefaultBackColor;
            button2.BackColor = Control.DefaultBackColor;
            button3.BackColor = Control.DefaultBackColor;
            button4.BackColor = Control.DefaultBackColor;
            button5.BackColor = Control.DefaultBackColor;
            CurrentPage=Convert.ToInt32(button.Text);       //获取当前页；被点击后页
            label1.Text ="当前" + CurrentPage + "/" + endPage + "页";
    
            if (endPage > 5)
            {
                //1-10
                if (System.Math.Abs(CurrentPage - startPage) >= 4 && System.Math.Abs(CurrentPage - endPage) >= 4)
                {
                    button1.Text = Convert.ToString(CurrentPage - 2);
                    button2.Text = Convert.ToString(CurrentPage - 1);
                    button3.Text = Convert.ToString(CurrentPage);
                    button4.Text = Convert.ToString(CurrentPage + 1);
                    button5.Text = Convert.ToString(CurrentPage + 2);
                    button3.BackColor = System.Drawing.Color.Red;
                }
                else if (System.Math.Abs(CurrentPage - startPage) >= 4 && System.Math.Abs(CurrentPage - endPage) < 4)
                {
                    int currentButton = range - System.Math.Abs(CurrentPage - endPage);
                    getCurrentButton(currentButton);
                }
                else
                {
                    getCurrentButton(CurrentPage);
                }
  /*             else if (System.Math.Abs(CurrentPage - startPage) < 4 && System.Math.Abs(CurrentPage - endPage) > 4)
                {
                  getCurrentButton(CurrentPage);              
                }
                else if (System.Math.Abs(CurrentPage - startPage) < 4 && System.Math.Abs(CurrentPage - endPage) <= 4)
                {
                 getCurrentButton(CurrentPage);                 
                }
   */
            }
            else   // 如果总页数小于五，就把对应的点击按钮变色
            {
                button.BackColor = System.Drawing.Color.Red;
            }
        }

        //如果button 需居中，刷新5个button的状态
        public Button getCurrentButton(int num)
        {
            button1.BackColor = Control.DefaultBackColor;
            button2.BackColor = Control.DefaultBackColor;
            button3.BackColor = Control.DefaultBackColor;
            button4.BackColor = Control.DefaultBackColor;
            button5.BackColor = Control.DefaultBackColor;
            switch (num){
            case 1:
                    button1.Text = Convert.ToString(CurrentPage);
                    button2.Text = Convert.ToString(CurrentPage + 1);
                    button3.Text = Convert.ToString(CurrentPage+2);
                    button4.Text = Convert.ToString(CurrentPage + 3);
                    button5.Text = Convert.ToString(CurrentPage + 4);
                    button1.BackColor = System.Drawing.Color.Red;
                    return button1;
                    break;
            case 2:
                   button1.Text = Convert.ToString(CurrentPage-1);
                    button2.Text = Convert.ToString(CurrentPage );
                    button3.Text = Convert.ToString(CurrentPage+1);
                    button4.Text = Convert.ToString(CurrentPage + 2);
                    button5.Text = Convert.ToString(CurrentPage + 3);
                    button2.BackColor = System.Drawing.Color.Red;
                    return button2;
                    break;
            case 3:
                    button1.Text = Convert.ToString(CurrentPage-2);
                    button2.Text = Convert.ToString(CurrentPage - 1);
                    button3.Text = Convert.ToString(CurrentPage);
                    button4.Text = Convert.ToString(CurrentPage +1);
                    button5.Text = Convert.ToString(CurrentPage +2);
                    button3.BackColor = System.Drawing.Color.Red;
                    return button3;
                    break;
            case 4:
                    button1.Text = Convert.ToString(CurrentPage - 3);
                    button2.Text = Convert.ToString(CurrentPage - 2);
                    button3.Text = Convert.ToString(CurrentPage-1);
                    button4.Text = Convert.ToString(CurrentPage );
                    button5.Text = Convert.ToString(CurrentPage + 1);
                    button4.BackColor = System.Drawing.Color.Red;
                    return button4;
                    break;
            case 5:
                    button1.Text = Convert.ToString(CurrentPage -4);
                    button2.Text = Convert.ToString(CurrentPage -3);
                    button3.Text = Convert.ToString(CurrentPage -2);
                    button4.Text = Convert.ToString(CurrentPage-1);
                    button5.Text = Convert.ToString(CurrentPage);
                    button5.BackColor = System.Drawing.Color.Red;
                    return button5;
                    break;
            }
            return null;
        }

  
        private void button8_Click(object sender, EventArgs e)
        {
            CurrentPage = Convert.ToInt32(textBox2.Text);
            if (CurrentPage < 5)
            {
                getCurrentButton(CurrentPage);
            }else
            {
                //
                Button temp = new Button();
                temp.Text = Convert.ToString(CurrentPage);
                changeStatus(temp);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}

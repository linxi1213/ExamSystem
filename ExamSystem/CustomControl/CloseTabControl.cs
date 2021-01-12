using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExamSystem.CustomControl
{
    public class CloseTabControl : TabItem
    {
        private TabItemControl tabItemControl;

        public CloseTabControl() 
        {
            tabItemControl = new TabItemControl();
            this.Header = tabItemControl;
            tabItemControl.btnClose.Click += Button_close_Click;
            
        }

        public string Title
        {
            set { tabItemControl.lblTitle.Content = value; }
        }

        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((TabItemControl)this.Header).btnClose.Visibility = Visibility.Hidden;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.IsSelected)
            {
                ((TabItemControl)this.Header).btnClose.Visibility = Visibility.Hidden;
            }
        }

        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((TabItemControl)this.Header).btnClose.Visibility = Visibility.Visible;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((TabItemControl)this.Header).btnClose.Visibility = Visibility.Visible;
        }

        private void Button_close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((TabControl)this.Parent).Items.Remove(this);
        }
    }
}

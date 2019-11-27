using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameAd
{
	/// <summary>
	/// Логика взаимодействия для GameWindow.xaml
	/// </summary>
	public partial class GameWindow : Window
	{
		public GameWindow()
		{
			InitializeComponent();
		}

		private void imagesOfGameClicked(object sender, MouseButtonEventArgs e)
		{
			var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
			if (item != null)
			{
				PictureWindow pictureWindow = new PictureWindow();
				pictureWindow.picture.Source = new BitmapImage(new Uri(item.Content.ToString(), UriKind.Absolute));
				pictureWindow.ShowDialog();
			}
		}
	}
}

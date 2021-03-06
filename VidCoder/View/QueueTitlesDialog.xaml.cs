﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HandBrake.Interop.SourceData;
using VidCoder.Services;
using VidCoder.ViewModel;

namespace VidCoder.View
{
	/// <summary>
	/// Interaction logic for MultipleTitlesDialog.xaml
	/// </summary>
	public partial class QueueTitlesDialog : Window
	{
		private QueueTitlesDialogViewModel viewModel;

		public QueueTitlesDialog()
		{
			InitializeComponent();

			this.DataContextChanged += this.OnDataContextChanged;
		}

		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			this.SetPlacement(Config.QueueTitlesDialogPlacement2);
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			this.viewModel = this.DataContext as QueueTitlesDialogViewModel;
			this.viewModel.PropertyChanged += this.viewModel_PropertyChanged;
		}

		private void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "PreviewImage")
			{
				this.RefreshImageSize();
			}
		}

		private void RefreshImageSize()
		{
			var previewVM = this.DataContext as QueueTitlesDialogViewModel;
			if (previewVM.SelectedTitles.Count != 1)
			{
				return;
			}

			double widthPixels, heightPixels;

			Title title = previewVM.SelectedTitles[0].Title;
			if (title.ParVal.Width > title.ParVal.Height)
			{
				widthPixels = title.Resolution.Width * ((double)title.ParVal.Width / title.ParVal.Height);
				heightPixels = title.Resolution.Height;
			}
			else
			{
				widthPixels = title.Resolution.Width;
				heightPixels = title.Resolution.Height * ((double) title.ParVal.Height / title.ParVal.Width);
			}

			ImageUtilities.UpdatePreviewImageSize(this.previewImage, this.previewImageHolder, widthPixels, heightPixels);
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Config.QueueTitlesDialogPlacement2 = this.GetPlacement();
		}

		private void previewImageHolder_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.RefreshImageSize();
		}
	}
}

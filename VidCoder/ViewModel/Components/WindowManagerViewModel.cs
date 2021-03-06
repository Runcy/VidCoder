﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace VidCoder.ViewModel.Components
{
	/// <summary>
	/// Controls opening/closing of windows.
	/// </summary>
	public class WindowManagerViewModel : ViewModelBase
	{
		private MainViewModel main = Ioc.Container.GetInstance<MainViewModel>();

		private bool encodingWindowOpen;
		private bool previewWindowOpen;
		private bool logWindowOpen;
		private bool encodeDetailsWindowOpen;

		public bool EncodingWindowOpen
		{
			get
			{
				return this.encodingWindowOpen;
			}

			set
			{
				this.encodingWindowOpen = value;
				this.RaisePropertyChanged(() => this.EncodingWindowOpen);
			}
		}

		public bool PreviewWindowOpen
		{
			get
			{
				return this.previewWindowOpen;
			}

			set
			{
				this.previewWindowOpen = value;
				this.RaisePropertyChanged(() => this.PreviewWindowOpen);
			}
		}

		public bool LogWindowOpen
		{
			get
			{
				return this.logWindowOpen;
			}

			set
			{
				this.logWindowOpen = value;
				this.RaisePropertyChanged(() => this.LogWindowOpen);
			}
		}

		public bool EncodeDetailsWindowOpen
		{
			get
			{
				return this.encodeDetailsWindowOpen;
			}

			set
			{
				this.encodeDetailsWindowOpen = value;
				this.RaisePropertyChanged(() => this.EncodeDetailsWindowOpen);
			}
		}

		private ICommand openEncodingWindowCommand;
		public ICommand OpenEncodingWindowCommand
		{
			get
			{
				if (this.openEncodingWindowCommand == null)
				{
					this.openEncodingWindowCommand = new RelayCommand(() =>
					{
						this.OpenEncodingWindow();
					});
				}

				return this.openEncodingWindowCommand;
			}
		}

		private ICommand openPreviewWindowCommand;
		public ICommand OpenPreviewWindowCommand
		{
			get
			{
				if (this.openPreviewWindowCommand == null)
				{
					this.openPreviewWindowCommand = new RelayCommand(() =>
					{
						this.OpenPreviewWindow();
					});
				}

				return this.openPreviewWindowCommand;
			}
		}

		private ICommand openLogWindowCommand;
		public ICommand OpenLogWindowCommand
		{
			get
			{
				if (this.openLogWindowCommand == null)
				{
					this.openLogWindowCommand = new RelayCommand(() =>
					{
						this.OpenLogWindow();
					});
				}

				return this.openLogWindowCommand;
			}
		}

		private RelayCommand openEncodeDetailsWindowCommand;
		public RelayCommand OpenEncodeDetailsWindowCommand
		{
			get
			{
				return this.openEncodeDetailsWindowCommand ?? (this.openEncodeDetailsWindowCommand = new RelayCommand(() =>
					{
						this.OpenEncodeDetailsWindow();
					},
					() =>
					{
						return this.main.ProcessingVM.Encoding;
					}));
			}
		}

		public void OpenEncodingWindow()
		{
			var encodingWindow = WindowManager.FindWindow(typeof(EncodingViewModel)) as EncodingViewModel;
			this.EncodingWindowOpen = true;

			if (encodingWindow == null)
			{
				encodingWindow = new EncodingViewModel(Ioc.Container.GetInstance<PresetsViewModel>().SelectedPreset.Preset);
				encodingWindow.Closing = () =>
				{
					this.EncodingWindowOpen = false;

					// Focus the main window after closing. If they used a keyboard shortcut to close it might otherwise give up
					// focus on the app altogether.
					WindowManager.FocusWindow(this.main);
				};
				WindowManager.OpenWindow(encodingWindow, this.main);
			}
			else
			{
				WindowManager.FocusWindow(encodingWindow);
			}
		}

		public void OpenPreviewWindow()
		{
			var previewWindow = WindowManager.FindWindow(typeof(PreviewViewModel)) as PreviewViewModel;
			this.PreviewWindowOpen = true;

			if (previewWindow == null)
			{
				previewWindow = new PreviewViewModel();
				previewWindow.Closing = () =>
				{
					this.PreviewWindowOpen = false;
				};
				WindowManager.OpenWindow(previewWindow, this.main);
			}
			else
			{
				WindowManager.FocusWindow(previewWindow);
			}
		}

		public void OpenLogWindow()
		{
			var logWindow = WindowManager.FindWindow(typeof(LogViewModel)) as LogViewModel;
			this.LogWindowOpen = true;

			if (logWindow == null)
			{
				logWindow = new LogViewModel();
				logWindow.Closing = () =>
				{
					this.LogWindowOpen = false;
				};
				WindowManager.OpenWindow(logWindow, this.main);
			}
			else
			{
				WindowManager.FocusWindow(logWindow);
			}
		}

		public void OpenEncodeDetailsWindow()
		{
			var encodeDetailsWindow = WindowManager.FindWindow(typeof (EncodeDetailsViewModel)) as EncodeDetailsViewModel;
			this.EncodeDetailsWindowOpen = true;

			if (encodeDetailsWindow == null)
			{
				encodeDetailsWindow = new EncodeDetailsViewModel();
				encodeDetailsWindow.Closing = () =>
				{
					this.EncodeDetailsWindowOpen = false;
				};

				Config.EncodeDetailsWindowOpen = true;

				WindowManager.OpenWindow(encodeDetailsWindow, this.main);
			}
			else
			{
				WindowManager.FocusWindow(encodeDetailsWindow);
			}
		}

		public void CloseEncodeDetailsWindow()
		{
			var encodeDetailsWindow = WindowManager.FindWindow(typeof(EncodeDetailsViewModel)) as EncodeDetailsViewModel;
			if (encodeDetailsWindow != null)
			{
				WindowManager.Close(encodeDetailsWindow);
			}
		}

		public void RefreshEncoding()
		{
			this.OpenEncodeDetailsWindowCommand.RaiseCanExecuteChanged();
		}
	}
}

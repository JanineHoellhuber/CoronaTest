﻿
using CoronaTest.Wpf.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Windows;
using CoronaTest.WPF;
using CoronaTest.Wpf.ViewModels;

namespace CoronaTest.Wpf.Common
{
  public class WindowController : IWindowController
  {
    private readonly Dictionary<BaseViewModel, Window> _windows
      = new Dictionary<BaseViewModel, Window>();

    public void ShowWindow(BaseViewModel viewModel, bool showAsDialog = false)
    {
      Window window = viewModel switch
      {
        // Wenn viewModel null ist -> ArgumentNullException
        null => throw new ArgumentNullException(nameof(viewModel)),

        MainViewModel _ => new MainWindow(),
        ParticipantViewModel _ => new ParticipantWindow(),

        // default -> InvalidOperationException
        _ => throw new InvalidOperationException($"Unbekanntes ViewModel '{viewModel}'"),
      };

      _windows[viewModel] = window;

      window.DataContext = viewModel;

      if (showAsDialog)
      {
        window.ShowDialog();
      }
      else
      {
        window.Show();
      }
    }

    public void CloseWindow(BaseViewModel viewModel)
    {
      if (_windows.ContainsKey(viewModel))
      {
        Window window = _windows[viewModel];
        _windows.Remove(viewModel);
        window.Close();
      }
    }
  }
}
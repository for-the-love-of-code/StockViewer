﻿using StockViewerUI.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public interface IBaseViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
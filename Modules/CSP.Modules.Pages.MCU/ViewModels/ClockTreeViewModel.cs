﻿using CSP.Modules.Pages.MCU.Tools;
using CSP.Resources;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.IO;
using CSP.Utils;

namespace CSP.Modules.Pages.MCU.ViewModels
{
    public class ClockTreeViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        private double _canvasHeight = 900;
        private double _canvasWidth = 1600;
        private Uri _clockTreeImage;

        public ClockTreeViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            var path =
                $"{DescriptionHelper.RepositoryPath}/description/{DescriptionHelper.Name.ToLower()}/clock/{DescriptionHelper.MCU.Name}.svg";
            DebugUtil.Assert(File.Exists(path), new FileNotFoundException(nameof(path)), $"{path}: 不存在");
            if (File.Exists(path))
                ClockTreeImage = new Uri(path, UriKind.Relative);
        }

        public double CanvasHeight {
            get => _canvasHeight;
            set => SetProperty(ref _canvasHeight, value);
        }

        public double CanvasWidth {
            get => _canvasWidth;
            set => SetProperty(ref _canvasWidth, value);
        }

        public Uri ClockTreeImage {
            get => _clockTreeImage;
            set => SetProperty(ref _clockTreeImage, value);
        }
    }
}
﻿namespace bperezT6B
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            MainPage = new NavigationPage(new Views.vEstudiante());
        }
    }
}
